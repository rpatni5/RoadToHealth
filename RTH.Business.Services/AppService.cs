using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class AppService
    {
        public static Languages GetLanguage()
        {
            return Http.ExecuteGET<Languages>(APIMethod.GetLanguages, null);
        }

        public static Variables GetVariable(string Language)
        {
            return Http.ExecuteGET<Variables>("apis/get_Variables/" + Language, null);
        }
        public static Countries GetCountry()
        {
            return Http.ExecuteGET<Countries>("apis/countries",null, null);
        }

        public static Response<VersionInfo> GetLatestVersionInfo()
        {
            return Http.ExecuteGET<Response<VersionInfo>>("apis/get_latest_version/3/en", null, null);
        }
    }
}
