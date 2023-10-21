using RTH.Business.Objects;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FaceBookAuthenticationView.xaml
    /// </summary>
    public partial class FaceBookAuthenticationView : ViewBase
    {
        private string addressTextBox;


        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<FaceBookAuthenticationViewModel>();
            base.LoadViewModel();
            SuppressCookies();
        }
        //~FaceBookAuthenticationView()
        //{
        //    browser.Dispose();
        //    browser = null;
        //}
        public FaceBookAuthenticationView()
        {
            InitializeComponent();
            this.Loaded += FaceBookAuthenticationView_Loaded;
            this.Unloaded += FaceBookAuthenticationView_Unloaded;
        }

        public void SetViewModelProperty(bool value)
        {
            (this.ViewModel as FaceBookAuthenticationViewModel).IsConnected = value;
        }


        void FaceBookAuthenticationView_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Unloaded -= FaceBookAuthenticationView_Unloaded;
        }


        void FaceBookAuthenticationView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            ViewBase.SuppressCookies();
            if (ViewModelBase.UserDetails != null && ViewModelBase.UserDetails.type != null)
                ViewModelBase.UserDetails.type = string.Empty;
            GlobalData.Default.LoaderVisibility = true;
            this.Loaded -= FaceBookAuthenticationView_Loaded;
            browser.Navigate("https://graph.facebook.com/oauth/authorize?client_id=" + Configurations.FacebookClientID + "&scope=email,publish_actions&redirect_uri=http://www.quealth.co/&response_type=token&display=popup");
        }

        public string AccessToken { get; private set; }

        private void browser_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {
            var dataContext = (this.DataContext as FaceBookAuthenticationViewModel);
            AsyncCall.Invoke(() =>
            {
                this.addressTextBox = e.Url.ToString();
                if (this.addressTextBox.StartsWith("http://www.quealth.co/"))
                {
                    string queryString = e.Url.Fragment;
                    string[] parameters = queryString.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string parameter in parameters)
                    {
                        List<string> parameterList = parameter.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                        if (parameterList.ElementAt(0).Equals("#access_token"))
                        {
                            AccessToken = parameterList.ElementAt(1);

                            var stringUrl = string.Format("https://graph.facebook.com/me?fields=first_name,last_name,id,email&access_token={0}", AccessToken);

                            dynamic me = dataContext.ExecuteHttp(stringUrl).Result;

                            User oUser = new User();
                            oUser.name = (string)me.first_name + " " + (string)me.last_name;
                            oUser.email = (string)me.email;
                            oUser._id = (string)me.id;
                            oUser.type = GlobalData.FACEBOOOK;
                            oUser.socialmedia_id = (string)me.id;
                            if (dataContext.IsConnected)
                            {
                                dataContext.Connect((string)me.id, GlobalData.FACEBOOOK);
                            }
                            else
                            {
                                ViewModelBase.UserDetails = oUser;
                                oUser = dataContext.ValidateSocialLogin(oUser._id, oUser.type);
                                if (oUser.message == "Failed to load User")
                                {
                                    ViewEnum lastView = App.SharedValues.WindowMain.PeekLastView();
                                    if (lastView == ViewEnum.LoginView)
                                    {
                                        Controls.QuealthMessageBox.ShowInformation("User does not exist. Please get started.");
                                        Dispatcher.BeginInvoke((Action)(() => { App.SharedValues.WindowMain.LoadView(Views.Enums.ViewEnum.HomeView); }));
                                    }
                                    else
                                    {
                                        Dispatcher.BeginInvoke((Action)(() => { App.SharedValues.WindowMain.LoadView(Views.Enums.ViewEnum.UserRegistrationView, true, true); }));
                                    }

                                }
                                else
                                {
                                    ViewModelBase.UserDetails = oUser;
                                    ViewModelBase.SaveViewModelSettings((string)me.id, oUser.type);
                                    ViewModelLocator.Get<DashboardViewModel>(resetInstance: true);

                                    var loginView = ViewModelLocator.Get<LoginViewModel>();
                                    ViewEnum view = (ViewEnum)Enum.Parse(typeof(ViewEnum), loginView.GetView() as string);
                                    Dispatcher.BeginInvoke((Action)(() => { App.SharedValues.WindowMain.LoadView(view); }));
                                }
                            }

                            break;
                        }
                        else
                        {
                            Dispatcher.BeginInvoke((Action)(() => { App.SharedValues.WindowMain.LoadView(Views.Enums.ViewEnum.LoginView); }));
                        }
                    }
                }
                else if (this.addressTextBox.StartsWith("https://www.facebook.com/dialog/close"))
                {
                    Dispatcher.BeginInvoke((Action)(() => { App.SharedValues.WindowMain.LoadView(Views.Enums.ViewEnum.LoginView); }));
                }
            });
        }

        private void browser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            GlobalData.Default.LoaderVisibility = false;
        }
    }

}
