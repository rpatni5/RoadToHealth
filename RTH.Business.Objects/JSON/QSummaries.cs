using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTH.Helpers;

namespace RTH.Business.Objects
{
  public class QSummaries : NotifyBase
    {
        public string _id { get; set; }
        public string questionnaire { get; set; }
        public int sequence { get; set; }
        public string rule { get; set; }
        public string content { get; set; }
    }
}
