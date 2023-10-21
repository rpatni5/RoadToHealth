﻿using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System;
using System.Web;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FaceBookSharingToWallView.xaml
    /// </summary>

    public partial class FaceBookSharingToWallView : ViewBase
    {
        private string addressTextBox;
        private string url;
        private string redirectUrl;
        public ShareData fbShareData;
        public FaceBookSharingToWallView()
        {
            InitializeComponent();
            this.Loaded += FaceBookAuthenticationView_Loaded;
            this.Unloaded += FaceBookAuthenticationView_Unloaded;
        }
        public override void LoadViewModel()
        {           
            this.ViewModel = ViewModelLocator.Get<FaceBookSharingToWallViewModel>();            
            base.LoadViewModel();
        }

        void FaceBookAuthenticationView_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Unloaded -= FaceBookAuthenticationView_Unloaded;
            this.browser.Dispose();
            this.browser = null;
        }

        void FaceBookAuthenticationView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            redirectUrl = "http://www.quealth.co/";
            if (fbShareData != null)
            {
                GlobalData.Default.LoaderVisibility = true;
                url = string.Format("https://www.facebook.com/dialog/feed?app_id={6}&scope=publish_actions&link={5}&picture={0}&name={1}&caption={2}&description={3}&redirect_uri={4}&display=popup", Uri.EscapeUriString(fbShareData.thumb_image), Uri.EscapeUriString(fbShareData.name), Uri.EscapeUriString(fbShareData.title), Uri.EscapeUriString(fbShareData.description), Uri.EscapeUriString(redirectUrl) , Uri.EscapeUriString(fbShareData.url), Configurations.FacebookClientID);
            }
            else {
                url = "https://www.facebook.com/dialog/feed?app_id="+ Configurations.FacebookClientID+"&link=http://www.quealth.co/&picture=https://ng-admin-live.roadtohealth.co.uk/img/icon.png&name=Quealth&caption=Quealth%20%E2%80%93%20Life%20Changer!&description=I%E2%80%99ve%20just%20helped%20make%20the%20world%20healthier.%20Find%20out%20more%E2%80%A6&redirect_uri=http://www.quealth.co/&display=popup";                
            }
            browser.Navigate(url);
        }

        public string AccessToken { get; private set; }
        private void browser_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {

            this.addressTextBox = e.Url.ToString();
            if (this.addressTextBox.StartsWith(string.Format("{0}?post_id=", redirectUrl)))
            {
                MessageBox.Show("Message Posted Successfully.");
                browser.Navigate(url);
                App.SharedValues.WindowMain.BackCommand.Execute(null);
            }
            else if (this.addressTextBox.StartsWith(redirectUrl))
            {
                browser.Navigate(url);
                App.SharedValues.WindowMain.BackCommand.Execute(null);
            }
        }
        private void browser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {
            GlobalData.Default.LoaderVisibility = false;
        }
    }
}

