using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class PolicyService
    {
        public static PrivatePolicy.Data GetPrivatePolicy(string language)
        {
            return Http.ExecuteGET<PrivatePolicy>(string.Format("apis/get_policy/{0}", language), null).data;
        }

        public static PrivatePolicy.Data GetTermsAndConditions(string language)
        {
            return Http.ExecuteGET<PrivatePolicy>(string.Format("apis/get_terms/{0}", language),null).data;
        }

        public static PrivatePolicy.Data GetAboutUs(string language)
        {
            return Http.ExecuteGET<PrivatePolicy>(string.Format("apis/get_about/{0}", language), null).data;
        }
    }   
}
