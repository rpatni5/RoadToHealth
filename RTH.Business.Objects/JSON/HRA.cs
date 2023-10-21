﻿using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Linq;

namespace RTH.Business.Objects
{
    public class Category : NotifyBase
    {
        public string name
        {
            get { return GetValue(() => name); }
            set { SetValue(() => name, value); }
        }
        public string icon
        {
            get { return GetValue(() => icon); }
            set { SetValue(() => icon, value); }
        }
        public string color
        {
            get { return GetValue(() => color); }
            set { SetValue(() => color, value); }
        }
        public string question_color
        {
            get { return GetValue(() => question_color); }
            set { SetValue(() => question_color, value); }
        }

    }
    public class Subcategory : NotifyBase
    {
        public Category subcategory { get { return GetValue(() => subcategory); } set { SetValue(() => subcategory, value); } }
        public ObservableCollection<Question> questions { get { return GetValue(() => questions); } set { SetValue(() => questions, value); } }
    }
    public class Dependency : NotifyBase
    {
        public ObservableCollection<object> dependency_answer { get { return GetValue(() => dependency_answer); } set { SetValue(() => dependency_answer, value); } }
        public string dependency_question { get { return GetValue(() => dependency_question); } set { SetValue(() => dependency_question, value); } }
    }
    public class Range : NotifyBase
    {
        public string _id { get { return GetValue(() => _id); } set { SetValue(() => _id, value); } }
        public double max { get { return GetValue(() => max); } set { SetValue(() => max, value); } }
        public double min { get { return GetValue(() => min); } set { SetValue(() => min, value); } }
        public DateTime MaxDate { get { return GetValue(() => MaxDate); } set { SetValue(() => MaxDate, value); } }
        public DateTime MinDate { get { return GetValue(() => MinDate); } set { SetValue(() => MinDate, value); } }
        public string unit { get { return GetValue(() => unit); } set { SetValue(() => unit, value); } }
        public string special { get { return GetValue(() => special); } set { SetValue(() => special, value); } }
    }
    public partial class Question : NotifyBase
    {
        public string _id
        {
            get { return GetValue(() => _id); }
            set { SetValue(() => _id, value); }
        }

        public bool HasErrors
        {
            get { return GetValue(() => HasErrors); }
            set { SetValue(() => HasErrors, value); }
        }
        public string ErrorMessage
        {
            get { return GetValue(() => ErrorMessage); }
            set { SetValue(() => ErrorMessage, value); }
        }
        public string question
        {
            get { return GetValue(() => question); }
            set { SetValue(() => question, value); }
        }
        public string question_alias
        {
            get { return GetValue(() => question_alias); }
            set { SetValue(() => question_alias, value); }
        }
        public Category Category
        {
            get { return GetValue(() => Category); }
            set { SetValue(() => Category, value); }
        }
        public Category SubCategory
        {
            get { return GetValue(() => SubCategory); }
            set { SetValue(() => SubCategory, value); }
        }
        public Dependency dependency
        {
            get { return GetValue(() => dependency); }
            set { SetValue(() => dependency, value); }
        }
        public int element_type
        {
            get { return GetValue(() => element_type); }
            set { SetValue(() => element_type, value); }
        }
        public bool decimals
        {
            get { return GetValue(() => decimals); }
            set { SetValue(() => decimals, value); }
        }
        public string decimal_places
        {
            get { return GetValue(() => decimal_places); }
            set { SetValue(() => decimal_places, value); }
        }
        public ObservableCollection<Range> ranges
        {
            get { return GetValue(() => ranges); }
            set { SetValue(() => ranges, value); }
        }
        public string SummaryToDisplay
        {
            get
            {
                string s = string.Format("<div class='helpText'><strong>{0}</strong></div>", helper_title);

                if (helper_image != string.Empty)
                {
                    string path = Uri.EscapeUriString(Config.ApiUrl + @"uploads/questions_helper/" + helper_image);
                    s = string.Format("{0}<div class='helpText'><img height='150' width='360' src ='{1}'/></div>", s, path);
                }
                s = string.Format("{0}<div class='helpText'>{1}</div>", s, summary);
                return s;
            }
        }
        public string summary
        {
            get { return GetValue(() => summary); }
            set
            {
                SetValue(() => summary, value);
                NotifyPropertyChanged("SummaryToDisplay");
            }
        }
        public string helper_title
        {
            get { return GetValue(() => helper_title); }
            set { SetValue(() => helper_title, value); }
        }
        public string HelperImagePath
        {
            get { return GetValue(() => HelperImagePath); }
            set { SetValue(() => HelperImagePath, value); }
        }
        public string helper_image
        {
            get { return GetValue(() => helper_image); }
            set { SetValue(() => helper_image, value); }
        }
        public int gender
        {
            get { return GetValue(() => gender); }
            set { SetValue(() => gender, value); }
        }
        public string key_string
        {
            get { return GetValue(() => key_string); }
            set { SetValue(() => key_string, value); }
        }
        public object AppendText
        {
            get
            {
                switch (key_string)
                {
                    case "cigarettes_count":
                        return "Cigarettes";
                    default:
                        return null;
                }
            }
            set
            {
                NotifyPropertyChanged("AppendText");
            }
        }
        public ObservableCollection<Option> answers
        {
            get { return GetValue(() => answers); }
            set { SetValue(() => answers, value); }
        }
        public ObservableCollection<Answer> SelectedAnswers { get { return GetValue(() => SelectedAnswers); } set { SetValue(() => SelectedAnswers, value); } }
        public int roundVal
        {
            get { return GetValue(() => roundVal); }
            set { SetValue(() => roundVal, value); }
        }
        public bool is_restricted { get { return GetValue(() => is_restricted); } set { SetValue(() => is_restricted, value); } }
        public Int32 QuestionPosition
        {
            get { return GetValue(() => QuestionPosition); }
            set { SetValue(() => QuestionPosition, value); }
        }

        /*health Plan Property*/
        public List<object> limit
        {
            get { return GetValue(() => limit); }
            set { SetValue(() => limit, value); }
        }
        public bool is_skipped_in_health_plan
        {
            get { return GetValue(() => is_skipped_in_health_plan); }
            set { SetValue(() => is_skipped_in_health_plan, value); }
        }


    }
    public class Option : NotifyBase
    {
        public string answer_text { get { return GetValue(() => answer_text); } set { SetValue(() => answer_text, value); } }
        public string answer_label { get { return GetValue(() => answer_label); } set { SetValue(() => answer_label, value); } }
        public object answer_value { get { return GetValue(() => answer_value); } set { SetValue(() => answer_value, value); } }
        public string _id { get { return GetValue(() => _id); } set { SetValue(() => _id, value); } }
        public bool answer_overrider { get { return GetValue(() => answer_overrider); } set { SetValue(() => answer_overrider, value); } }
    }

    public class CategorisedQuestions : NotifyBase
    {
        public Category category { get { return GetValue(() => category); } set { SetValue(() => category, value); } }
        public ObservableCollection<Question> questions { get { return GetValue(() => questions); } set { SetValue(() => questions, value); } }
        public ObservableCollection<Subcategory> subcategories { get { return GetValue(() => subcategories); } set { SetValue(() => subcategories, value); } }
    }
    public class HRA : NotifyBase
    {
        public string _id { get { return GetValue(() => _id); } set { SetValue(() => _id, value); } }
        public string background_colour { get { return GetValue(() => background_colour); } set { SetValue(() => background_colour, value); } }
        public object sponsor { get { return GetValue(() => sponsor); } set { SetValue(() => sponsor, value); } }
        public string title { get { return GetValue(() => title); } set { SetValue(() => title, value); } }
        public string strap { get { return GetValue(() => strap); } set { SetValue(() => strap, value); } }
        public string summary { get { return GetValue(() => summary); } set { SetValue(() => summary, value); } }
        public string helper { get { return GetValue(() => helper); } set { SetValue(() => helper, value); } }
        public string updated { get { return GetValue(() => updated); } set { SetValue(() => updated, value); } }
        public ObservableCollection<CategorisedQuestions> questions { get { return GetValue(() => questions); } set { SetValue(() => questions, value); } }
        public string image_name { get { return GetValue(() => image_name); } set { SetValue(() => image_name, value); } }
        public string image_logo_color { get { return GetValue(() => image_logo_color); } set { SetValue(() => image_logo_color, value); } }
        public string image_logo_grey { get { return GetValue(() => image_logo_grey); } set { SetValue(() => image_logo_grey, value); } }

        public ObservableCollection<Question> GetQuestions(List<Answer> answers)
        {

            if (questions == null || questions.Count == 0) return null;
            ObservableCollection<Question> ques = null;
            foreach (CategorisedQuestions item in questions)
            {
                if (ques == null) ques = new ObservableCollection<Question>();
                foreach (Question q in item.questions)
                {
                    q.Category = item.category;

                    if (answers.Where(a => a.question == q._id).Any())
                    {
                        var _UserAnswer = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id)).FirstOrDefault();

                        if (_UserAnswer.answer != null)
                        {
                            if (_UserAnswer.answer.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                            {
                                var ArrayAnaswer = (Newtonsoft.Json.Linq.JArray)_UserAnswer.answer;


                                if (ArrayAnaswer.Count == 1)
                                {
                                    string answer = GetAnswerFronJArray(ArrayAnaswer);
                                    q.SelectedAnswers = new ObservableCollection<Answer>();
                                    Answer a = new Answer();
                                    a.date = Convert.ToString(DateTime.Now.Ticks);
                                    a.key_string = q.key_string;
                                    a.element_type = q.element_type;
                                    a.question = q._id;
                                    a.answer = answer;
                                    a.answer_overrider = q.answers.Where(x => x._id.Equals(answer)).Select(x => x.answer_overrider).FirstOrDefault();
                                    q.SelectedAnswers.Add(a);

                                }
                                else
                                {
                                    q.SelectedAnswers = new ObservableCollection<Answer>();
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
                                    //string[] items = ArrayAnaswer.Select(jv => (string)jv).ToArray();
                                    //q.SelectedAnswers = new ObservableCollection<Answer>();
                                    //foreach (var answervalue in items)
                                    //{

                                    //}
                                }




                            }
                            else
                            {
                                if ((String)_UserAnswer.answer != "none")
                                {
                                    q.SelectedAnswers = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id));
                                }
                                else if ((String)_UserAnswer.answer == "none" && q.element_type == 4)
                                {
                                    q.SelectedAnswers = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id));
                                    q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(q.SelectedAnswers[0].response);
                                }
                            }
                        }


                    }
                }
                ques.AddRange(item.questions);
                if (item.subcategories != null && item.subcategories.Count > 0)
                {
                    foreach (Subcategory sc in item.subcategories)
                    {
                        foreach (Question q in sc.questions)
                        {

                            q.Category = item.category;
                            q.SubCategory = sc.subcategory;
                            if (answers.Where(a => a.question == q._id).Any())
                            {
                                var _UserAnswer = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id)).FirstOrDefault();

                                if (_UserAnswer.answer != null)
                                {
                                    if (_UserAnswer.answer.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                                    {
                                        var ArrayAnaswer = (Newtonsoft.Json.Linq.JArray)_UserAnswer.answer;
                                        q.SelectedAnswers = new ObservableCollection<Answer>();
                                        if (ArrayAnaswer.Count == 1)
                                        {
                                            string answer = GetAnswerFronJArray(ArrayAnaswer);
                                            Answer a = new Answer();
                                            a.date = Convert.ToString(DateTime.Now.Ticks);
                                            a.key_string = q.key_string;
                                            a.element_type = q.element_type;
                                            a.question = q._id;
                                            a.answer = answer;
                                            a.answer_overrider = q.answers.Where(x => x._id.Equals(answer)).Select(x => x.answer_overrider).FirstOrDefault();
                                            q.SelectedAnswers.Add(a);

                                        }
                                        else
                                        {
                                            q.SelectedAnswers = new ObservableCollection<Answer>();
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
                                            //string[] items = ArrayAnaswer.Select(jv => (string)jv).ToArray();
                                            //foreach (var answervalue in items)
                                            //{
                                            //    q.SelectedAnswers = new ObservableCollection<Answer>();
                                            //    Answer a = new Answer();
                                            //    a.date = Convert.ToString(DateTime.Now.Ticks);
                                            //    a.key_string = q.key_string;
                                            //    a.element_type = q.element_type;
                                            //    a.question = q._id;
                                            //    a.answer = answervalue;
                                            //    a.answer_overrider = q.answers.Where(x => x._id.Equals(answervalue)).Select(x => x.answer_overrider).FirstOrDefault();
                                            //    q.SelectedAnswers.Add(a);
                                            //}
                                        }


                                    }
                                    else
                                    {
                                        if ((String)_UserAnswer.answer != "none")
                                        {
                                            q.SelectedAnswers = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id));
                                        }
                                        else if ((String)_UserAnswer.answer == "none" && q.element_type == 4)
                                        {
                                            q.SelectedAnswers = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id));
                                            q.SelectedAnswers[0].response = Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(q.SelectedAnswers[0].response);
                                        }
                                        else if ((String)_UserAnswer.answer == "none" && q.element_type == 0)
                                        {
                                            q.SelectedAnswers = new ObservableCollection<Answer>(answers.Where(a => a.question == q._id));
                                            q.SelectedAnswers[0].answer = Convert.ToString(q.SelectedAnswers[0].response) == "none" ? "" : Convert.ToString(q.SelectedAnswers[0].response);
                                        }
                                    }

                                }
                            }
                        }
                    }
                    ques.AddRange(item.subcategories.GetCollection<Subcategory, Question>("questions"));
                }
            }
            return ques;
        }

        private string GetAnswerFronJArray(JArray arrayAnaswer)
        {
            return getJArrayValue(arrayAnaswer.First);
        }

        private string getJArrayValue(JToken first)
        {
            if (first.HasValues)
            {
                return getJArrayValue(first.First);
            }
            else
            {

                return Convert.ToString(((Newtonsoft.Json.Linq.JValue)first).Value);
            }

        }

        public ObservableCollection<Subcategory> GetCategories()
        {
            if (questions == null || questions.Count == 0) return null;
            ObservableCollection<Subcategory> categories = null;
            foreach (CategorisedQuestions item in questions)
            {
                if (categories == null) categories = new ObservableCollection<Subcategory>();
                categories.Add(new Subcategory { subcategory = item.category, questions = item.questions });
                if (item.subcategories != null && item.subcategories.Count > 0)
                {
                    categories.AddRange(item.subcategories);
                }
            }
            return categories;
        }
    }

    public static class ObservableCollectionExtension
    {
        public static void AddRange<T>(this ObservableCollection<T> param, ObservableCollection<T> collection)
        {
            foreach (var item in collection)
            {
                param.Add(item);
            }

        }

        public static ObservableCollection<T1> GetCollection<T, T1>(this ObservableCollection<T> param, string collectionName)
        {
            if (param == null && param.Count == 0) return null;
            if (string.IsNullOrEmpty(collectionName)) return null;
            ObservableCollection<T1> obj = new ObservableCollection<T1>();
            foreach (T item in param)
            {
                Type t = item.GetType();

                PropertyInfo prop = t.GetProperty(collectionName);

                obj.AddRange((ObservableCollection<T1>)prop.GetValue(item));
            }
            return obj;
        }
    }

}
