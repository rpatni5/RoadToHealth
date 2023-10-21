using System.Windows;
using System.Windows.Controls;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DeactivateView.xaml
    /// </summary>
    public partial class DeactivateView : ViewBase
    {
        public DeactivateView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<DeactivateViewModel>(refreshRequired: true);
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }

        private void rdoAnswersList_Checked(object sender, RoutedEventArgs e)
        {

            var selRdoButton = sender as RadioButton;

            DeactivateViewModel.objSelectedAnswer._id = selRdoButton.Uid;
            DeactivateViewModel.objSelectedAnswer.deactivation_text = selRdoButton.Content.ToString();
        
            // DeactivateViewModel.strDeactivationText = selRdoButton.Content.ToString();
            
            if (selRdoButton.Content.ToString() == Configurations.CUSTOM_DEACTIVATION_TEXT)
            {

                txtCustomText.IsEnabled = true;
                txtCustomText.Focus();

            }
            else
                txtCustomText.IsEnabled = false;


        }

    }
}
