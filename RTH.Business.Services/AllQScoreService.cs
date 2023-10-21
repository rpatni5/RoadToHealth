using RTH.Business.Objects.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class AllQScoreService
    {       
        public static QSummery GetQSummery(string userId, string accessToken)
        {
            return Http.ExecuteGET<QSummery>(string.Format("apis/get_qsummaries/{0}", userId),null, accessToken);
        }

    }
}
