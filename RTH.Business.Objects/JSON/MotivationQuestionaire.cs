﻿using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public class MotivationQuestionaire : NotifyBase
    {

        public string element_type
        {
            get { return GetValue(() => this.element_type); }
            set { SetValue(() => element_type, value); }
        }
        public string question
        {
            get { return GetValue(() => this.question); }
            set { SetValue(() => question, value); }
        }
        public string key_string
        {
            get { return GetValue(() => this.key_string); }
            set { SetValue(() => key_string, value); }
        }
        public object answer
        {
            get { return GetValue(() => this.answer); }
            set { SetValue(() => answer, value); }
        }
        public string question_title
        {
            get { return GetValue(() => this.question_title); }
            set { SetValue(() => question_title, value); }
        }
        public object response
        {
            get { return GetValue(() => this.response); }
            set { SetValue(() => response, value); }
        }
        public string response1
        {
            get { return GetValue(() => this.response1); }
            set { SetValue(() => response1, value); }
        }
        public string response2
        {
            get { return GetValue(() => this.response2); }
            set { SetValue(() => response2, value); }
        }

        //public Answer[] answers { get; set; }
        //public object answer { get; set; }
    }
    public class MotivationQuestionaireResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<MotivationQuestionaire> data { get; set; }
    }
    //public class Answer
    //{
    //    public string _id { get; set; }
    //    public string answer { get; set; }
    //    public string next_steps { get; set; }
    //}

}
