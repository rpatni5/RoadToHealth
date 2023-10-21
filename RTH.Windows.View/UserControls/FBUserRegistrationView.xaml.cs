using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FBUserRegistrationView.xaml
    /// </summary>
    public partial class FBUserRegistrationView : ViewBase
    {
        public FBUserRegistrationView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            SuppressCookies();
            this.ViewModel = ViewModelLocator.GetNew<FBUserRegistrationViewModel>();
            (this.ViewModel as FBUserRegistrationViewModel).name = ViewModelBase.UserDetails.name;
            base.LoadViewModel();
        }
    }
}
