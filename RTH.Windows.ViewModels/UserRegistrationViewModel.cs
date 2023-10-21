﻿using RTH.Business.Objects;
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
    public class UserRegistrationViewModel : Common.ViewModelBase
    {

        public IEnumerable<Language> LanguageList
        {
            get { return GetValue(() => LanguageList); }
            set
            {
                SetValue(() => LanguageList, value);
            }
        }
        public IEnumerable<Country> CountryList
        {
            get { return GetValue(() => CountryList); }
            set
            {
                SetValue(() => CountryList, value);
            }
        }

        public UserRegistrationViewModel()
        {
            ExecuteRegistrationLoad();
            EmailColor = "#FF31AAE1";
        }

        private async void ExecuteRegistrationLoad()
        {
            GlobalData.Default.LoaderVisibility = true;
            User oUser = await ExecuteRegistration();
            GlobalData.Default.LoaderVisibility = false;
        }

        private async Task<User> ExecuteRegistration()
        {
            var user = await AsyncCall.Invoke(() =>
            {
                LoadPrimaryData();
                string email = null;//Properties.Settings.Default.Email;
                string password = null; //Properties.Settings.Default.Password;
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    ViewModels.LoginViewModel login = new ViewModels.LoginViewModel();
                    return login.UserLogin(new Business.Objects.User() { email = email, Securepwd = password.ToSecureString() });
                }
                return null;
            });
            return user;
        }

        private void LoadPrimaryData()
        {
            IsNotified = true;
            IsDiscloseData = true;
            LanguageList = RTH.Business.Services.AppService.GetLanguage().Data;
            Language = Lang ?? "en";
            CountryList = RTH.Business.Services.AppService.GetCountry().Data;
            country = "53eb36f79b982320b4009f7e";
            HeaderLabel = AppMessages.login;
        }
        private User userData;
        public async Task<User> UserRegistration()
        {
            return await AsyncCall.Invoke(() =>
            {
                EmailColor = "#FF31AAE1";
                NameColor = "#FF31AAE1";
                //if (string.IsNullOrEmpty(this.name))
                //{
                //    this.ErrorMessage = ViewModelBase.AppMessages.please_enter_name;
                //    return null;
                //}
                //if (!ExtensionMethod.ValidateName(this.name))
                //{
                //    this.ErrorMessage = ViewModelBase.AppMessages.please_enter_valid_name;
                //    NameColor = "#FFE51400"; return null;
                //}
                if (string.IsNullOrEmpty(this.email))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.missing_email;
                    return null;
                }
                if (!ExtensionMethod.ValidateEmail(this.email))
                {
                    EmailColor = "#FFE51400";
                    this.ErrorMessage = ViewModelBase.AppMessages.invalid_email_entry;
                    return null;
                }

                if (ViewModelBase.UserDetails==null || ViewModelBase.UserDetails.type == Configurations.NORMAL_USER_TYPE)
                {
                    if (string.IsNullOrEmpty(this.password))
                    {
                        this.ErrorMessage = ViewModelBase.AppMessages.please_enter_password;
                        return null;
                    }
                    if (string.IsNullOrEmpty(this.confirm))
                    {
                        this.ErrorMessage = ViewModelBase.AppMessages.please_enter_confirm_password;
                        return null;
                    }
                    if (this.confirm != this.password)
                    {
                        this.ErrorMessage = ViewModelBase.AppMessages.password_mismatched;
                        return null;
                    }
                    if (!System.Text.RegularExpressions.Regex.IsMatch(this.password, Configurations.PasswordRegex))
                    {
                        this.ErrorMessage = ViewModelBase.AppMessages.password_must_contain_numbers_and_special_char;
                        return null;
                    }
                }
                var User = new User
                {
                    name = name,
                    email = email,
                    Securepwd = password.ToSecureString(),
                    confirm = confirm,
                    username = email,
                    language = Language,
                    country = country,
                    notified = IsNotified,
                    discloseData = IsDiscloseData,
                    socialmedia_id= UserDetails!=null?UserDetails.socialmedia_id:null,
                    type= UserDetails != null ? UserDetails.type : null
                };

                //return RTH.Business.Services.UserService.RegisterUser(User);
                return User;
            });
        }

        private void GetLocale()
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;
            string localLang = System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        }

        #region ViewModel Property  
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
        public String password
        {
            get { return GetValue(() => password); }
            set
            {
                SetValue(() => password, value);
            }
        }
        public String confirm
        {
            get { return GetValue(() => confirm); }
            set
            {
                SetValue(() => confirm, value);
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
        public String country
        {
            get { return GetValue(() => country); }
            set
            {
                SetValue(() => country, value);
            }
        }
        public bool IsNotified
        {
            get { return GetValue(() => IsNotified); }
            set
            {
                SetValue(() => IsNotified, value);
            }
        }

        public bool IsDiscloseData
        {
            get { return GetValue(() => IsDiscloseData); }
            set
            {
                SetValue(() => IsDiscloseData, value);
            }
        }


        #endregion

    }
}
