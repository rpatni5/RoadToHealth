using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
   public class AnswerRequest : NotifyBase
    {
        public object answer { get { return GetValue(() => answer); } set { SetValue(() => answer, value); } }
        public string date { get { return GetValue(() => date); } set { SetValue(() => date, value); } }
        public string key_string { get { return GetValue(() => key_string); } set { SetValue(() => key_string, value); } }
        public int element_type { get { return GetValue(() => element_type); } set { SetValue(() => element_type, value); } }
        public string question { get { return GetValue(() => question); } set { SetValue(() => question, value); } }      
        public object response2 { get { return GetValue(() => response2); } set { SetValue(() => response2, value); } }             
        public object response1 { get { return GetValue(() => response1); } set { SetValue(() => response1, value); } }
        public object response { get { return GetValue(() => response); } set { SetValue(() => response, value); } }



        public bool decimals { get { return GetValue(() => decimals); } set { SetValue(() => decimals, value); } }
        public int decimal_places { get { return GetValue(() => decimal_places); } set { SetValue(() => decimal_places, value); } }
        public bool answer_overrider { get { return GetValue(() => answer_overrider); } set { SetValue(() => answer_overrider, value); } }
        public bool alreadyAnswered { get { return GetValue(() => alreadyAnswered); } set { SetValue(() => alreadyAnswered, value); } }
        public bool selected { get { return GetValue(() => selected); } set { SetValue(() => selected, value); } }
    }
}
