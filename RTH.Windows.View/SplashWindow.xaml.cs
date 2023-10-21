﻿using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Helpers.Exceptions;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Enums;
using RTH.Windows.Views.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RTH.Windows.Views
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            bool InterNetConnection = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            InitializeComponent();
            Loaded += SplashWindow_Loaded;
            this.Unloaded += SplashWindow_Unloaded;
            //GetLocale();
        }

        private void SplashWindow_Unloaded(object sender, RoutedEventArgs e)
        {
            IsStart = false;
        }

        private void SplashWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.ShowInfoIfNetUnavailable(App.IsOnline())) ExecuteSplash();
            IsStart = true;
            AnimateLoader();
        }

        string _lang = "en";
        ViewModels.HomeViewModel homeViewModel;
        ViewModels.LoginViewModel login;
        private async Task<bool> LoadPrimaryData()
        {
            return await Task.Run(() =>
            {
                try
                {
                    homeViewModel = new ViewModels.HomeViewModel();
                    App.SharedValues.LanguageResource = homeViewModel.GetLanguageVariables(_lang).data;
                    ViewModelBase.AppMessages = App.SharedValues.LanguageResource;

                    var icons = homeViewModel.FetchDiseaseIcons(_lang);

                    Parallel.ForEach(icons, new ParallelOptions { MaxDegreeOfParallelism = 1 }, icon =>
                    {
                        Application.Current.Dispatcher.Invoke(delegate
                        {
                            BitmapImage bitmap = new BitmapImage(new Uri(string.Concat(icon.type== 4 ? Configurations.OldImagePath : Configurations.ImagePath, icon.image_name), UriKind.Absolute), RTH.Helpers.DataCaching.AppCachePolicy.ImageCachePolicy);

                            BitmapImage bitmapGray = new BitmapImage(new Uri(string.Concat(icon.type == 4 ? Configurations.OldImagePath : Configurations.ImagePath, icon.image_logo_color), UriKind.Absolute), RTH.Helpers.DataCaching.AppCachePolicy.ImageCachePolicy);

                            App.SharedValues.DiseaseIcons.AddOrUpdate(icon.key_string, bitmap, (k, s) => s);
                            App.SharedValues.DiseasePlainIcons.AddOrUpdate(icon.key_string, bitmapGray, (k, s) => s);
                        }, DispatcherPriority.Render);
                    });
                    return true;
                }
                catch (Exception ex)
                {

                    throw;
                }
            });
        }

        private async Task<User> ExecuteUserLogin()
        {
            var user = await Task.Run(() =>
            {
                string email = Properties.Settings.Default.Email;


                login = new ViewModels.LoginViewModel();
                string strPwd = Properties.Settings.Default.SecurePwd.Value();
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(strPwd) && strPwd != Configurations.DefaultPassword)
                {
                    return login.UserLogin(new Business.Objects.User() { email = email, Securepwd = Properties.Settings.Default.SecurePwd });
                }
                else
                {
                    IDictionary<string, string> vmProperties = ViewModelBase.GetViewModelSettings();
                    string socialId;
                    string socialType = vmProperties["SocialType"];
                    if (vmProperties["SocialType"] == GlobalData.TWITTER)
                    {
                        socialId = vmProperties["TwitterUserId"];
                    }
                    else
                    {
                        socialId = vmProperties["FacebookUserId"];
                    }

                    if (!string.IsNullOrEmpty(socialId) && !string.IsNullOrEmpty(socialType))
                        // return login.ValidateSocialLogin(socialId, socialType);
                        return login.UserLogin(new Business.Objects.User() { socialmedia_id = socialId, type = socialType });
                }

                return null;
            });
            return user;
        }

        public async Task<AppVersionInfo> GetIsLatestVersion()
        {
            return await AsyncCall.Invoke(() =>
            {
                AppVersionInfo toRet = null;
                var info = ViewModelBase.GetLatestVersionInfo();
                if (info != null)
                {
                    toRet = new AppVersionInfo(info);
                    if (Configurations.CurrentBuild == info.build)
                    {
                        toRet.AppVersion = Enums.AppVersions.Latest;
                    }
                    else if (Configurations.CurrentBuild < info.build && info.force_update)
                    {
                        toRet.AppVersion = Enums.AppVersions.UpdateRequired;
                    }
                    else if (Configurations.CurrentBuild < info.build && !info.force_update)
                    {
                        toRet.AppVersion = Enums.AppVersions.Older;
                    }
                }
                return toRet;
            });
        }

        private async void ExecuteSplash()
        {
            string message = string.Empty;
            AppVersionInfo versionInfo = await GetIsLatestVersion();
            if (versionInfo != null)
            {
                if (versionInfo.AppVersion == Enums.AppVersions.Older)
                {
                    MessageBoxResult result = Controls.QuealthMessageBox.ShowQuestion(this, versionInfo.message);
                    if (result == MessageBoxResult.Yes || result == MessageBoxResult.OK)
                    {
                        // call to update
                        //return;
                    }
                }
                else if (versionInfo.AppVersion == Enums.AppVersions.UpdateRequired)
                {
                    MessageBoxResult result = Controls.QuealthMessageBox.ShowQuestion(this, versionInfo.message, button: MessageBoxButton.OK);
                    if (result == MessageBoxResult.OK)
                    {
                        // call to update
                        //return;
                    }
                    else
                    {
                        App.Current.Shutdown();
                    }
                    // call to update
                    return;
                }
            }
            MainWindow mainWindow = null;
            User oUser = null;
            try
            {
                await LoadPrimaryData();
                oUser = await ExecuteUserLogin();
                if (oUser != null && oUser.message == null)
                {
                    ViewModelBase.UserDetails = oUser;
                    _lang = oUser.language;
                    await LoadPrimaryData();
                    ViewEnum ve = await CheckView();
                    mainWindow = new MainWindow(ve);
                }
                else
                {
                    mainWindow = new MainWindow(Views.Enums.ViewEnum.HomeView, true);
                }
                mainWindow.Show(); this.Close();
            }
            catch (LoginException ex)
            {
                if (ex.Message.ToLower().Contains("do not match"))
                {
                    mainWindow = new MainWindow(Views.Enums.ViewEnum.HomeView);
                    mainWindow.Show(); this.Close();
                }
                else
                {
                    QuealthMessageBox.ShowError(ex, ex.Message);
                }
            }

        }

        private async Task<ViewEnum> CheckView()
        {
            login = login ?? new ViewModels.LoginViewModel();
            return (ViewEnum)Enum.Parse(typeof(ViewEnum), login.GetView() as string);
        }

        int j = 2;
        bool IsStart = true;
        private async void AnimateLoader()
        {
            AsyncCall.Invoke(() =>
            {
                Thread.Sleep(300);

                if (j == 1)
                {
                    Dispatcher.Invoke(() =>
                    {
                        viewTyping.Content = ".";
                    });
                    j = 2;
                }
                else if (j == 2)
                {
                    Dispatcher.Invoke(() =>
                    {
                        viewTyping.Content = "..";
                    });
                    j = 3;
                }
                else if (j == 3)
                {
                    Dispatcher.Invoke(() =>
                    {
                        viewTyping.Content = "...";
                    });
                    j = 1;
                }
                if (IsStart)
                    AnimateLoader();
            }, false);
        }
    }
}
