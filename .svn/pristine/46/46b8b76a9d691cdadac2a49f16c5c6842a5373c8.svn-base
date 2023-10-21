using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class FriendsOfQService
    {     
        public static FriendsOfQ GetFriendsOfQ(string id,string authToken)
        {
            return Http.ExecuteGET<FriendsOfQ>(string.Format("apis/product/friends_of_q/{0}", id), null, authToken);
        }
    }
}
