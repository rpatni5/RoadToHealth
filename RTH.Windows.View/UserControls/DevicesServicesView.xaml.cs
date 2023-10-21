using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DevicesServicesView.xaml
    /// </summary>
    public partial class DevicesServicesView : ViewBase
    {
        public DevicesServicesView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<DevicesServicesViewModel>(refreshRequired: true);
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }
        public override void OnMessage(Message e)
        {
            switch (e.Type)
            {
                case MessageType.ConnectToFacebook:                   
                    App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.FaceBookAuthenticationView,param:true);                    
                    break;
                case MessageType.ConnectToTwitter:
                    break;
            }
            base.OnMessage(e);

        }
    }
}
