using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RTH.Business.Objects.JSON
{
    public class TwitterCredentials : NotifyBase
    {
        /// <summary>
        /// Key provided by Twitter for your application
        /// </summary>
        public string ConsumerKey { get { return TwitterConfig.ConsumerKey; } }

        /// <summary>
        /// Secret provided by Twitter for your application
        /// </summary>
        public string ConsumerSecret { get { return TwitterConfig.ConsumerSecret; } }
        public string AccessToken { get { return TwitterConfig.AccessToken; } }
        public string AccessTokenSecret { get { return TwitterConfig.AccessTokenSecret; } }

        /// <summary>
        /// Token provided by Twitter for making request
        /// </summary>
        public TwitterAuthToken OAuthToken { get { return GetValue(() => OAuthToken); } set { SetValue(() => OAuthToken, value); } }

        /// <summary>
        /// Token provided by Twitter for making request after getting the "Pin"
        /// </summary>
        public TwitterAuthToken OAuthToken2 { get { return GetValue(() => OAuthToken2); } set { SetValue(() => OAuthToken2, value); } }

        /// <summary>
        /// Pin obtained after login into the twitter app
        /// </summary>
        public string Pin { get { return GetValue(() => Pin); } set { SetValue(() => Pin, value); } }

        /// <summary>
        /// Unique access token for a user
        /// </summary>
        public bool HasAllCredentials()
        {
            return
                    !string.IsNullOrWhiteSpace(ConsumerKey) &&
                    !string.IsNullOrWhiteSpace(ConsumerSecret) &&
                    OAuthToken != null && !string.IsNullOrWhiteSpace(OAuthToken.Token) &&
                    OAuthToken2 != null && !string.IsNullOrWhiteSpace(OAuthToken2.Token);
        }

    }
}
