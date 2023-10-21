﻿using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class HealthPlanQuestionnaire : NotifyBase
    {
        public Category category { get; set; }
        public List<Question> questions { get; set; }
        public List<HealthQuestionnaireSubcategory> subcategories { get; set; }
    }
    public class HealthQuestionnaireSubcategory : NotifyBase
    {
        public Category subcategory { get; set; }
        public List<Question> questions { get; set; }
    }
    public class Questionnaire : NotifyBase
    {
        public string _id { get; set; }
        public string image_name
        {
            get { return GetValue(() => image_name); }
            set { SetValue(() => image_name, value); }
        }
    }
    public class HealthPlanQuestionnaireData : NotifyBase
    {
        public string _id { get; set; }
        public string key_string { get; set; }
        public Category category { get; set; }
        public string objective_title { get; set; }
        public string objective_prompt { get; set; }
        public string updated { get; set; }
        public ObservableCollection<HealthPlanQuestionnaire> questions { get; set; }
        public string image_name { get; set; }
        public ObservableCollection<Strategy> strategies { get; set; }
        public ObservableCollection<Questionnaire> questionnaires { get; set; }
    }
    public class HealthQuestionnaire : NotifyBase
    {
        public int status { get; set; }
        public string message { get; set; }
        public HealthPlanQuestionnaireData data { get; set; }
    }
    [Serializable]
    public class HealthQuestionnaireRequest
    {
        public string key_string { get; set; }
        public string objective_id { get; set; }
        public List<AnswerRequest> question { get; set; }
        public ObservableCollection<Strategy> strategy { get; set; }
        public string user_id { get; set; }
    }

}
