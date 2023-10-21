﻿using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RTH.Windows.ViewModels.Common;
using RTH.Helpers;

namespace RTH.Windows.ViewModels
{
    public class ForgotPasswordViewModel : ViewModelBase
    {
        public String EmailColor
        {
            get { return GetValue(() => EmailColor); }
            set
            {
                SetValue(() => EmailColor, value);
            }
        }

        public int ErrorStatus
        {
            get { return GetValue(() => ErrorStatus); }
            set
            {
                SetValue(() => ErrorStatus, value);
            }
        }
        public ForgotPasswordViewModel()
        {
            HeaderLabel = AppMessages.signin_help;
            EmailColor = "#FF000000";
        }

        public async Task<User> RequestAnAccessCode()
        {
            var user = await AsyncCall.Invoke(() =>
            {
                ErrorStatus = 0;
                if (string.IsNullOrEmpty(this.Email))
                {
                    this.ErrorMessage = ViewModelBase.AppMessages.missing_email;
                    GlobalData.Default.LoaderVisibility = false; return null;
                }
                else if (!ExtensionMethod.ValidateEmail(this.Email))
                {
                    EmailColor = "#FFE51400";
                    this.ErrorMessage = ViewModelBase.AppMessages.invalid_email_entry;
                    GlobalData.Default.LoaderVisibility = false; return null;
                }
                var oUserLogin = new RTH.Business.Objects.User
                {
                    email = Email
                };
                User objUser = RTH.Business.Services.UserService.RequestAnAccessCode(oUserLogin);
                ErrorStatus = objUser.status==0?1:0;
                return objUser;
            });
            return user;
        }

        public User UserLogin(User oUserLogin)
        {
            return RTH.Business.Services.UserService.UserLogin(oUserLogin);
        }
        public async Task<User> ChangePassword()
        {
            var user = await AsyncCall.Invoke(() =>
            {
                if (string.IsNullOrEmpty(this.Code))
                { this.ErrorMessage2 = ViewModelBase.AppMessages.enter_access_code; GlobalData.Default.LoaderVisibility = false; return null; }               
                if (string.IsNullOrEmpty(this.Password))
                { this.ErrorMessage2 = ViewModelBase.AppMessages.enter_new_password; GlobalData.Default.LoaderVisibility = false; return null; }
                if (string.IsNullOrEmpty(this.Confirm))
                { this.ErrorMessage2 = ViewModelBase.AppMessages.enter_confirm_new_password; GlobalData.Default.LoaderVisibility = false; return null; }
                if (this.Confirm != this.Password)
                { this.ErrorMessage2 = ViewModelBase.AppMessages.password_mismatched; GlobalData.Default.LoaderVisibility = false; return null; }
                if (!System.Text.RegularExpressions.Regex.IsMatch(this.Password, Configurations.PasswordRegex))
                {
                    this.ErrorMessage2 = ViewModelBase.AppMessages.password_must_contain_numbers_and_special_char;
                    return null;
                }
                var oUserLogin = new RTH.Business.Objects.User
                {
                    Securepwd = Password.ToSecureString(),
                    responsecode = Code

                };
                return RTH.Business.Services.UserService.ForGotPassword(oUserLogin);
            });
            return user;
        }

        #region Property 
        public String Email
        {
            get { return GetValue(() => Email); }
            set
            {
                SetValue(() => Email, value);
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
        public String Confirm
        {
            get { return GetValue(() => Confirm); }
            set
            {
                SetValue(() => Confirm, value);
            }
        }
        public String Code
        {
            get { return GetValue(() => Code); }
            set
            {
                SetValue(() => Code, value);
            }
        }
        #endregion
    }
}