using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class DevicesServicesViewModel : SocialViewModelBase
    {
        public DevicesServicesViewModel()
        {
            Refresh();
            FooterVisibility = true;

        }

        public override void Refresh()
        {
            if (UserDetails.sociallogins != null && UserDetails.sociallogins.Any())
            {
                foreach (SocialLogin sl in UserDetails.sociallogins)
                {
                    if (sl.socialmedia_type.ToLower() == GlobalData.FACEBOOOK) IsFacebookConnected = true;
                    if (sl.socialmedia_type.ToLower() == GlobalData.TWITTER) IsTwitterConnected = true;
                }
            }
        }

        public bool IsFacebookConnected
        {
            get { return GetValue(() => IsFacebookConnected); }
            set
            {
                SetValue(() => IsFacebookConnected, value);
            }
        }
        public bool IsTwitterConnected
        {
            get { return GetValue(() => IsTwitterConnected); }
            set
            {
                SetValue(() => IsTwitterConnected, value);
            }
        }


        RelayCommand _connectToFacebookCommand;
        RelayCommand _connectToTwitterCommand;


        public RelayCommand ConnectToFacebookCommand
        {
            get
            {
                return _connectToFacebookCommand ?? (_connectToFacebookCommand = new RelayCommand(
                    cp =>
                    {
                        if (!IsFacebookConnected)
                        {
                            if (Properties.Settings.Default.SocialType == GlobalData.FACEBOOOK)
                            {
                                Connect(Properties.Settings.Default.FacebookUserId,GlobalData.FACEBOOOK);
                            }
                            else
                            {
                                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.ConnectToFacebook });
                            }
                        }
                        else
                        {

                        }
                    },
                    b => { return true; }));
            }
        }

        public RelayCommand ConnectToTwitterCommand
        {
            get
            {
                return _connectToTwitterCommand ?? (_connectToTwitterCommand = new RelayCommand(
                    cp =>
                    {
                        if (!IsTwitterConnected)
                        {
                            RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.LoadView, Data = "TwitterConnect" });
                        }
                        else
                        {
                            IsTwitterConnected = false;
                            //Nothing is to be done for now
                        }
                    },
                    b => { return true; }));
            }
        }

        private void DisconnectSocialMedia(string type)
        {
            UserDetails.socialmedia_id = string.Empty;
            UserDetails.type = string.Empty;

            User user = UserService.UpdateUserProfile(UserDetails, UserDetails.AuthToken.access_token);
            if (string.IsNullOrEmpty(user.message) && type == GlobalData.TWITTER)
            {
                ClearTwitterSettings();
                IsTwitterConnected = false;
            }
        }
    }
}
