using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class ExploreChatHistoryViewModel : ViewModelBase
    {
        public ExploreChatHistoryViewModel()
        {
            SetHeader();
        }

        void SetHeader()
        {
            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = "";
            KeyString = "None";
            FooterVisibility = true;
        }



        public List<Engagement> GetHistoryDesc(string ThreadId)
        {

            return CoachingDashboardService.GetAllConversation(UserDetails._id, clientDate, dateOffset, UserDetails.AuthToken.access_token, "-1", ThreadId);
        }
    }
}
