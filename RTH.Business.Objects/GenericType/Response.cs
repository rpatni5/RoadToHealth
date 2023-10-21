using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class Response<T>
    {
        public int status { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}
