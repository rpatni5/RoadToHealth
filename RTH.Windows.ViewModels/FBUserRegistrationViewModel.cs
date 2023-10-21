using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RTH.Windows.ViewModels
{
    public class FBUserRegistrationViewModel : Common.ViewModelBase
    {

        public IEnumerable<Language> LanguageList
        {
            get { return GetValue(() => LanguageList); }
            set
            {
                SetValue(() => LanguageList, value);
            }
        }

        public FBUserRegistrationViewModel()
        {
            AsyncCall.Invoke(() =>
            {
                email = UserDetails.email;
                name = UserDetails.name;
                LanguageList = RTH.Business.Services.AppService.GetLanguage().Data;
                Language = Lang ?? "en";
                CountryList = RTH.Business.Services.AppService.GetCountry().Data;
                HeaderLabel = AppMessages.we_need_more_detail;
                country = "53eb36f79b982320b4009f7e";
                EmailColor = "#FF000000";
                NameColor = "#FF000000";
            });
        }
        public Task<User> RegistrationWithSocialLogin()
        {
            return AsyncCall.Invoke(() =>
             {
                 EmailColor = "#FF000000";
                 NameColor = "#FF000000";
                 if (string.IsNullOrEmpty(this.name))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.please_enter_name;
                     GlobalData.Default.LoaderVisibility = false; return null;
                 }
                 if (!ExtensionMethod.ValidateName(this.name))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.please_enter_valid_name;
                     GlobalData.Default.LoaderVisibility = false; NameColor = "#FFE51400"; return null;
                 }
                 if (string.IsNullOrEmpty(this.email))
                 {
                     this.ErrorMessage = ViewModelBase.AppMessages.missing_email;
                     GlobalData.Default.LoaderVisibility = false; return null;
                 }
                 if (!ExtensionMethod.ValidateEmail(this.email))
                 {
                     EmailColor = "#FFE51400";
                     this.ErrorMessage = ViewModelBase.AppMessages.invalid_email_entry;
                     GlobalData.Default.LoaderVisibility = false; return null;
                 }

                 var User = new User
                 {
                     name = name,
                     email = email,
                     username = name,
                     language = Language,
                     Securepwd = Password.ToSecureString(),
                     confirm = Password,
                     socialmedia_id = UserDetails._id,
                     type = UserDetails.type,
                     country = country
                 };
                 var u= RTH.Business.Services.UserService.RegisterUserWithSocialLogin(User);
                 SaveViewModelSettings(User.socialmedia_id, User.type);
                 return u;
             });
        }

        #region ViewModel Property  

        public IEnumerable<Country> CountryList
        {
            get { return GetValue(() => CountryList); }
            set
            {
                SetValue(() => CountryList, value);
            }
        }

        public String name
        {
            get { return GetValue(() => name); }
            set { SetValue(() => name, value); }
        }

        public String email
        {
            get { return GetValue(() => email); }
            set
            {
                SetValue(() => email, value);
            }
        }

        public String Language
        {
            get { return GetValue(() => Language); }
            set
            {
                SetValue(() => Language, value);
            }
        }
        public String HealthGuidelines
        {
            get { return GetValue(() => HealthGuidelines); }
            set
            {
                SetValue(() => HealthGuidelines, value);
            }
        }
        public String SocialId
        {
            get { return GetValue(() => SocialId); }
            set
            {
                SetValue(() => SocialId, value);
            }
        }
        public String Type
        {
            get { return GetValue(() => Type); }
            set
            {
                SetValue(() => Type, value);
            }
        }

        public String Password
        {
            get { return GetValue(() => Password); }
            set
            {
                SetValue(() => Password, value);
            }
        }
        public String country
        {
            get { return GetValue(() => country); }
            set
            {
                SetValue(() => country, value);
            }
        }
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
        #endregion
    }
}
