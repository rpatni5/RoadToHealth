﻿using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class ConversationService
    {
        public static Conversation PostRegistrationConversation(string lang,string accessToken)
        {
            var res= Http.ExecuteGET<Response<Conversation>>(string.Format("apis/get_other_questionnaire/pre_amble_2/{0}", lang),null, accessToken);
            return res.data;
        }
        public static Conversation PreRegistrationConversation(string lang = "en")
        {
            var res = Http.ExecuteGET<Response<Conversation>>(string.Format("apis/get_other_questionnaire/pre_amble_1/{0}", lang), null, null);
            return res.data;
        }

        public static string GetDashboardConversation(string userId, string lang)
        {
            var res = Http.ExecuteGET<Response<Conversation>>(string.Format("apis/get_other_questionnaire/pre_amble_3/{0}/{1}", userId, lang), null, null);
            return res.data.questions[0].questions[0].question;
        }
    }
}
