﻿using RTH.Business.Objects;
using RTH.Business.Services;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class HealthPlanQuestionnaireViewModel : ViewModelBase
    {
        public HealthPlanQuestionnaireViewModel()
        {
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = AppMessages.targets;
        }
        public override void Refresh()
        {
            CurrentQuestion = null;
            HealthPlanText = null;
            HealthStrategyRequest = new HealthQuestionnaireRequest();
        }
        public string HealthPlanText
        {
            get { return GetValue(() => HealthPlanText); }
            set { SetValue(() => HealthPlanText, value); }
        }

        public Question CurrentQuestion
        {
            get { return GetValue(() => CurrentQuestion); }
            set { SetValue(() => CurrentQuestion, value); }
        }
        public ObservableCollection<Question> AllQuestions
        {
            get { return GetValue(() => AllQuestions); }
            set { SetValue(() => AllQuestions, value); }
        }
        public ArrayList QuestionWithoutDependency
        {
            get { return GetValue(() => QuestionWithoutDependency); }
            set { SetValue(() => QuestionWithoutDependency, value); }
        }
        public Hashtable DependentQuestion
        {
            get { return GetValue(() => DependentQuestion); }
            set { SetValue(() => DependentQuestion, value); }
        }

        public Int32 CurrentCategoryCount
        {
            get { return GetValue(() => CurrentCategoryCount); }
            set { SetValue(() => CurrentCategoryCount, value); }
        }
        public string objectiveId
        {
            get { return GetValue(() => objectiveId); }
            set { SetValue(() => objectiveId, value); }
        }

        private void SetHeader()
        {
            HeaderColor = CurrentQuestion.Category.color;
            KeyString = "None";
            FooterVisibility = false;
            SharingIconVisibility = false;
        }
        public HealthPlanQuestionnaireData HealthplanQuestionnaire
        {
            get { return GetValue(() => HealthplanQuestionnaire); }
            set { SetValue(() => HealthplanQuestionnaire, value); }
        }
        public async void GetHealthPlanQuestion(string ObjectiveId)
        {
            objectiveId = ObjectiveId;
            await AsyncCall.Invoke(() =>
             {
                 ObservableCollection<Question> ques = new ObservableCollection<Question>();
                 //Get Question Answer From the bellow API
                 var result = HealthPlanServices.GetHealthPlan(UserDetails._id, UserDetails.AuthToken.access_token);

                 var ObjectiveData = HealthPlanServices.GetHealthPlanObjective(UserDetails._id, ObjectiveId, UserDetails.AuthToken.access_token).data.questions;
                 //Get Question From the bellow API
                 var healthplanquestion = HealthPlanServices.GetHealthPlanQuestionaries(UserDetails._id, ObjectiveId, UserDetails.AuthToken.access_token).data;
                 HealthplanQuestionnaire = healthplanquestion;

                 var CategoriesQuestion = GetCategoryQuestion(healthplanquestion.questions, ObjectiveData);
                 if (CategoriesQuestion != null)
                 {
                     ques.AddRange(GetCategoryQuestion(healthplanquestion.questions, ObjectiveData));
                 }
                 AllQuestions = ques;
                 if (AllQuestions.Count == 0)
                 {
                     QuestionWithoutDependency = new ArrayList();
                     DependentQuestion = new Hashtable();
                     RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.HealthQuestionaire });
                 }
                 else
                 {
                     CurrentQuestion = AllQuestions[0];
                     QuestionWithoutDependency = GetQuestionWithoutDependency();
                     DependentQuestion = GetDependentHasTable();
                     SetHeader();
                 }
                 HealthPlanText = result.Where(x => x._id.Equals(ObjectiveId)).FirstOrDefault().objective_title;
                 HealthStrategyRequest.key_string = result.Where(x => x._id.Equals(ObjectiveId)).FirstOrDefault().key_string == null ? string.Empty : result.Where(x => x._id.Equals(ObjectiveId)).FirstOrDefault().key_string;
                 return true;
             });
        }

        private ObservableCollection<Question> GetCategoryQuestion(ObservableCollection<HealthPlanQuestionnaire> questions, List<Answer> oHealthAllQuestion)
        {
            ObservableCollection<Question> ques = new ObservableCollection<Question>();
            foreach (var item in questions)
            {
                //Get category Question 
                if (item.questions != null)
                {
                    foreach (var q in item.questions)
                    {
                        q.question_alias = string.IsNullOrEmpty(q.question_alias) ? q.question : q.question_alias;
                        q.Category = item.category;
                        if (oHealthAllQuestion != null)
                        {
                            if (oHealthAllQuestion.Where(x => x.question == q._id).Any())
                            {
                                if (oHealthAllQuestion.Where(x => x.question == q._id).Any())
                                {
                                    var _UserAnswer = oHealthAllQuestion.Where(a => a.question == q._id).FirstOrDefault();
                                    if (_UserAnswer.answer != null)
                                    {
                                        if (_UserAnswer.answer.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                                        {
                                            var ArrayAnaswer = (Newtonsoft.Json.Linq.JArray)_UserAnswer.answer;
                                            foreach (var _a in ArrayAnaswer)
                                            {
                                                var ss = _a.ToString().Replace("[", "").Replace("]", "").Trim();
                                                Answer a = new Answer();
                                                a.date = Convert.ToString(DateTime.Now.Ticks);
                                                a.key_string = q.key_string;
                                                a.element_type = q.element_type;
                                                a.question = q._id;
                                                a.answer = ss;
                                                a.answer_overrider = q.answers.Where(x => x._id.Equals(ss)).Select(x => x.answer_overrider).FirstOrDefault();
                                                q.SelectedAnswers.Add(a);

                                            }
                                        }
                                        else
                                        {
                                            if ((String)_UserAnswer.answer != "none")
                                            {
                                                q.SelectedAnswers = new ObservableCollection<Answer>(oHealthAllQuestion.Where(x => x.question == q._id));
                                            }
                                            else if ((String)_UserAnswer.answer == "none" && q.element_type == 4)
                                            {
                                                q.SelectedAnswers = new ObservableCollection<Answer>(oHealthAllQuestion.Where(x => x.question == q._id));
                                                q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(q.SelectedAnswers[0].response);
                                            }
                                        }

                                    }
                                }

                                ques.Add(q);
                            }
                            else {
                                q.SelectedAnswers = null;
                                ques.Add(q);
                            }
                        }
                        else {
                            q.SelectedAnswers = null;
                            ques.Add(q);
                        }
                    }
                    if (item.subcategories != null)
                    {
                        foreach (var subcategory in item.subcategories)
                        {
                            if (subcategory.questions != null)
                            {
                                foreach (var q in subcategory.questions)
                                {
                                    q.question_alias = string.IsNullOrEmpty(q.question_alias) ? q.question : q.question_alias;
                                    q.Category = item.category;
                                    q.SubCategory = subcategory.subcategory;
                                    q.SelectedAnswers = new ObservableCollection<Answer>();
                                    if (oHealthAllQuestion != null)
                                    {
                                        if (oHealthAllQuestion.Where(x => x.question == q._id).Any())
                                        {
                                            var _UserAnswer = oHealthAllQuestion.Where(a => a.question == q._id).FirstOrDefault();
                                            if (_UserAnswer.answer != null)
                                            {
                                                if (_UserAnswer.answer.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                                                {
                                                    var ArrayAnaswer = (Newtonsoft.Json.Linq.JArray)_UserAnswer.answer;
                                                    foreach (var _a in ArrayAnaswer)
                                                    {

                                                        var ss = _a.ToString().Replace("[", "").Replace("]", "").Trim();
                                                        Answer a = new Answer();
                                                        a.date = Convert.ToString(DateTime.Now.Ticks);
                                                        a.key_string = q.key_string;
                                                        a.element_type = q.element_type;
                                                        a.question = q._id;
                                                        a.answer = ss;
                                                        a.answer_overrider = q.answers.Where(x => x._id.Equals(ss)).Select(x => x.answer_overrider).FirstOrDefault();
                                                        q.SelectedAnswers.Add(a);

                                                    }
                                                }
                                                else
                                                {
                                                    if ((String)_UserAnswer.answer != "none")
                                                    {
                                                        q.SelectedAnswers = new ObservableCollection<Answer>(oHealthAllQuestion.Where(x => x.question == q._id));
                                                    }
                                                    else if ((String)_UserAnswer.answer == "none" && q.element_type == 4)
                                                    {
                                                        q.SelectedAnswers = new ObservableCollection<Answer>(oHealthAllQuestion.Where(x => x.question == q._id));
                                                        q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(q.SelectedAnswers[0].response);
                                                    }
                                                }

                                            }
                                            ques.Add(q);

                                        }
                                        else {
                                            q.SelectedAnswers = null;
                                            ques.Add(q);
                                        }
                                    }
                                    else {
                                        q.SelectedAnswers = null;
                                        ques.Add(q);
                                    }
                                }
                            }
                        }

                    }

                }
            }
            return ques;
        }
        private Hashtable GetDependentHasTable(object Gender = null)
        {
            Hashtable HasDependency = new Hashtable();
            ObservableCollection<Question> questions = AllQuestions;
            if (Gender == null)
            {
                var Dependency = (from dependentquestion in questions where dependentquestion.dependency.dependency_question != null select dependentquestion);
                foreach (var item in Dependency)
                {
                    //HasDependency.Add(item.dependency,item)
                    ArrayList ADependent = new ArrayList();
                    var DependentQuestion = (from dependentquestion in Dependency where dependentquestion.dependency.dependency_question.Equals(item.dependency.dependency_question) select dependentquestion).ToList();

                    foreach (var _item in DependentQuestion)
                    {

                        ADependent.Add(_item);
                    }
                    if (!HasDependency.Contains(item.dependency.dependency_question))
                    {
                        HasDependency.Add(item.dependency.dependency_question, ADependent);
                    }
                }
            }
            else
            {
                var Dependency = (from dependentquestion in questions where dependentquestion.dependency.dependency_question != null select dependentquestion);
                foreach (var item in Dependency)
                {
                    //HasDependency.Add(item.dependency,item)
                    ArrayList ADependent = new ArrayList();
                    Int32 _Gender = Convert.ToInt32(Gender);

                    var DependentQuestionExceptSex = (from dependentquestion in Dependency where dependentquestion.dependency.dependency_question.Equals(item.dependency.dependency_question) && dependentquestion.gender != _Gender select dependentquestion).ToList();
                    foreach (var _item in DependentQuestionExceptSex)
                    {
                        ADependent.Add(_item);
                    }
                    if (!HasDependency.Contains(item.dependency.dependency_question))
                    {
                        HasDependency.Add(item.dependency.dependency_question, ADependent);
                    }
                }
            }
            return HasDependency;
        }

        private ArrayList GetQuestionWithoutDependency(object Gender = null)
        {
            ArrayList AWithoutDependency = new ArrayList();
            if (Gender == null)
            {

                ObservableCollection<Question> questions = AllQuestions;
                var WithoutDependency = (from dependentquestion in questions where dependentquestion.dependency.dependency_question == null select dependentquestion);
                foreach (var item in WithoutDependency)
                {
                    AWithoutDependency.Add(item);
                }
            }
            else
            {
                Int32 _Gender = Convert.ToInt32(Gender);
                ObservableCollection<Question> questions = AllQuestions;
                var WithoutDependency = (from dependentquestion in questions where dependentquestion.dependency.dependency_question == null && dependentquestion.gender != _Gender select dependentquestion);
                foreach (var item in WithoutDependency)
                {
                    AWithoutDependency.Add(item);
                }
                AWithoutDependency.RemoveRange(0, 2);
            }
            return AWithoutDependency;
        }
        public Uri SourceHelperImage
        {
            get { return GetValue(() => SourceHelperImage); }
            set { SetValue(() => SourceHelperImage, value); }
        }

        public String Summary
        {
            get { return GetValue(() => Summary); }
            set { SetValue(() => Summary, value); }
        }

        public async Task<HRASubmit> MoveToQuestion(int moveIndex, SecureString securePwd)
        {
            /* 0  for sucess , 1 for Application Error , -1 For service Error */
            if (QuestionWithoutDependency.Count == 0) { return await SetHealtAnswer().ConfigureAwait(false); }
            SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);
            Summary = null;
            if (moveIndex == 1 && !ValidateAnswer()) return HRASubmit.Continue;
            ArrayList SelectedAnswer = new ArrayList();
            foreach (var item in CurrentQuestion.SelectedAnswers)
            {
                SelectedAnswer.Add(Convert.ToString(item.answer));
            }
            RemoveQuestion = null;
            List<Question> _GetExistingDependentRecord = CheckForRecursiveDependentQuestion(CurrentQuestion);
            foreach (var item in _GetExistingDependentRecord)
            {
                if (QuestionWithoutDependency.Contains(item))
                    QuestionWithoutDependency.Remove(item);
            }
            ArrayList _questionId = CheckForDependentQuestion(CurrentQuestion, SelectedAnswer);

            if (_questionId != null && _questionId.Count > 0)
            {
                for (int i = 0; i < _questionId.Count; i++)
                {
                    if (i > 0)
                    {
                        if (QuestionWithoutDependency.Contains((Question)_questionId[i - 1]))
                        {
                            QuestionWithoutDependency.Insert(QuestionWithoutDependency.IndexOf((Question)_questionId[i - 1]) + 1, _questionId[i]);
                        }
                    }
                    else
                    {
                        QuestionWithoutDependency.Insert(QuestionWithoutDependency.IndexOf(CurrentQuestion) + 1, (Question)_questionId[i]);
                    }

                }
            }

            if (CurrentQuestion != (Question)QuestionWithoutDependency[QuestionWithoutDependency.Count - 1])
            {
                string PreviousQKeyString = CurrentQuestion.key_string;
                CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(CurrentQuestion) + 1];
                CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);
                return HRASubmit.Continue;
            }

            if (QuestionWithoutDependency[QuestionWithoutDependency.Count - 1] == CurrentQuestion)
            {
                CurrentQuestion = null;
                return await SetHealtAnswer().ConfigureAwait(false);
            }
            return HRASubmit.Continue;

        }

        private async Task<HRASubmit> SetHealtAnswer()
        {
            return await AsyncCall.Invoke(() =>
            {
                var ObjectiveData = HealthPlanServices.GetHealthPlanObjective(UserDetails._id, objectiveId, UserDetails.AuthToken.access_token).data.all_answers;
                GetObjectiveAnswer(ObjectiveData);
                return HRASubmit.Completed;
            }).ConfigureAwait(false);
        }

        private void GetObjectiveAnswer(List<Answer> objectiveData)
        {
            if (objectiveData == null) { objectiveData = new List<Answer>(); }
            List<Answer> RemoveAnswer = new List<Answer>();
            List<Answer> NewAnswer = new List<Answer>();
            if (objectiveData.Count != 0)
            {
                foreach (var item in objectiveData)
                {
                    List<Answer> ListAnswer = GetQuestionnaireAnswer(item.question);
                    if (ListAnswer.Count() > 0)
                    {
                        foreach (var SelectedAnswer in ListAnswer)
                        {
                            var Ans = (from q in objectiveData where q.question.Equals(SelectedAnswer.question) select q).ToList();
                            RemoveAnswer.InsertRange(RemoveAnswer.Count, Ans);
                        }
                        NewAnswer.InsertRange(NewAnswer.Count(), ListAnswer);
                    }

                }
                foreach (var item in RemoveAnswer)
                {
                    objectiveData.Remove(item);
                }
                objectiveData.InsertRange(objectiveData.Count(), NewAnswer);
                List<AnswerRequest> oAnswerRequest = new List<AnswerRequest>();
                if (RemoveAnswer.Count == 0)
                {
                    foreach (Question item in QuestionWithoutDependency)
                    {
                        foreach (var answeritem in item.SelectedAnswers)
                        {
                            oAnswerRequest.Add(new AnswerRequest
                            {
                                answer = answeritem.answer == null ? "none" : answeritem.answer,
                                date = Convert.ToString(DateTime.Now.Ticks),
                                key_string = answeritem.key_string,
                                element_type = answeritem.element_type,
                                question = answeritem.question,
                                response2 = Convert.ToString(answeritem.response2) == "" ? "none" : answeritem.response2,
                                response1 = Convert.ToString(answeritem.response1) == "" ? "none" : answeritem.response1,
                                response = Convert.ToString(answeritem.response) == "" ? "none" : answeritem.response
                            });
                        }
                    }
                }

                foreach (var item in objectiveData)
                {
                    oAnswerRequest.Add(new AnswerRequest
                    {
                        answer = item.answer == null ? "none" : item.answer,
                        date = Convert.ToString(DateTime.Now.Ticks),
                        key_string = item.key_string,
                        element_type = item.element_type,
                        question = item.question,
                        response2 = Convert.ToString(item.response2) == "" ? "none" : item.response2,
                        response1 = Convert.ToString(item.response1) == "" ? "none" : item.response1,
                        response = Convert.ToString(item.response) == "" ? "none" : item.response
                    });
                }

                HealthStrategyRequest.question = oAnswerRequest;
            }
            else
            {
                List<Answer> NewObject = new List<Answer>();
                var query = from Question num in QuestionWithoutDependency
                            select num.SelectedAnswers;
                foreach (var item in query)
                {
                    foreach (var InnterAnswer in item)
                    {
                        NewObject.Add(InnterAnswer);
                    }
                }

                List<AnswerRequest> oAnswerRequest = new List<AnswerRequest>();
                foreach (var item in NewObject)
                {
                    oAnswerRequest.Add(new AnswerRequest
                    {
                        answer = item.answer == null ? "none" : item.answer,
                        date = Convert.ToString(DateTime.Now.Ticks),
                        key_string = item.key_string,
                        element_type = item.element_type,
                        question = item.question,
                        response2 = Convert.ToString(item.response2) == "" ? "none" : item.response2,
                        response1 = Convert.ToString(item.response1) == "" ? "none" : item.response1,
                        response = Convert.ToString(item.response) == "" ? "none" : item.response
                    });
                }

                HealthStrategyRequest.question = oAnswerRequest;

            }

        }
        private List<Answer> GetQuestionnaireAnswer(string _id)
        {
            List<Answer> SelectedAnswer = new List<Answer>();
            if ((from Question s in QuestionWithoutDependency where s._id.Equals(_id) select s).Any())
            {
                var _Answer = (from Question s in QuestionWithoutDependency where s._id.Equals(_id) select s.SelectedAnswers).FirstOrDefault();
                if (_Answer != null)
                {
                    foreach (var answeritem in _Answer)
                    {
                        SelectedAnswer.Add(answeritem);
                    }
                }
            }
            return SelectedAnswer;
        }

        public int MoveToQuestionPrevious(int v)
        {
            SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);
            Summary = null;
            string CurrentQuestionKeyString = CurrentQuestion.key_string;
            if (QuestionWithoutDependency.IndexOf(CurrentQuestion) != 0)
            {
                CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(CurrentQuestion) - 1];
                CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);
                return 1;
            }
            else { return QuestionWithoutDependency.IndexOf(CurrentQuestion); }

        }
        public List<Question> RemoveQuestion { get; set; }
        private List<Question> CheckForRecursiveDependentQuestion(Question currentQuestion)
        {
            if (RemoveQuestion == null)
            { RemoveQuestion = new List<Question>(); }
            var query = from Question num in QuestionWithoutDependency
                        where num.dependency.dependency_question == currentQuestion._id
                        select num;

            foreach (var item in query)
            {
                if (RemoveQuestion != null)
                {
                    if (!RemoveQuestion.Contains(item))
                    {
                        RemoveQuestion.Add((Question)item);
                    }
                }
            }
            foreach (var item in query)
            {
                return CheckForRecursiveDependentQuestion((Question)item);
            }

            return RemoveQuestion;

        }
        private ArrayList CheckForDependentQuestion(Question currentQuestion, ArrayList selectedAnswer)
        {
            ArrayList _QuestionId = null;
            if (DependentQuestion.Contains(currentQuestion._id))
            {
                ArrayList AllDependentQuestion = (ArrayList)DependentQuestion[currentQuestion._id];
                List<Question> Dependent_Question = new List<Business.Objects.Question>();
                for (int i = 0; i < AllDependentQuestion.Count; i++)
                {
                    Dependent_Question.Add((Question)AllDependentQuestion[i]);
                }
                _QuestionId = GetDependentQuestionIdHavingAnswer(selectedAnswer, Dependent_Question);
            }
            return _QuestionId;
        }
        private ArrayList GetDependentQuestionIdHavingAnswer(ArrayList selectedAnswer, List<Question> getAllDependentQuestion)
        {
            var _questionId = (from a in getAllDependentQuestion select a);
            ArrayList SelectedQuestion = new ArrayList();

            string _QuestionID = null;
            foreach (var item in _questionId)
            {
                var MatchedAnswer = item.dependency.dependency_answer.ToArray().Intersect(selectedAnswer.ToArray()).Any();
                //!item.dependency.dependency_answer.ToArray().Except(selectedAnswer.ToArray()).Any()
                //        && !selectedAnswer.ToArray().Except(item.dependency.dependency_answer.ToArray()).Any();
                if (MatchedAnswer)
                {
                    _QuestionID = item._id;
                    SelectedQuestion.Add(item);
                    // break;
                }
            }
            return SelectedQuestion;
        }
        private bool ValidateAnswer()
        {

            #region Simple Text Validation
            if (
                CurrentQuestion.key_string.Equals("cigarettes_count") ||
                CurrentQuestion.key_string.Equals("mod_literal") ||
                CurrentQuestion.key_string.Equals("vig_literal") ||
                CurrentQuestion.key_string.Equals("alcopop_m") ||
                CurrentQuestion.key_string.Equals("fortified_m") ||
                CurrentQuestion.key_string.Equals("liqueur_m") ||
                CurrentQuestion.key_string.Equals("spirit_m") ||
                CurrentQuestion.key_string.Equals("wine_m") ||
                CurrentQuestion.key_string.Equals("beer_m") ||
                CurrentQuestion.key_string.Equals("alcopop_w") ||
                CurrentQuestion.key_string.Equals("fortified_w") ||
                CurrentQuestion.key_string.Equals("liqueur_w") ||
                CurrentQuestion.key_string.Equals("spirit_w") ||
                CurrentQuestion.key_string.Equals("wine_w") ||
                CurrentQuestion.key_string.Equals("beer_w") ||
                CurrentQuestion.key_string.Equals("night_shift_total_years") ||
                CurrentQuestion.key_string.Equals("menarchy_age") ||
                CurrentQuestion.key_string.Equals("given_birth_total") ||
                CurrentQuestion.key_string.Equals("menopause_age")
                )
            {
                if (string.IsNullOrEmpty(Convert.ToString(CurrentQuestion.SelectedAnswers[0].response)) || Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].response) == 0)
                {
                    CurrentQuestion.ErrorMessage = AppMessages.missing_answer;
                    return false;
                }
                else
                {

                    var Range = (Range)CurrentQuestion.ranges.SingleOrDefault();
                    if (Range != null)
                    {
                        if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].response) < Range.min)
                        {
                            CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                            return false;
                        }
                        if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].response) > Range.max)
                        {
                            CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                            return false;
                        }
                    }
                    // return true;
                }
            }

            #region DateValidation
            if (CurrentQuestion.element_type == 6)
            {
                if (string.IsNullOrEmpty(Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer)) || Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "none")
                {
                    CurrentQuestion.ErrorMessage = AppMessages.missing_answer;
                    return false;
                }
                else
                {
                    System.Globalization.DateTimeFormatInfo df = new System.Globalization.DateTimeFormatInfo();
                    df.ShortDatePattern = "YYYY-MM-DD";
                    DateTime dt = Convert.ToDateTime(CurrentQuestion.SelectedAnswers[0].answer, df);
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("days")).SingleOrDefault();
                    if (Range != null)
                    {
                        Range.MinDate = DateTime.UtcNow.AddDays(Range.min);
                        Range.MaxDate = DateTime.UtcNow.AddDays(Range.max);
                        if (dt > Range.MaxDate || dt < Range.MinDate)
                        {
                            CurrentQuestion.ErrorMessage = String.Format("Out of range! Expected between {0:dd-MM-yyyy} and {1:dd-MM-yyyy}", Range.MinDate, Range.MaxDate);
                            return false;
                        }
                    }
                    else
                    {
                        TimeSpan ts = dt.Subtract(Convert.ToDateTime(DateTime.Now, df));
                        var ans = UserDetails.answers != null && UserDetails.answers.Any() ? UserDetails.answers.FirstOrDefault(a => a.question == "537f57042140f60800de43c9") : null;
                        var targetAns = AllQuestions.FirstOrDefault(q => q._id == "537f57042140f60800de43c9");
                        double currWeight, targetWeight = 0;
                        if (ts.Days <= 0)
                        {
                            CurrentQuestion.ErrorMessage = String.Format("Please select a valid future date!");
                            return false;
                        }
                        else if (ans != null && double.TryParse(ans.response.ToString(), out currWeight) && double.TryParse(targetAns.SelectedAnswers[0].response.ToString(), out targetWeight) && Math.Abs(currWeight - targetWeight) / (ts.Days / 7) > 1)
                        {
                            CurrentQuestion.ErrorMessage = "Your weight loss target may be a little ambitious for the timescale you’ve selected - please either reduce your target weight or delay your target date so that you lose no more than 1kg per week";
                            return false;
                        }
                    }
                }
            }

            #endregion
            #region Single Select Validation
            if (CurrentQuestion.element_type == 0)
            {
                if (string.IsNullOrEmpty(Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer)) || Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "none")
                {
                    CurrentQuestion.ErrorMessage = AppMessages.missing_option;
                    return false;
                }
            }
            #endregion
            #region MultiSelect Select Validation
            if (CurrentQuestion.element_type == 7)
            {
                if (CurrentQuestion.SelectedAnswers.Count() == 1)
                {
                    if (CurrentQuestion.SelectedAnswers[0].answer == null || Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "" || Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "none")
                    { CurrentQuestion.SelectedAnswers = new ObservableCollection<Answer>(); }
                }
                if (CurrentQuestion.SelectedAnswers.Count() == 0)
                {
                    CurrentQuestion.ErrorMessage = AppMessages.missing_option;
                    return false;
                }
                if (CurrentQuestion.SelectedAnswers.Count() == 1)
                {
                    if (string.IsNullOrEmpty(Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer)) || Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "none")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.missing_option;
                        return false;
                    }
                }
            }
            #endregion
            #endregion

            #region Height Validations 
            if (CurrentQuestion.key_string.Equals("height"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "cm")
                {
                    CurrentQuestion.SelectedAnswers[0].answer = "cm";
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseCM) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseCM) == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("cm")).SingleOrDefault();
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseCM) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseCM) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "m")
                {
                    CurrentQuestion.SelectedAnswers[0].answer = "m";
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseM) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseM) == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("m")).SingleOrDefault();
                    Double _maxrange = ((Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseM) * 100) + Convert.ToDouble(CurrentQuestion.SelectedAnswers[0]._responseMCM == "" ? "0" : CurrentQuestion.SelectedAnswers[0]._responseMCM)) / 100;
                    if (_maxrange > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                    if (_maxrange < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "feet")
                {
                    CurrentQuestion.SelectedAnswers[0].answer = "feet";
                    if (string.IsNullOrEmpty(CurrentQuestion.SelectedAnswers[0].responseFT) || CurrentQuestion.SelectedAnswers[0].responseFT == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    //"0.0833333"
                    double maxrange = Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseFT) + (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].AnswerIsNullOrEmpty(CurrentQuestion.SelectedAnswers[0].responseINCH)) * 0.0833333F);
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("feet")).SingleOrDefault();
                    if (maxrange < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (maxrange > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }

            }
            #endregion
            #region WeightValidation
            if (CurrentQuestion.key_string.Equals("weight"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "kg")
                {
                    if (string.IsNullOrEmpty(CurrentQuestion.SelectedAnswers[0].responseKG) || CurrentQuestion.SelectedAnswers[0].responseKG == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("kg")).SingleOrDefault();
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseKG) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseKG) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                    if (UserDetails.answers != null && UserDetails.answers.Any())
                    {
                        var ans = UserDetails.answers.FirstOrDefault(a => a.question == "537f57042140f60800de43c9");
                        double resp = 0;
                        if (ans != null && double.TryParse(ans.response.ToString(), out resp) && Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseKG) > resp)
                        {
                            CurrentQuestion.ErrorMessage = "Target weight can't be more than current weight.";
                            return false;
                        }
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "st")
                {
                    if (string.IsNullOrEmpty(CurrentQuestion.SelectedAnswers[0].responseST) || CurrentQuestion.SelectedAnswers[0].responseST == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("st")).SingleOrDefault();

                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseST) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseST) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                    if (UserDetails.answers != null)
                    {
                        var ans = UserDetails.answers.FirstOrDefault(a => a.question == "537f57042140f60800de43c9");
                        double resp = 0;
                        if (ans != null && double.TryParse(ans.response.ToString(), out resp) && Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseKG) > resp)
                        {
                            CurrentQuestion.ErrorMessage = "Target weight can't be more than current weight.";
                            return false;
                        }
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "lb")
                {
                    if (string.IsNullOrEmpty(CurrentQuestion.SelectedAnswers[0].responseLB) || CurrentQuestion.SelectedAnswers[0].responseLB == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("lb")).SingleOrDefault();

                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseLB) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseLB) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                    if (UserDetails.answers != null)
                    {
                        var ans = UserDetails.answers.FirstOrDefault(a => a.question == "537f57042140f60800de43c9");
                        double resp = 0;
                        if (ans != null && double.TryParse(ans.response.ToString(), out resp) && Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseKG) > resp)
                        {
                            CurrentQuestion.ErrorMessage = "Target weight can't be more than current weight.";
                            return false;
                        }
                    }
                }
            }
            #endregion
            #region WaistGirthValidation
            if (CurrentQuestion.key_string.Equals("waist_girth"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseWaistGirthCM) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseWaistGirthCM) == "0")
                {
                    CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                    return false;
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "cm")
                {
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("cm")).SingleOrDefault();
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseWaistGirthCM) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseWaistGirthCM) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "inches")
                {
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("inches")).SingleOrDefault();

                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseWaistGirthINCH) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseWaistGirthINCH) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }

            }
            #endregion
            #region Blood Glucose
            if (CurrentQuestion.key_string.Equals("blood_glucose_level"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mmol")
                {
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemmol_l) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemmol_l) == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }

                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmol")).SingleOrDefault();
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_l) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_l) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mg")
                {
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_dl) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_dl) == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }

                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mg")).SingleOrDefault();

                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dl) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dl) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "g")
                {
                    if (String.IsNullOrEmpty(Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_g_l)) || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_g_l) == "0")
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    var Range = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("g")).SingleOrDefault();

                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_l) < Range.min)
                    {
                        CurrentQuestion.ErrorMessage = "Minimum value should be " + Convert.ToString(Range.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_l) > Range.max)
                    {
                        CurrentQuestion.ErrorMessage = "Maximum value should be " + Convert.ToString(Range.max);
                        return false;
                    }
                }

            }

            #endregion
            #region BP Validation
            if (CurrentQuestion.key_string.Equals("blood_pressure"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mmhg")
                {
                    var RangeSystolic = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmhg")).Where(x => x.special.Equals("systolic")).SingleOrDefault();
                    var RangeDiastolic = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmhg")).Where(x => x.special.Equals("diastolic")).SingleOrDefault();
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG) == string.Empty)
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG) < RangeSystolic.min)
                    {
                        CurrentQuestion.ErrorMessage = "Systolic minimum value should be " + Convert.ToString(RangeSystolic.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG) < RangeDiastolic.min)
                    {
                        CurrentQuestion.ErrorMessage = "Diastolic minimum value should be " + Convert.ToString(RangeDiastolic.min);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG) > RangeSystolic.max)
                    {
                        CurrentQuestion.ErrorMessage = "Systolic maximum value should be " + Convert.ToString(RangeSystolic.max);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG) > RangeDiastolic.max)
                    {
                        CurrentQuestion.ErrorMessage = "Diastolic maximum value should be " + Convert.ToString(RangeDiastolic.max);
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mmhg10")
                {
                    var RangeSystolic = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmhg")).Where(x => x.special.Equals("systolic")).SingleOrDefault();
                    var RangeDiastolic = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmhg")).Where(x => x.special.Equals("diastolic")).SingleOrDefault();
                    double sysMin = RangeSystolic.min / 10;
                    double sysmax = RangeSystolic.max / 10;

                    double diMin = RangeDiastolic.min / 10;
                    double dimax = RangeDiastolic.max / 10;
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG10) == string.Empty)
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG10) < sysMin)
                    {
                        CurrentQuestion.ErrorMessage = "Systolic minimum value should be " + Convert.ToString(sysMin);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG10) < diMin)
                    {
                        CurrentQuestion.ErrorMessage = "Diastolic minimum value should be " + Convert.ToString(diMin);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG10) > sysmax)
                    {
                        CurrentQuestion.ErrorMessage = "Systolic maximum value should be " + Convert.ToString(sysmax);
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG10) > dimax)
                    {
                        CurrentQuestion.ErrorMessage = "Diastolic maximum value should be " + Convert.ToString(dimax);
                        return false;
                    }
                }
            }
            #endregion
            #region CholesterolLevel Validation
            if (CurrentQuestion.key_string.Equals("cholesterol"))
            {
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mmol")
                {
                    var tcl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmol")).Where(x => x.special.Equals("tcl")).SingleOrDefault();
                    var hdl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mmol")).Where(x => x.special.Equals("hdl")).SingleOrDefault();

                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemmol_lTotalCholesterol) == string.Empty)
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_lTotalCholesterol) < tcl.min)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol minimum value should be " + tcl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_lTotalCholesterol) > tcl.max)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol maximum value should be " + tcl.max.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL = CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL) < hdl.min)
                    {
                        CurrentQuestion.ErrorMessage = "HDL minimum value should be " + hdl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL = CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemmol_lHDL) > hdl.max)
                    {
                        CurrentQuestion.ErrorMessage = "HDL maximum value should be " + hdl.max.ToString();
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "mg")
                {
                    var tcl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mg")).Where(x => x.special.Equals("tcl")).SingleOrDefault();
                    var hdl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("mg")).Where(x => x.special.Equals("hdl")).SingleOrDefault();

                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_dlTotalCholesterol) == string.Empty)
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dlTotalCholesterol) < tcl.min)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol minimum value should be " + tcl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dlTotalCholesterol) > tcl.max)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol maximum value should be " + tcl.max.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL = CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL) < hdl.min)
                    {
                        CurrentQuestion.ErrorMessage = "HDL minimum value should be " + hdl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL = CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemg_dlHDL) > hdl.max)
                    {
                        CurrentQuestion.ErrorMessage = "HDL maximum value should be " + hdl.max.ToString();
                        return false;
                    }
                }
                if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "g")
                {
                    var tcl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("g")).Where(x => x.special.Equals("tcl")).SingleOrDefault();
                    var hdl = (Range)CurrentQuestion.ranges.Where(x => x.unit.Equals("g")).Where(x => x.special.Equals("hdl")).SingleOrDefault();

                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responsemg_g_lTotalCholesterol) == string.Empty)
                    {
                        CurrentQuestion.ErrorMessage = AppMessages.please_enter_value;
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_lTotalCholesterol) < tcl.min)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol minimum value should be " + tcl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_lTotalCholesterol) > tcl.max)
                    {
                        CurrentQuestion.ErrorMessage = "Total cholesterol maximum value should be " + tcl.max.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL = CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL) < hdl.min)
                    {
                        CurrentQuestion.ErrorMessage = "HDL minimum value should be " + hdl.min.ToString();
                        return false;
                    }
                    if (Convert.ToDouble(CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL = CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL == "" ? "0" : CurrentQuestion.SelectedAnswers[0].responsemg_g_lHDL) > hdl.max)
                    {
                        CurrentQuestion.ErrorMessage = "HDL maximum value should be " + hdl.max.ToString();
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }
    }
}
