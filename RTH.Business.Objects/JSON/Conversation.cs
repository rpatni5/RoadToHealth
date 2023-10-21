﻿using System.Collections.Generic;

namespace RTH.Business.Objects
{

    public class MotivationResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public Conversation data { get; set; }
        public bool bad_structure { get; set; }
        public bool missing_data { get; set; }
    }

    public partial class Answer
    {
        public string answer_label { get; set; }
        public object answer_value { get; set; }
        public string _id { get; set; }
        public string next_steps { get; set; }
    }

    public partial class Question
    {
        public bool sortable { get; set; }
    }

  
    public class Questions
    {
        public Category category { get; set; }
        public List<Question> questions { get; set; }
        //public List<object> subcategories { get; set; }
        public List<Subcategory> subcategories { get; set; }
    }
   
    public class Conversation
    {
        public string _id { get; set; }
        public string background_colour { get; set; }
        public object sponsor { get; set; }
        public string title { get; set; }
        public string strap { get; set; }
        public string summary { get; set; }
        public string helper { get; set; }
        public string updated { get; set; }
        public List<Questions> questions { get; set; }
        public string image_name { get; set; }
        public string image_logo_color { get; set; }
        public string image_logo_grey { get; set; }
        public string key_string { get; set; }
        public int type { get; set; }      
    }
}
