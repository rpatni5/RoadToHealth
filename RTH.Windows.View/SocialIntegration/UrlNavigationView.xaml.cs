using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for UrlNavigationView.xaml
    /// </summary>
    public partial class UrlNavigationView : ViewBase
    {
        public UrlNavigationView()
        {
            InitializeComponent();
        }

        public void Navigate(string url)
        {
            browser.Navigate(url);
        }

        private void browser_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {

        }

        private void browser_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
