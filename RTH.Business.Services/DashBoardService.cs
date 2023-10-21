using RTH.Business.Objects;
using RTH.Business.Objects.Custom;
using RTH.Business.Objects.JSON;
using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class DashboardService
    {
        public static UserTimeline GetTimelines(string userId, string clientOffset, string clientDate, string pushType,string accessToken)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("user_id", userId);
            nvc.Add("client_offset", clientOffset);
            nvc.Add("client_date", clientDate);
            nvc.Add("push_type", pushType);
            return Http.ExecuteGET<UserTimeline>(APIMethod.GetUserTimelines, nvc, accessToken);
        }
        public static Questionnaires GetQuestionaires(string clientId, string language)
        {                    
            return Http.ExecuteGET<Questionnaires>(string.Format("apis/get_client_questionnaires_html/{0}/{1}/all", clientId, language), null);
        }        
        public static Coaches GetCoaches()
        {
            return Http.ExecuteGET<Coaches>("apis/coaches/get_coaches",null,null);
        }
        public static Coaches SaveCoach(string UserId , string coachid,string AccessToken)
        {
            PostCoach oPostCoach = new PostCoach();
            oPostCoach.coach = coachid;
            return Http.ExecuteJSONPOST<Coaches>(String.Concat("apis/users/save_coach/", UserId), oPostCoach, AccessToken);
        }
        public static async Task<object> ReportEmail(string userId)
        {
            return await RTH.Business.Services.Http.GetAsync(String.Concat(Config.ApiUrl , "apis/downloadHealthReport/", userId));
        }
    }
}
