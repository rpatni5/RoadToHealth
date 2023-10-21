using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{

    public class AllAlgorithmValue
    {
        public string _id { get; set; }
        public string risk_factor { get; set; }
        public string risk_sub_factor { get; set; }
        public string questionnaire { get; set; }
        public string key_string { get; set; }
        public string units { get; set; }
        public object value { get; set; }
        public object response { get; set; }
        public object response1 { get; set; }
        public object response2 { get; set; }
    }

    public class AllAlgorithmValue2
    {
        public string _id { get; set; }
        public string risk_factor { get; set; }
        public string risk_sub_factor { get; set; }
        public string questionnaire { get; set; }
        public string key_string { get; set; }
        public string units { get; set; }
        public double value { get; set; }
        public object response { get; set; }
        public int? response1 { get; set; }
        public string response2 { get; set; }
    }



    public class QuestionnairesResponseData
    {
        public List<string> reportValid { get; set; }
        public double q_score { get; set; }
        public double optimum_q_score { get; set; }
        public List<AllAlgorithmValue> all_algorithm_values { get; set; }
        public List<ScoreHistory> score_history { get; set; }
        public List<string> answered_questionnaire_ids { get; set; }
        public List<AnsweredQuestionnaireIdsArr> answered_questionnaire_ids_arr { get; set; }
        public int age { get; set; }
        public string DOB { get; set; }
        public int gender { get; set; }
        public string ethnicity_real { get; set; }
        public double averageQ { get; set; }
        public List<Answer> answers { get; set; }
        public List<List<string>> reportCalc { get; set; }
    }

    public class QuestionnairesResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public QuestionnairesResponseData data { get; set; }
        public bool bad_structure { get; set; }
        public bool missing_data { get; set; }
    }

}
