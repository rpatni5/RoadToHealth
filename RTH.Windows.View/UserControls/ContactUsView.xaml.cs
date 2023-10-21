﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Diagnostics;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ContactUs.xaml
    /// </summary>
    public partial class ContactUsView : ViewBase
    {
        public ContactUsView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ContactUsViewModel>();
            base.LoadViewModel();

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("mailto://support@quealth.zendesk.com");
        }

        private void ViewBase_Loaded(object sender, RoutedEventArgs e)
        {
            browser.Navigate("https://quealth.zendesk.com/hc/en-us");
        }

        private void browser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {

            browser.Document.Body.Style = "zoom:75%;";
        }
    }
}
