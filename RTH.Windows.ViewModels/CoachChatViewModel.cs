﻿using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class CoachChatViewModel : ViewModelBase
    {
        public CoachChatViewModel()
        {
            SetHeader();
        }

        void SetHeader()
        {
            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderBlueColor;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = "Quealth Coach";
            KeyString = "None";
            FooterVisibility = true;
        }

        #region CoachConversation

        public ConversationThread GetSpecificActivity(string threadId)
        {
            return CoachingDashboardService.GetSpecificActivity(UserDetails._id, threadId, clientDate, dateOffset, UserDetails.AuthToken.access_token);
            //if (lst.option_list != null && lst.option_list.Count > 0)
            //{
            //    SetSpecificEngagement(lst._id, lst.option_list.FirstOrDefault().option_id, "");
            //}
        }
        public CoachingConversationResponse SetSpecificEngagement(string activityId, string optionId, string additionalInfo)
        {
            string dateOffset = (DateTime.UtcNow - DateTime.Now).TotalMinutes.ToString();
            return CoachingDashboardService.SetSpecificActivity(UserDetails._id, activityId, optionId, additionalInfo, clientDate, dateOffset, UserDetails.AuthToken.access_token);
        }

        #endregion
    }
}