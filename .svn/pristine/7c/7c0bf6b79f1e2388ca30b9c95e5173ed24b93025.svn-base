using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for MWHealthierView.xaml
    /// </summary>
    public partial class MWHealthierView : ViewBase
    {
        public MWHealthierView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<MWHealthierViewModel>();
            base.LoadViewModel();
        }
        private RelayCommand _ShareCommand;
        public RelayCommand ShareCommand
        {
            get
            {
                return _ShareCommand ?? (_ShareCommand = new RelayCommand(
                    ve => OnShare(ve), (t) => true));
            }
        }

      
        public void OnShare(object ve)
        {
            shareFb.Visibility = Visibility.Collapsed;
            ShareTwitter.Visibility = Visibility.Collapsed;
            if (ve != null)
            {
                if (ve.Equals("ShareFB"))
                {
                    shareFb.Visibility = Visibility.Visible;
                    ShareTwitter.Visibility = Visibility.Collapsed;
                }
                else if (ve.Equals("ShareTwitter"))
                {
                    shareFb.Visibility = Visibility.Collapsed;
                    ShareTwitter.Visibility = Visibility.Visible;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            shareFb.Visibility = Visibility.Collapsed;
            ShareTwitter.Visibility = Visibility.Collapsed;
        }
    }
}
