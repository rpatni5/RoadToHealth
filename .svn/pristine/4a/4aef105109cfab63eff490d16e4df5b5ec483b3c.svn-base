using RTH.Business.Objects;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.ViewModels
{
    public class FaceBookAuthenticationViewModel : SocialViewModelBase
    {
        public bool IsConnected
        {
            get { return GetValue(() => this.IsConnected); }
            set { SetValue(() => IsConnected, value); }
        }

        public User ValidateSocialLogin(User OUser)
        {
            //return RTH.Business.Services.UserService.ValidateSocialLogin(OUser._id, OUser.type, Configurations.DefaultPassword.ToSecureString());
            return RTH.Business.Services.UserService.UserLogin(new Business.Objects.User() { socialmedia_id = OUser._id, type = OUser.type });
        }
    }

}
