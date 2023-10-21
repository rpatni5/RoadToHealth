using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PolicyView.xaml
    /// </summary>
    public partial class PolicyView : ViewBase
    {
        public PolicyView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<PolicyViewModel>();
            base.LoadViewModel();
        }
    }
}
