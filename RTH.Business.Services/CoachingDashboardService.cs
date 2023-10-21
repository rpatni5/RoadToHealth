﻿using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public class CoachingDashboardService
    {
        public static List<Engagement> GetAllConversation(string userId, string clientDate, string clientOffset, string accessToken, string listType = "0", string threadId = "")
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("user_id", userId);
            nvc.Add("client_offset", clientOffset);
            nvc.Add("client_date", clientDate);
            nvc.Add("push_type", "1");
            nvc.Add("list_type", listType);
            nvc.Add("thread_id", threadId);
            return Http.ExecuteGET<UserTimeline>("apis/get_user_engagements/", nvc, accessToken).engagements;
            //var res = Http.ExecuteGET<Response<List<Engagement>>>(string.Format("apis/get_user_engagements?push_type=1&list_type=0&user_id={0}&thread_id=&client_date={1}&client_offset={2}", userId, clientDate, clientOffset), null, accessToken);
            //return res.data;
        }

        public static ConversationThread GetSpecificActivity(string userId, string activityId, string clientDate, string clientOffset, string accessToken)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("user_id", userId);
            nvc.Add("activity_id", activityId);
            nvc.Add("client_offset", clientOffset);
            nvc.Add("client_date", clientDate);

            return Http.ExecuteGET<Response<ConversationThread>>("apis/get_user_engagement/", nvc, accessToken).data;

        }

        public static CoachingConversationResponse SetSpecificActivity(string userId, string activityId, string optionId, string additionalInfo, string clientDate, string clientOffset, string accessToken)
        {
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("user_id", userId);
            nvc.Add("activity_id", activityId);
            nvc.Add("option_id", optionId);
            nvc.Add("additional_info", additionalInfo);
            nvc.Add("client_offset", clientOffset);
            nvc.Add("client_date", clientDate);

            return Http.ExecuteGET<CoachingConversationResponse>("apis/set_user_engagement/", nvc, accessToken);
        }


    }
}
