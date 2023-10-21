﻿using RTH.Business.Objects;
using RTH.Business.Services;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTH.Windows.ViewModels
{
    public class QuestionNavigatorViewModel : ViewModelBase
    {
        List<Answer> _allQuestionAnswers = null;
        public QuestionNavigatorViewModel()
        {
            _allQuestionAnswers = UserDetails.answers != null ? UserDetails.answers.Clone() : new List<Answer>();
            SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);
            QuestionnaireCompleted = GlobalData.Default.ClickedHRA.IsCompleted == HRAStatusEnum.NotCompleted ? false : true;
            GlobalData.Default.LastVisitedDiseaseID = QuestionnaireCompleted == true ? GlobalData.Default.ClickedHRA.ID : GlobalData.Default.LastVisitedDiseaseID;
            TickColor = GlobalData.Default.ClickedHRA.BgColor;
            GetQuestionnaire();
            PreviousScoreHistory = UserDetails.answered_questionnaire_ids_arr;
            //Navigation Tracking


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
        
        public double Score
        {
            get { return GetValue(() => Score); }
            set { SetValue(() => Score, value); }
        }
        public bool QuestionnaireCompleted
        {
            get { return GetValue(() => QuestionnaireCompleted); }
            set
            {
                SetValue(() => QuestionnaireCompleted, value);
            }
        }

        private RelayCommand m_ShowQuestionHelperCommand;

        public RelayCommand ShowQuestionHelperCommand
        {
            get
            {
                return m_ShowQuestionHelperCommand ?? (m_ShowQuestionHelperCommand = new RelayCommand(
                    ve => ShowQuestionHelper(ve), (t) => true));
            }
        }

        private void ShowQuestionHelper(object ve)
        {
            var a = ve as Question;
            Summary = string.Format("<img src ='{0}'/>{1}", a.HelperImagePath, a.summary);
            //var template = ContentTemplate.Template;
            //var myControl = (DatePickerControl)template.FindName("DatePickerControl", ContentTemplate);
            //var element = FindElementByName<ContentControl>(ContentQuestionTemplate, "answersControl").ContentTemplate.FindName("DatePickerControl",);

        }

        void SetHeader()
        {
            HeaderVisibility = true;
            KeyString = GlobalData.Default.ClickedHRA.KeyString;
            HeaderState = false;
            HeaderColor = Questionnaire.background_colour;
            HeaderTitle = Questionnaire.title;
        }
        private void GetQuestionnaire()
        {
            //if (UserDetails.score_history != null && UserDetails.score_history.Count > 0)

            Questionnaire = QuestionnaireService.GetQuestionnaire(UserDetails._id, GlobalData.Default.ClickedHRA.ID, UserDetails.AuthToken.access_token);
            SetHeader();

            AllQuestions = Questionnaire.GetQuestions(_allQuestionAnswers);
            SetQuestionPossitions();
            CurrentCategory = Questionnaire.questions.FirstOrDefault().category;
            CurrentSubCategory = Questionnaire.questions.FirstOrDefault().subcategories.FirstOrDefault();
            CurrentQuestion = Questionnaire.questions.FirstOrDefault(q => q.category == CurrentCategory).questions.FirstOrDefault();
            if (CurrentQuestion == null)
            {
                CurrentQuestion = Questionnaire.questions.FirstOrDefault().subcategories.FirstOrDefault(q => q.subcategory == CurrentSubCategory.subcategory).questions.FirstOrDefault();
            }
            CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);
            //CurrentQuestion.Category = CurrentCategory;
            QuestionWithoutDependency = GetQuestionWithoutDependency();
            DependentQuestion = GetDependentHasTable();
            ViewModelBase.ExecuteTrackNavigation("Dashboard", GlobalData.Default.ClickedHRA.KeyString + "-hra-" + CurrentQuestion.key_string, 1);

        }

        private void SetQuestionPossitions()
        {
            foreach (var item in AllQuestions)
            {
                var CategoryCount = (from Q in AllQuestions where Q.Category.name.Equals(item.Category.name) select Q).Count();
                var CurrentQuestionIndex = (from Q in AllQuestions where Q.Category.name.Equals(item.Category.name) select Q).ToList().IndexOf(item);
                item.QuestionPosition = CategoryCount - CurrentQuestionIndex;
                if (item.decimals)
                    item.decimal_places = Convert.ToString(item.decimal_places.Substring(item.decimal_places.IndexOf(".")).Length);
            }
        }

        public Question CurrentQuestion
        {
            get { return GetValue(() => CurrentQuestion); }
            set { SetValue(() => CurrentQuestion, value); }
        }
        public Int32 CurrentCategoryCount
        {
            get { return GetValue(() => CurrentCategoryCount); }
            set { SetValue(() => CurrentCategoryCount, value); }
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

        public Category CurrentCategory
        {
            get { return GetValue(() => CurrentCategory); }
            set { SetValue(() => CurrentCategory, value); }
        }
        public Subcategory CurrentSubCategory
        {
            get { return GetValue(() => CurrentSubCategory); }
            set { SetValue(() => CurrentSubCategory, value); }
        }
        public HRA Questionnaire
        {
            get { return GetValue(() => Questionnaire); }
            set
            {
                SetValue(() => Questionnaire, value);
                HeaderLabel = Questionnaire.title;
            }
        }
        public List<Question> DependentQuestionList
        {
            get { return GetValue(() => DependentQuestionList); }
            set { SetValue(() => DependentQuestionList, value); }
        }
        public ObservableCollection<Question> AllQuestions
        {
            get { return GetValue(() => AllQuestions); }
            set { SetValue(() => AllQuestions, value); }
        }

        public async Task<string> MoveToQuestion(int moveIndex, SecureString securePwd)
        {
            /* 0  for sucess , 1 for Application Error , -1 For service Error */
            SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);
            Summary = null;
            ObservableCollection<Question> questions = AllQuestions;
            CurrentQuestion.ErrorMessage = "";
            if (moveIndex == 1 && !ValidateAnswer()) return HRASubmit.Continue.ToString();

            /*Check for Gender*/
            if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "53876df906836d0800c4aff7")
            {
                ArrayList AlMaleQuestion = GetQuestionWithoutDependency(2);
                QuestionWithoutDependency.RemoveRange(2, QuestionWithoutDependency.Count - 2);
                QuestionWithoutDependency.InsertRange(2, AlMaleQuestion);
                DependentQuestion = GetDependentHasTable(2);

            }
            else if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "53876df906836d0800c4affa")
            {
                ArrayList AlFemaleQuestion = GetQuestionWithoutDependency(1);
                QuestionWithoutDependency.RemoveRange(2, QuestionWithoutDependency.Count - 2);
                QuestionWithoutDependency.InsertRange(2, AlFemaleQuestion);
                DependentQuestion = GetDependentHasTable(1);
            }
            ArrayList SelectedAnswer = new ArrayList();
            foreach (var item in CurrentQuestion.SelectedAnswers)
            {
                SelectedAnswer.Add(Convert.ToString(item.answer));
            }
            //Cheack having dependent Question 
            ArrayList _questionId = CheckForDependentQuestion(CurrentQuestion, SelectedAnswer);
            RemoveQuestion = null;
            List<Question> _GetExistingDependentRecord = CheckForRecursiveDependentQuestion(CurrentQuestion);
            foreach (var item in _GetExistingDependentRecord)
            {
                if (QuestionWithoutDependency.Contains(item))
                    QuestionWithoutDependency.Remove(item);
            }
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


            if (CurrentQuestion == (Question)QuestionWithoutDependency[QuestionWithoutDependency.Count - 1])
            {

                return await SubmitQuestionnaire(securePwd);
            }
            else
            {
                string PreviousQKeyString = CurrentQuestion.key_string;
                CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(CurrentQuestion) + 1];
                CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);
                ViewModelBase.ExecuteTrackNavigation(GlobalData.Default.ClickedHRA.KeyString + "-hra-" + PreviousQKeyString, GlobalData.Default.ClickedHRA.KeyString + "-hra-" + CurrentQuestion.key_string, 0);
                return HRASubmit.Continue.ToString();
            }



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

        private ArrayList CheckForDependentQuestion(Question currentQuestion)
        {
            var query = from Question num in QuestionWithoutDependency
                        where num.dependency.dependency_question == currentQuestion._id
                        select num;

            ArrayList Al = new ArrayList();
            foreach (var item in query)
            {
                Al.Add(item);
            }
            return Al;
        }


        private ArrayList GetAllDependentQuestion(Question currentQuestion)
        {
            var DependentQuestionList = (ArrayList)DependentQuestion[currentQuestion._id];
            var query = from Question num in DependentQuestionList
                        where num.dependency.dependency_answer == currentQuestion.dependency.dependency_answer
                        select num;

            ArrayList Al = new ArrayList();
            foreach (var item in query)
            {
                Al.Add(item);
            }

            return Al;
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

        public void MoveToQuestionPrevious(int v)
        {
            SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);
            Summary = null;
            string CurrentQuestionKeyString = CurrentQuestion.key_string;
            CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(CurrentQuestion) - 1];
            CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);
            ViewModelBase.ExecuteTrackNavigation(GlobalData.Default.ClickedHRA.KeyString + "-hra-" + CurrentQuestionKeyString, GlobalData.Default.ClickedHRA.KeyString + "-hra-" + CurrentQuestion.key_string, 0);
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
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG) == string.Empty)
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
                    if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPSystolicMMHG10) == string.Empty || Convert.ToString(CurrentQuestion.SelectedAnswers[0].responseBPDiastolicMMHG10) == string.Empty)
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

        public async Task<string> SubmitQuestionnaire(SecureString Password)
        {
            var QuestionResponse = await AsyncSubmitQuestionnaire(Password);
            GlobalData.Default.LastVisitedDiseaseID = GlobalData.Default.ClickedHRA.IsCompleted == HRAStatusEnum.NotCompleted ? GlobalData.Default.LastVisitedDiseaseID : Questionnaire._id;
            if (QuestionResponse.status == 0)
            {
                ViewModelBase.ExecuteTrackNavigation(GlobalData.Default.ClickedHRA.KeyString + "-hra", GlobalData.Default.ClickedHRA.KeyString + "-Qsummary", 1);
                return HRASubmit.Completed.ToString();
            }
            else
            {
                ViewModelBase.ExecuteTrackNavigation(GlobalData.Default.ClickedHRA.KeyString + "-hra", "Dashboard", 1);
                return HRASubmit.ServiceError.ToString();
            }
        }

        private async Task<QuestionnairesResponse> AsyncSubmitQuestionnaire(SecureString securePwd)
        {
            return await AsyncCall.Invoke(() =>
             {
                 ObservableCollection<Question> questions = AllQuestions;
                 List<Answer> RemoveAnswer = new List<Answer>();
                 List<Answer> NewAnswer = new List<Answer>();
                 List<AnswerRequest> oAnswerRequest = new List<AnswerRequest>();
                 //54a3ec966e2527647a6fb245

                 foreach (var item in AllQuestions)
                 {
                     List<Answer> ListAnswer = GetQuestionnaireAnswer(item);
                     if (ListAnswer.Count() > 0)
                     {
                         foreach (var SelectedAnswer in ListAnswer)
                         {

                             var Ans = (from q in _allQuestionAnswers where q.question.Equals(SelectedAnswer.question) select q).ToList();
                             RemoveAnswer.InsertRange(RemoveAnswer.Count, Ans);
                         }
                         NewAnswer.InsertRange(NewAnswer.Count(), ListAnswer);
                     }
                 }
                 foreach (var item in RemoveAnswer)
                 {
                     _allQuestionAnswers.Remove(item);
                 }
                 _allQuestionAnswers.InsertRange(_allQuestionAnswers.Count(), NewAnswer);

                 foreach (var item in _allQuestionAnswers)
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

                 QuestionnairesResponse oQuestionnairesResponse = QuestionnaireService.PutQuestionnaire(UserDetails._id, GlobalData.Default.ClickedHRA.ID, UserDetails.AuthToken.access_token, oAnswerRequest);

                 try
                 {
                     LoginData(ViewModelBase.UserDetails.email, securePwd);
                     GlobalData.Default.ClickedHRA.TotalScore = oQuestionnairesResponse.data.q_score.ToString();
                     double cScore;
                     double.TryParse(GlobalData.Default.ClickedHRA.TotalScore, out cScore);
                     Score = cScore;
                     GlobalData.Default.LastVisitedDiseaseID = GlobalData.Default.ClickedHRA.ID;
                 }
                 catch (Exception)
                 {

                     oQuestionnairesResponse.message = "-1";
                 }
                 return oQuestionnairesResponse;
             });
        }

        private List<Answer> GetQuestionnaireAnswer(Question item)
        {
            List<Answer> SelectedAnswer = new List<Answer>();
            var _item = item;
            //if(QuestionWithoutDependency.Contains()
            if ((from Question s in QuestionWithoutDependency where s._id.Equals(item._id) select s).Any())
            {
                var _Answer = (from Question s in QuestionWithoutDependency where s._id.Equals(item._id) select s.SelectedAnswers).FirstOrDefault();
                if (_Answer != null)
                {
                    if (_Answer.Count == 1)
                    {
                        if (item.element_type == 7)
                        {
                            Answer AnsMultiSelect = _Answer[0];
                            AnsMultiSelect.answer = _Answer[0].answer == null ? "none" : _Answer[0].answer;
                            ArrayList MutliSelect = new ArrayList();
                            MutliSelect.Add(_Answer[0].answer);
                            AnsMultiSelect.answer = MutliSelect;
                            SelectedAnswer.Add(AnsMultiSelect);
                        }
                        else
                        {
                            _Answer[0].response = _Answer[0].response == null ? "none" : _Answer[0].response;
                            _Answer[0].response1 = _Answer[0].response1 == null ? "none" : _Answer[0].response1;
                            _Answer[0].response2 = _Answer[0].response2 == null ? "none" : _Answer[0].response2;
                            SelectedAnswer.Add(_Answer[0]);
                        }
                    }
                    else
                    {

                        Answer AnsMultiSelect = _Answer[0];
                        ArrayList MutliSelect = new ArrayList();
                        foreach (var MutliSelectAnswer in _Answer)
                        {
                            if (Convert.ToString(MutliSelectAnswer.answer) != "none")
                            { if (MutliSelectAnswer.answer != null) { MutliSelect.Add(MutliSelectAnswer.answer); } }

                        }
                        AnsMultiSelect.answer = MutliSelect;
                        SelectedAnswer.Add(AnsMultiSelect);
                    }
                }
                return SelectedAnswer;
            }
            else
            {
                item.SelectedAnswers = new ObservableCollection<Answer>();
                Answer a = new Answer();
                a.date = Convert.ToString(DateTime.Now.Ticks);
                a.key_string = item.key_string;
                a.element_type = item.element_type;
                a.question = item._id;
                a.answer = "none";
                a.response = a.response == null ? "none" : a.response;
                a.response1 = a.response1 == null ? "none" : a.response1;
                a.response2 = a.response2 == null ? "none" : a.response2;
                item.SelectedAnswers.Add(a);
                var _UnFilledQuestion = item.SelectedAnswers.FirstOrDefault();
                SelectedAnswer.Add(_UnFilledQuestion);
                return SelectedAnswer;
            }
        }
        private void LoginData(string Email, SecureString Password)
        {
            string strPwd = Password != null && Password.Length > 0 ? Password.Value() : string.Empty;
            if (!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(strPwd) && strPwd != Configurations.DefaultPassword)
            {
                ViewModels.LoginViewModel login = new ViewModels.LoginViewModel();
                ViewModelBase.UserDetails = login.UserLogin(new Business.Objects.User() { email = Email, Securepwd = Password });
            }
            else
            {
                IDictionary<string, string> vmProperties = ViewModelBase.GetViewModelSettings();
                string socialId;
                string socialType = vmProperties["SocialType"];
                if (vmProperties["SocialType"] == GlobalData.TWITTER)
                {
                    socialId = vmProperties["TwitterUserId"];
                }
                else
                {
                    socialId = vmProperties["FacebookUserId"];
                }

                if (!string.IsNullOrEmpty(socialId) && !string.IsNullOrEmpty(socialType))
                    ViewModelBase.UserDetails = new ViewModels.LoginViewModel().ValidateSocialLogin(socialId, socialType);
            }
        }

        public Question QuestionNotHavingAnswer
        {
            get { return GetValue(() => QuestionNotHavingAnswer); }
            set { SetValue(() => QuestionNotHavingAnswer, value); }
        }
        public void LoadCategoryQuestion(string vm, SecureString securePwd)
        {
            QuestionNotHavingAnswer = null;
            if (ValidateAnswer())
            {
                ArrayList CategoryQuestion = new ArrayList();
                var AllCategoryList = (from _Category in AllQuestions select _Category.Category.name).Distinct().ToList();
                Int32 Gender = 1;
                if (AllQuestions.Where(x => x.key_string.Equals("gender")).Where(x => x.SelectedAnswers[0].answer.Equals("53876df906836d0800c4aff7")).Any())
                {
                    Gender = 2;
                }
                ArrayList AlMaleQuestion = GetQuestionWithoutDependency(Gender);
                QuestionWithoutDependency.RemoveRange(2, QuestionWithoutDependency.Count - 2);
                QuestionWithoutDependency.InsertRange(2, AlMaleQuestion);
                DependentQuestion = GetDependentHasTable(Gender);
                if (AllCategoryList.IndexOf((string)vm) != 0)
                {
                    #region Category Except First
                    foreach (var item in AllCategoryList)
                    {
                        if (AllCategoryList.IndexOf(item) < AllCategoryList.IndexOf((string)vm))
                        {
                            var QuestionList = (from _QuestionList in AllQuestions where _QuestionList.Category.name.Equals(item) && _QuestionList.dependency.dependency_question == null && _QuestionList.gender != Gender select _QuestionList);
                            foreach (var questionItem in QuestionList)
                            {

                                Question CategoryQuestionView = new Question();
                                #region Question Without dependency                            
                                CategoryQuestionView = GetCategoryQuestion(questionItem);
                                CategoryQuestion.Add(CategoryQuestionView);
                                ((Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(questionItem)]).answers = CategoryQuestionView.answers;

                                #endregion
                                #region Question having Dependent
                                ArrayList SelectedAnswer = new ArrayList();

                                /*Check if question having not answered*/
                                if (QuestionHasNoAnswer(CategoryQuestionView))
                                {
                                    if (QuestionNotHavingAnswer == null)
                                        QuestionNotHavingAnswer = CategoryQuestionView;
                                }

                                if (CategoryQuestionView.SelectedAnswers != null)
                                {
                                    foreach (var _SelectedAnswer in CategoryQuestionView.SelectedAnswers)
                                    {
                                        SelectedAnswer.Add(Convert.ToString(_SelectedAnswer.answer));
                                    }
                                }
                                DependentQuestionList = new List<Question>();
                                DependentQuestionList = RecursiveDependentQuestion(questionItem, SelectedAnswer);
                                ArrayList Dependent = new ArrayList();
                                if (DependentQuestionList != null)
                                {
                                    if (DependentQuestionList.Count > 0)
                                    {
                                        for (int i = 0; i < DependentQuestionList.Count; i++)
                                        {
                                            Dependent.Add((Question)DependentQuestionList[i]);
                                            CategoryQuestion.Add((Question)DependentQuestionList[i]);
                                        }
                                        QuestionWithoutDependency.InsertRange(QuestionWithoutDependency.IndexOf(questionItem) + 1, Dependent);
                                    }
                                }
                                #endregion

                            }
                        }

                    }
                    /*Normal Work Flow */
                    if (QuestionNotHavingAnswer != null)
                    {
                        CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(QuestionNotHavingAnswer) - 1];
                    }
                    else {
                        CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(((Question)CategoryQuestion[CategoryQuestion.Count - 1]))];
                    }

                    CategoryMove(1);
                    #endregion
                }
                else
                {
                    CurrentQuestion = (Question)QuestionWithoutDependency[0];
                }
            }
            /*if answer having null */
        }

        private bool QuestionHasNoAnswer(Question categoryQuestionView)
        {
            if (categoryQuestionView.key_string.Equals("cigarettes_count") ||
            categoryQuestionView.key_string.Equals("mod_literal") ||
            categoryQuestionView.key_string.Equals("vig_literal") ||
            categoryQuestionView.key_string.Equals("alcopop_m") ||
            categoryQuestionView.key_string.Equals("fortified_m") ||
            categoryQuestionView.key_string.Equals("liqueur_m") ||
            categoryQuestionView.key_string.Equals("spirit_m") ||
            categoryQuestionView.key_string.Equals("wine_m") ||
            categoryQuestionView.key_string.Equals("beer_m") ||
            categoryQuestionView.key_string.Equals("alcopop_w") ||
            categoryQuestionView.key_string.Equals("fortified_w") ||
            categoryQuestionView.key_string.Equals("liqueur_w") ||
            categoryQuestionView.key_string.Equals("spirit_w") ||
            categoryQuestionView.key_string.Equals("wine_w") ||
            categoryQuestionView.key_string.Equals("beer_w") ||
            categoryQuestionView.key_string.Equals("night_shift_total_years") ||
            categoryQuestionView.key_string.Equals("menarchy_age") ||
            categoryQuestionView.key_string.Equals("given_birth_total") ||
            categoryQuestionView.key_string.Equals("menopause_age"))
            {
                if (categoryQuestionView.SelectedAnswers != null)
                {
                    if (Convert.ToString(categoryQuestionView.SelectedAnswers[0].response) == string.Empty)
                    {
                        return true;
                    }
                }
                else { return true; }
            }
            if (categoryQuestionView.element_type == 0)
            {
                if (categoryQuestionView.SelectedAnswers != null)
                {
                    if (categoryQuestionView.SelectedAnswers[0].answer == null || Convert.ToString(categoryQuestionView.SelectedAnswers[0].answer) == string.Empty)
                    {
                        return true;
                    }
                }
                else
                { return true; }
            }
            if (CurrentQuestion.element_type == 7)
            {
                if (CurrentQuestion.SelectedAnswers != null)
                {
                    if (CurrentQuestion.SelectedAnswers.Count() == 0)
                    { return true; }
                }
                else
                    return true;
            }

            return false;
        }

        private List<Question> RecursiveDependentQuestion(Question currentQuestion, ArrayList selectedAnswer)
        {
            if (DependentQuestion.Contains(currentQuestion._id))
            {
                ArrayList AllDependentQuestion = (ArrayList)DependentQuestion[currentQuestion._id];
                List<Question> Dependent_Question = new List<Business.Objects.Question>();
                for (int i = 0; i < AllDependentQuestion.Count; i++)
                {

                    Dependent_Question.Add((Question)AllDependentQuestion[i]);
                    if (GetDependentQuestionIdHavingAnswer(selectedAnswer, Dependent_Question).Count > 0)
                    {
                        foreach (var item in GetDependentQuestionIdHavingAnswer(selectedAnswer, Dependent_Question))
                        {
                            if (!DependentQuestionList.Contains((Question)item))
                            {
                                var innercurrentAnswer = GetCurrentAnswer((Question)item);
                                if (innercurrentAnswer != null)
                                {
                                    ((Question)item).SelectedAnswers = innercurrentAnswer as ObservableCollection<Answer>;
                                }
                                DependentQuestionList.Add((Question)item);
                            }

                            //selectedAnswer = new ArrayList();
                            if (((Question)item).SelectedAnswers != null)
                            {
                                foreach (var SelectedAnsweritem in ((Question)item).SelectedAnswers)
                                {
                                    selectedAnswer.Add(SelectedAnsweritem.answer);
                                    RecursiveDependentQuestion((Question)AllDependentQuestion[i], selectedAnswer);
                                }
                            }
                            /*Check if question having not answered*/
                            if (QuestionHasNoAnswer((Question)item))
                            {
                                if (QuestionNotHavingAnswer == null)
                                    QuestionNotHavingAnswer = (Question)item;
                            }

                        }
                    }

                }


            }
            return DependentQuestionList;
        }

        private Question GetCategoryQuestion(Question questionItem)
        {
            var currentAnswer = GetCurrentAnswer(questionItem);
            if (currentAnswer == null)
            {
                if (_allQuestionAnswers.Where(a => a.question == questionItem._id).Any())
                {
                    var _UserAnswer = new ObservableCollection<Answer>(_allQuestionAnswers.Where(a => a.question == questionItem._id)).FirstOrDefault();
                    if (_UserAnswer.answer != null)
                    {
                        if (_UserAnswer.answer.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                        {
                            var ArrayAnaswer = (Newtonsoft.Json.Linq.JArray)_UserAnswer.answer;
                            questionItem.SelectedAnswers = new ObservableCollection<Answer>();
                            foreach (var ArrValue in ArrayAnaswer)
                            {
                                Answer a = new Answer();
                                a.date = Convert.ToString(DateTime.Now.Ticks);
                                a.key_string = questionItem.key_string;
                                a.element_type = questionItem.element_type;
                                a.question = questionItem._id;
                                a.answer = ArrValue;
                                questionItem.SelectedAnswers.Add(a);
                            }

                        }
                        else
                        {
                            if ((String)_UserAnswer.answer != "none")
                            {
                                questionItem.SelectedAnswers = new ObservableCollection<Answer>(_allQuestionAnswers.Where(a => a.question == questionItem._id));
                            }
                            else if ((String)_UserAnswer.answer == "none" && questionItem.element_type == 4)
                            {
                                questionItem.SelectedAnswers = new ObservableCollection<Answer>(_allQuestionAnswers.Where(a => a.question == questionItem._id));
                                questionItem.SelectedAnswers[0].response = Convert.ToString(questionItem.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(questionItem.SelectedAnswers[0].response);
                            }
                        }
                    }
                    else { questionItem.answers = null; }
                }
            }
            else
            {
                questionItem.SelectedAnswers = currentAnswer as ObservableCollection<Answer>;
            }

            return questionItem;
        }

        private ObservableCollection<Answer> GetCurrentAnswer(Question questionItem)
        {
            var currentAnswer = (from Question q in QuestionWithoutDependency where q._id == questionItem._id select q).FirstOrDefault();
            if (currentAnswer != null)
                return ((Question)currentAnswer).SelectedAnswers;
            else
                return null;
        }

        private void CategoryMove(int moveIndex)
        {
            ///*Check for Gender*/
            //if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "53876df906836d0800c4aff7")
            //{
            //    ArrayList AlMaleQuestion = GetQuestionWithoutDependency(2);
            //    QuestionWithoutDependency.RemoveRange(2, QuestionWithoutDependency.Count - 2);
            //    QuestionWithoutDependency.InsertRange(2, AlMaleQuestion);
            //    DependentQuestion = GetDependentHasTable(2);

            //}
            //else if (Convert.ToString(CurrentQuestion.SelectedAnswers[0].answer) == "53876df906836d0800c4affa")
            //{
            //    ArrayList AlFemaleQuestion = GetQuestionWithoutDependency(1);
            //    QuestionWithoutDependency.RemoveRange(2, QuestionWithoutDependency.Count - 2);
            //    QuestionWithoutDependency.InsertRange(2, AlFemaleQuestion);
            //    DependentQuestion = GetDependentHasTable(1);
            //}
            //ArrayList SelectedAnswer = new ArrayList();
            //foreach (var item in CurrentQuestion.SelectedAnswers)
            //{
            //    SelectedAnswer.Add(Convert.ToString(item.answer));
            //}
            ////Cheack having dependent Question 
            //ArrayList _questionId = CheckForDependentQuestion(CurrentQuestion, SelectedAnswer);
            //if (_questionId != null && _questionId.Count > 0)
            //{
            //    ArrayList GetExistingDependentRecord = CheckForDependentQuestion(CurrentQuestion);
            //    foreach (var item in GetExistingDependentRecord)
            //    {
            //        QuestionWithoutDependency.Remove(item);
            //    }
            //    for (int i = 0; i < _questionId.Count; i++)
            //    {
            //        if (i > 0)
            //        {
            //            if (QuestionWithoutDependency.Contains((Question)_questionId[i - 1]))
            //            {
            //                QuestionWithoutDependency.Insert(QuestionWithoutDependency.IndexOf((Question)_questionId[i - 1]) + 1, _questionId[i]);
            //            }
            //        }
            //        else
            //        {
            //            QuestionWithoutDependency.Insert(QuestionWithoutDependency.IndexOf(CurrentQuestion) + 1, (Question)_questionId[i]);
            //        }

            //    }
            //}
            //else {
            //    ArrayList GetExistingDependentRecord = CheckForDependentQuestion(CurrentQuestion);
            //    foreach (var item in GetExistingDependentRecord)
            //    {
            //        QuestionWithoutDependency.Remove(item);
            //    }
            //}

            CurrentQuestion = (Question)QuestionWithoutDependency[QuestionWithoutDependency.IndexOf(CurrentQuestion) + 1];
            CurrentQuestion.HelperImagePath = string.Concat(Configurations.ImagePath, CurrentQuestion.helper_image);


        }

        public bool IsFirstHra()
        {
            int countNow = (Int32)UserDetails.answered_questionnaire_ids_arr?.Count(x => x.success == true);
            int? countPrevious = PreviousScoreHistory?.Count(x => x.success == true);
            if (countNow == 1 && (countPrevious == null || countNow > countPrevious))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<AnsweredQuestionnaireIdsArr> PreviousScoreHistory { get; set; }
    }
}