using RTH.Business.Objects;
using RTH.Business.Services;
using RTH.Helpers.Exceptions;
using RTH.Helpers.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels.Common
{
    public abstract class SocialViewModelBase : ViewModelBase
    {
        public void Connect(string socialId, string socialType)
        {
            UserDetails.socialmedia_id = socialId;
            UserDetails.type = socialType;
            try
            {
                User updatedUser = UserService.UpdateUserProfile(UserDetails, UserDetails.AuthToken.access_token);
                UserDetails.sociallogins = updatedUser.sociallogins;
                UserDetails.socialmedia_id = updatedUser.socialmedia_id;
                UserDetails.salt = updatedUser.salt;
                UserDetails.hashed_password = updatedUser.hashed_password;
                UserDetails.type = Configurations.NORMAL_USER_TYPE;
            }
            catch (LoginException le)
            {
                UserDetails.socialmedia_id = null;
                UserDetails.type = Configurations.NORMAL_USER_TYPE;
                RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.Message, Data = le.Message });
            }
            RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.ExecuteBack });
        }

    }
}
