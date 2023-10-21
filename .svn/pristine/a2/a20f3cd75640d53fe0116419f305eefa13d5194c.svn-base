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
    public class ChatHistoryViewModel : ViewModelBase
    {
        public ChatHistoryViewModel()
        {
            SetHeader();
            GetHistoryConversation();
        }
        public List<Engagement> HistoryConversations
        {
            get { return GetValue(() => HistoryConversations); }
            set { SetValue(() => HistoryConversations, value); }
        }

        public override void Refresh()
        {
            GetHistoryConversation();
            base.Refresh();
        }
        void SetHeader()
        {
            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = false;
            HeaderState = false;
            HeaderTitle = "";
            KeyString = "None";
            FooterVisibility = true;
        }

        private void GetHistoryConversation()
        {
            AsyncCall.Invoke(() =>
            {
                HistoryConversations = CoachingDashboardService.GetAllConversation(UserDetails._id, clientDate, dateOffset, UserDetails.AuthToken.access_token, "-1");
            });
        }
    }
}
