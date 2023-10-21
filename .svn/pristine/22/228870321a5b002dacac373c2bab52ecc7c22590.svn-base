using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    //public class HealthAllQuestion
    //{
    //    public string answer { get; set; }
    //    public string answer_text { get; set; }
    //    public string date { get; set; }
    //    public string response { get; set; }
    //    public string question { get; set; }
    //    public string key_string { get; set; }
    //    public int decimal_places { get; set; }
    //    public bool decimals { get; set; }
    //    public int element_type { get; set; }
    //    public bool answer_overrider { get; set; }
    //    public bool alreadyAnswered { get; set; }
    //    public bool selected { get; set; }
    //    public string question_title { get; set; }
    //    public string response2 { get; set; }
    //    public string response1 { get; set; }
    //}

    public class Strategy
    {
        public Guid LocalGuid { get; set; }
        public string strategy_text { get; set; }
        public string strategy_id { get; set; }
        public int strategy_status { get; set; }
        public string _id { get; set; }
    }

    //public class AllAnswer
    //{
    //    public string answer { get; set; }
    //    public string response1 { get; set; }
    //    public string date { get; set; }
    //    public string response { get; set; }
    //    public string question { get; set; }
    //    public string key_string { get; set; }
    //    public int decimal_places { get; set; }
    //    public bool decimals { get; set; }
    //    public int element_type { get; set; }
    //    public bool answer_overrider { get; set; }
    //    public bool alreadyAnswered { get; set; }
    //    public bool selected { get; set; }
    //    public string answer_text { get; set; }
    //    public string response2 { get; set; }
    //}

    public class HealthObjectiveData
    {
        public int __v { get; set; }
        public string _id { get; set; }
        public string created { get; set; }
        public List<Answer> questions { get; set; }
        public string objective_id { get; set; }
        public ObservableCollection<Strategy> strategy { get; set; }
        public List<Answer> all_answers { get; set; }
    }

    public class HealthObjective
    {
        public int status { get; set; }
        public string message { get; set; }
        public HealthObjectiveData data { get; set; }
    }

    public class HealthTarget
    {
        public String TargetText { get; set; }
        public String StrategyText { get; set; }
        public object KeyColor { get; set; }
        public List<Strategy> Strategies { get; set; }
        public List<Answer> Targets { get; set; }
    }
}
