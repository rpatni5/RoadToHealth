using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
   public class HealthAreasService
    {
        public static PHA GetPHA(string userId, string qId, string accessToken)
        {
            return Http.ExecuteGET<PHA>("apis/get_phas/" + userId + "/" + qId, null, accessToken);
        }

        
    }
}
