﻿using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Helpers.Exceptions;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTH.Windows.ViewModels
{
    public class TwitterAuthenticationViewModel : SocialViewModelBase
    {
        RelayCommand authenticateCommand;
        IDictionary<string, string> parameters;
        public TwitterCredentials Credentials
        {
            get { return GetValue(() => Credentials); }
            set
            {
                SetValue(() => Credentials, value);
            }
        }
        bool _isPostTweetCalled;
        bool _isConnectCalled;
        public TwitterAuthenticationViewModel()
        {
            Refresh();
        }

        public override void Refresh()
        {
            Credentials = new TwitterCredentials();
            Credentials.OAuthToken = new TwitterAuthToken();
            Credentials.OAuthToken2 = new TwitterAuthToken();

            Credentials.OAuthToken.Token = Properties.Settings.Default.TwitterToken;
            Credentials.OAuthToken.TokenSecret = Properties.Settings.Default.TwitterTokenSecret;
            Credentials.OAuthToken2.Token = Properties.Settings.Default.TwitterToken2;
            Credentials.OAuthToken2.TokenSecret = Properties.Settings.Default.TwitterTokenSecret2;
            Credentials.OAuthToken2.UserId = Properties.Settings.Default.TwitterUserId;
        }

        public void PerformTask(TwitterTasks task = TwitterTasks.Default)
        {
            AsyncCall.Invoke(() =>
            {
                _isPostTweetCalled = false;
                _isConnectCalled = false;
                switch (task)
                {
                    case TwitterTasks.Authenticate:
                        GetRequestTokenAndNavigateBrowser();
                        break;
                    case TwitterTasks.PostTweet:
                        _isPostTweetCalled = true;
                        if (!Credentials.HasAllCredentials())
                            GetRequestTokenAndNavigateBrowser();
                        else
                        {
                            Tweet();
                        }
                        break;
                    case TwitterTasks.Connect:
                        _isConnectCalled = true;
                        if (!Credentials.HasAllCredentials())
                            GetRequestTokenAndNavigateBrowser();
                        else
                        {
                            Connect(Credentials.OAuthToken2.UserId, GlobalData.TWITTER);
                        }
                        break;
                    default:
                        GetRequestTokenAndNavigateBrowser();
                        break;
                }
            });
        }

        IDictionary<string, string> Parameters
        {
            get
            {
                if (parameters == null)
                {
                    parameters = new Dictionary<string, string>();
                    parameters.Add("oauth_consumer_key", Credentials.ConsumerKey);
                    if (Credentials.OAuthToken == null) Credentials.OAuthToken = new TwitterAuthToken();
                    parameters.Add("oauth_token", Credentials.OAuthToken.Token);
                }
                return parameters;
            }
        }
        public Uri NavigateToUri { get { return GetValue(() => NavigateToUri); } set { SetValue(() => NavigateToUri, value); } }
        private async void GetRequestTokenAndNavigateBrowser()
        {
            await Task.Run(() =>
            {
                parameters = null;
                GlobalData.Default.LoaderVisibility = true;
                Parameters.Remove("oauth_callback");
                Parameters.Add("oauth_callback", EncodeToProtectMultiByteCharUrls("oob"));
                Parameters.Remove("oauth_token");
                string oAuthToken = TwitterService.GetRequestToken(Credentials.ConsumerKey, Credentials.ConsumerSecret, Credentials.AccessToken, Parameters);
                if (string.IsNullOrEmpty(oAuthToken))
                {
                    GlobalData.Default.LoaderVisibility = false;
                    throw new Exception("Could not obtain Request token - Twitter Authentication");
                }
                string[] tokens = oAuthToken.Split('&');
                Properties.Settings.Default.TwitterToken = Credentials.OAuthToken.Token = tokens[0].Split('=')[1];
                Properties.Settings.Default.TwitterTokenSecret = Credentials.OAuthToken.TokenSecret = tokens[1].Split('=')[1];
                Properties.Settings.Default.Save();
                NavigateToUri = new Uri("http://twitter.com/oauth/authenticate?oauth_token=" + Credentials.OAuthToken.Token);
                GlobalData.Default.LoaderVisibility = false;
            });
        }
        string EncodeToProtectMultiByteCharUrls(string callback)
        {
            return callback == "oob" ? "oob" : new Uri(callback).AbsoluteUri;
        }
        public RelayCommand AuthenticateCommand
        {
            get
            {
                return authenticateCommand ?? (authenticateCommand = new RelayCommand(
                    (o) =>
                    {
                        GetUserDetailsAsync();
                    },
                    (o) =>
                    {
                        return !string.IsNullOrEmpty(Credentials.Pin) && !string.IsNullOrWhiteSpace(Credentials.Pin);
                    }));
            }
        }

        public async void GetUserDetailsAsync()
        {
            string navView = await AsyncCall.Invoke<string>(() =>
              {
                  string viewName = string.Empty;
                  Parameters.Remove("oauth_verifier");
                  Parameters.Remove("oauth_token");
                  Parameters.Add("oauth_verifier", Credentials.Pin);
                  Parameters.Add("oauth_token", Credentials.OAuthToken.Token);
                  if (TwitterService.GetAccessToken(Credentials, Parameters))
                  {
                      Properties.Settings.Default.TwitterToken2 = Credentials.OAuthToken2.Token;
                      Properties.Settings.Default.TwitterTokenSecret2 = Credentials.OAuthToken2.TokenSecret;
                      Properties.Settings.Default.TwitterUserId = Credentials.OAuthToken2.UserId;
                      Properties.Settings.Default.Save();
                      Parameters.Remove("screen_name");
                      Parameters.Remove("oauth_token");
                      Parameters.Add("oauth_token", Credentials.OAuthToken2.Token);
                      Parameters.Add("screen_name", Credentials.OAuthToken2.ScreenName);
                      Parameters.Remove("oauth_verifier");
                      TwitterUser tUser = TwitterService.GetUserInfo(Credentials, Parameters);
                      if (tUser == null) throw new LoginException("Could not fetch Twitter user information");
                      User oUser = new User();
                      oUser.name = tUser.name;

                      if (_isPostTweetCalled)
                      {
                          Tweet();
                      }
                      else if (_isConnectCalled)
                      {
                          Connect(tUser.id_str, GlobalData.TWITTER);
                          return "";
                      }
                      else
                      {
                          // Settings are to be saved only after ValidateSocialLogin goes successful. Currently the api is not working, so left as it is.
                          Properties.Settings.Default.TwitterUserId = oUser._id = tUser.id_str;
                          Properties.Settings.Default.SocialType = oUser.type = GlobalData.TWITTER;
                          Properties.Settings.Default.Save();
                          UserDetails = oUser;
                          UserDetails.socialmedia_id = UserDetails._id;
                          oUser = this.ValidateSocialLogin(oUser._id, oUser.type);
                          if (!string.IsNullOrEmpty(oUser.message) && string.IsNullOrEmpty(oUser._id))
                          {
                              viewName = "UserRegistrationView";
                          }
                          else
                          {
                              UserDetails = oUser;
                              viewName = "DashboardView";
                          }
                      }

                  }
                  return viewName;
              });
            if (navView != string.Empty)
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.LoadView, Data = navView });
        }


        private void Tweet()
        {
            string message;
            string contentUrl;
            int msgLength = Configurations.TwitterCharacterLimit;
            if (SharingData != null)
            {
                Uri uri = new Uri(SharingData.url);
                if (SharingData.twitter_title.Contains(uri.Authority))
                {
                    string[] arr = SharingData.twitter_title.Split(new string[] { string.Concat(" ", uri.Authority) }, StringSplitOptions.None);
                    if (arr.Length > 0)
                    {
                        SharingData.twitter_title = arr[0];
                    }
                }
                contentUrl = string.Concat(" ", SharingData.url);
                message = SharingData.twitter_title.Length > msgLength - contentUrl.Length ? string.Concat(SharingData.twitter_title.Substring(0, msgLength - contentUrl.Length), contentUrl) : string.Concat(SharingData.twitter_title, contentUrl);
            }
            else
            {
                contentUrl = string.Concat(" https://www.quealth.co/healthierworld.html");
                message = string.Concat("Quealth – Life Changer! I’ve just helped make the world healthier. Find out more…\n".Substring(0, msgLength - contentUrl.Length), contentUrl);
            }


            string result = TwitterService.PostTweet(message, contentUrl, Credentials, Parameters);
            if (!string.IsNullOrEmpty(result) && result.ToLower().Contains("forbidden"))
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = "You have already made this Tweet. Twitter doesn't allow the same Tweet in a row." });
            if (!string.IsNullOrEmpty(result) && result.ToLower().Contains("status")) // "status" is returned only in case of successfull call.
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = "Message Posted Successfully!!" });
            if (!string.IsNullOrEmpty(result) && result.ToLower().Contains("authorization required"))
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = "Message not Posted!" });
            RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.ExecuteBack });
        }
    }
}
