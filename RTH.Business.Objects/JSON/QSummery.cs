using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public class QSummery
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Datum> data { get; set; }
        public class Datum
        {
            public string _id { get; set; }
            public int sequence { get; set; }
            public string rule { get; set; }
            public string age { get; set; }
            public string content { get; set; }
        }       
       
    }
}
