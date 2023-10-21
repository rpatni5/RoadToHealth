using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class DeactivateAnswer
    {
        public string _id { get; set; }
        public string deactivation_text { get; set; }

        public bool blnIsCustomValue { get; set; }
    }

    public class DeactivateData
    {
        public string _id { get; set; }
        public List<DeactivateAnswer> answers { get; set; }
        public string question { get; set; }
    }

    public class DeactivateAccount
    {
        public int status { get; set; }
        public string message { get; set; }
        public DeactivateData data { get; set; }
    }

}
