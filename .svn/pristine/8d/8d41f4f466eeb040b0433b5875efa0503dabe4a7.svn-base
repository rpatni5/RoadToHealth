using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AboutUsView.xaml
    /// </summary>
    public partial class AboutUsView : ViewBase
    {
        public AboutUsView()
        {
            InitializeComponent();
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<AboutUsViewModel>();
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }

        private void rdoAbout_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            string Destinations = ((RadioButton)sender).Tag as string;
            ViewModelBase.ExecuteTrackNavigation("About", Destinations , 0);
        }
    }
}
