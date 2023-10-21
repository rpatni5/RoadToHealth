using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class Language
    {
        public string code { get; set; }
        public string name { get; set; }
        public int flag { get; set; }
    }

    public class Languages
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Language> Data { get; set; }
    }
}
