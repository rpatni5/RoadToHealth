using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Helpers.Exceptions
{
    public class CachedObjectNotFoundException : Exception
    {
        public CachedObjectNotFoundException(string message) : base(message)
        {
        }
    }
}
