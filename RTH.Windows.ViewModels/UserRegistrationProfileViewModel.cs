using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RTH.Windows.ViewModels
{
    public class UserRegistrationProfileViewModel : ViewModelBase
    {
        public UserRegistrationProfileViewModel()
        {
            AsyncCall.Invoke(() =>
            {
                IsMale = false;
                BirthDate = "";
                NameColor = "#FF31AAE1";
                LoadPrimaryData();
            });
        }
        public String country
        {
            get { return GetValue(() => country); }
            set
            {
                SetValue(() => country, value);
            }
        }
        public String BirthDate
        {
            get { return GetValue(() => BirthDate); }
            set
            {
                SetValue(() => BirthDate, value);
            }
        }
        public String name
        {
            get { return GetValue(() => name); }
            set { SetValue(() => name, value); }
        }
        public bool IsMale
        {
            get { return GetValue(() => IsMale); }
            set { SetValue(() => IsMale, value); }
        }
        public bool IsFeMale
        {
            get { return GetValue(() => IsFeMale); }
            set { SetValue(() => IsFeMale, value); }
        }

        public IEnumerable<Country> CountryList
        {
            get { return GetValue(() => CountryList); }
            set
            {
                SetValue(() => CountryList, value);
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

        private RelayCommand m_UserProfileRegistration;
        public RelayCommand UserProfileRegistrationCommand
        {
            get
            {
                return m_UserProfileRegistration ?? (m_UserProfileRegistration = new RelayCommand(
                    ve => ExecuteProfileUserRegistration(ve), (t) => true));
            }
        }

        private void ExecuteProfileUserRegistration(object ve)
        {
            AsyncCall.Invoke(() =>
            {
                ViewModelBase.Errors = string.Empty;
                NameColor = "#FF31AAE1";
                if (string.IsNullOrEmpty(this.name))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.please_enter_name;
                    return;
                }
                if (!ExtensionMethod.ValidateName(this.name))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.please_enter_valid_name;
                    NameColor = "#FFE51400";
                    return;
                }
                if (this.IsMale==false && this.IsFeMale==false)
                {
                    this.ErrorMessage = "Please Select Gender";
                    return;
                }
                if (string.IsNullOrEmpty(BirthDate))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.enter_dob;
                    return;
                }
                if (Convert.ToDateTime(BirthDate) > DateTime.Now.AddYears(-20))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.validation_select_dob;
                    NameColor = "#FFE51400";
                    return;
                }
                UserDetails.name = name;
                UserDetails.dob = Convert.ToString(Convert.ToDateTime(BirthDate).ToString("yyyy-MM-dd"));
                UserDetails.country = country;
                UserDetails.device_id = "windows";
                UserDetails.device_type = "3";
                UserDetails.gender = IsMale == true ? 1 : 2;
                UserDetails.provider = "3";

                UserDetails.Securepwd = UserDetails.password.ToSecureString();
                User oUser = RTH.Business.Services.UserService.RegisterUser(UserDetails);
                oUser.Securepwd = UserDetails.password.ToSecureString();
                if (oUser != null)
                {
                    if (oUser.message == null)
                    {
                        ViewModelBase.UserDetails = oUser;
                        if (UserDetails.sociallogins != null && UserDetails.sociallogins.Count > 0)
                            SaveViewModelSettings(UserDetails.sociallogins.FirstOrDefault(x => x.socialmedia_type == UserDetails.type).socialmedia_id, UserDetails.type);
                        RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.SaveCredentialAndLoadChatView, Data = UserDetails });
                        //SaveCredentials(oUser.email, UserRegistrationViewModel.password);
                        //this.LoadView(Enums.ViewEnum.UserRegistrationProfileView);
                    }
                    else
                    {
                        if (oUser.message == "There is an existing account associated with this email address.")
                        {
                            ViewModelBase.Errors = oUser.message;
                            RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.ExecuteBack });
                        }
                        else
                        {
                            ErrorMessage = oUser.message;
                        }
                    }
                }
            });
        }

        private void LoadPrimaryData()
        {
            CountryList = RTH.Business.Services.AppService.GetCountry().Data;
            country = "53eb36f79b982320b4009f7e";
            HeaderLabel = AppMessages.login;
        }
    }
}
