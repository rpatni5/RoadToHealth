using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for TermsAndConditionsView.xaml
    /// </summary>
    public partial class TermsAndConditionsView : ViewBase
    {
        public TermsAndConditionsView()
        {
            InitializeComponent();
        }
        TermsAndConditionsViewModel vm;
        public override void LoadViewModel()
        {
            vm = ViewModelLocator.Get<TermsAndConditionsViewModel>();
            this.ViewModel = vm;
            base.LoadViewModel();
        }
        public bool Isvisible { get; set; }
        public override void OnViewLoaded()
        {
            if (Isvisible)
            {
                btnGetStarted.Visibility = System.Windows.Visibility.Collapsed;
                vm.FooterVisibility = true;
                grid.Margin = new System.Windows.Thickness(0,0,0,55);
            }
            else
            {
                btnGetStarted.Visibility = System.Windows.Visibility.Visible;
                vm.FooterVisibility = false;
                grid.Margin = new System.Windows.Thickness(0);
            }
            base.OnViewLoaded();
        }
    }
}
