using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects
{
    public class AuthToken : NotifyBase
    {
        public string access_token { get { return GetValue(() => access_token); } set { SetValue(() => access_token, value); } }
        public string refresh_token { get { return GetValue(() => refresh_token); } set { SetValue(() => refresh_token, value); } }
        public int expires_in { get { return GetValue(() => expires_in); } set { SetValue(() => expires_in, value); } }
        public string token_type { get { return GetValue(() => token_type); } set { SetValue(() => token_type, value); } }
    }
}
