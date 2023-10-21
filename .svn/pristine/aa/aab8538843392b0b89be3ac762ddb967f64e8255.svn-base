using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Helpers;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class MWHealthierViewModel : ViewModelBase
    {
        public MWHealthierViewModel()
        {

        }
        public async Task<bool> SendInvitation()
        {
            return await AsyncCall.Invoke(() =>
             {
                 EmailColor = "#FF000000";
                 NameColor = "#FF000000";

                 if (string.IsNullOrEmpty(this.Name))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.please_enter_name;
                     return false;
                 }
                 if (!ExtensionMethod.ValidateName(this.Name))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.please_enter_valid_name;
                     NameColor = "#FFE51400"; return false;
                 }
                 if (string.IsNullOrEmpty(this.Email))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.missing_email;
                     return false;
                 }
                 if (!ExtensionMethod.ValidateEmail(this.Email))
                 {
                     EmailColor = "#FFE51400";
                     this.ErrorMessage = ViewModelBase.AppMessages.invalid_email_entry;
                     return false;
                 }
                 return true;
             });
        }

        public bool HasTwitterCredentials()
        {
            if (Properties.Settings.Default.TwitterToken != string.Empty &&
                Properties.Settings.Default.TwitterTokenSecret != string.Empty &&
                Properties.Settings.Default.TwitterToken2 != string.Empty &&
                Properties.Settings.Default.TwitterTokenSecret2 != string.Empty)

                return true;
            else
                return false;
        }

        public TwitterCredentials GetTwitterCredentials()
        {
            TwitterCredentials twitterCredentials = new TwitterCredentials();

            twitterCredentials.OAuthToken = new TwitterAuthToken()
            {
                Token = Properties.Settings.Default.TwitterToken,
                TokenSecret = Properties.Settings.Default.TwitterTokenSecret
            };
            twitterCredentials.OAuthToken2 = new TwitterAuthToken()
            {
                Token = Properties.Settings.Default.TwitterToken2,
                TokenSecret = Properties.Settings.Default.TwitterTokenSecret2,
                UserId = Properties.Settings.Default.TwitterUserId
            };

            return twitterCredentials;
        }
        #region properties
        public String EmailColor
        {
            get { return GetValue(() => EmailColor); }
            set
            {
                SetValue(() => EmailColor, value);
            }
        }
        public String NameColor
        {
            get { return GetValue(() => NameColor); }
            set
            {
                SetValue(() => NameColor, value);
            }
        }

        public String Name
        {
            get { return GetValue(() => Name); }
            set
            {
                SetValue(() => Name, value);
            }
        }
        public String Email
        {
            get { return GetValue(() => Email); }
            set
            {
                SetValue(() => Email, value);
            }
        }
        #endregion

        public bool PostTweet(string message)
        {
            TwitterCredentials twitterCredentials = GetTwitterCredentials();
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("oauth_consumer_key", twitterCredentials.ConsumerKey);
            parameters.Add("oauth_token", twitterCredentials.OAuthToken2.Token);
            string result = string.Empty;//TwitterService.PostTweet(message, twitterCredentials, parameters);
            if (!string.IsNullOrEmpty(result) && result.ToLower().Contains("forbidden")) return false;
            return true;
        }

        private RelayCommand m_ShareWithTwitterCommand;
        public RelayCommand ShareWithTwitterCommand
        {
            get
            {
                return m_ShareWithTwitterCommand ?? (m_ShareWithTwitterCommand = new RelayCommand(
                    ve => OnTwitterShare(ve), (t) => true));
            }
        }
        private void OnTwitterShare(object ve)
        {
            if (HasTwitterCredentials())
            {
                string contentUrl = "<a href='https://www.quealth.co/healthierworld.html';'>https://www.quealth.co/healthierworld.html';</a>";
                string message = string.Concat("Quealth – Life Changer! I’ve just helped make the world healthier. Find out more…\n", contentUrl);
                bool result = PostTweet(message);
                if (result)
                    RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = "Message Posted Successfully." });
                else
                    RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = "Message not Posted!" });
            }
            else
            {
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.LoadView, Data = "TwitterPost" });
            }
        }
    }
}
