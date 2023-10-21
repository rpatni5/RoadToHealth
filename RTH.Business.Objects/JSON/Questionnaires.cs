﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class Questionnaires
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<DiseaseInfo> data { get; set; }
    }

    public class DiseaseInfo
    {
        public string _id { get; set; }
        public string image_name { get; set; }
        public string image_logo_color { get; set; }
        public string image_logo_grey { get; set; }
        public string key_string { get; set; }
        public string title { get; set; }
        public string summary { get; set; }
        public string background_colour { get; set; }
        public int sort_order { get; set; }
        public int type { get; set; }
    }


}
