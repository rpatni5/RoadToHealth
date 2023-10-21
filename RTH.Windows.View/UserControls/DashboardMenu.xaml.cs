using RTH.Windows.ViewModels.Common;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DashboardSideMenuView.xaml
    /// </summary>
    public partial class DashboardMenu : UserControl
    {
        public DashboardMenu()
        {
            InitializeComponent();
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {                
                txtVersion.Text = string.Format(" Version {0} {1}",System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(3), Configurations.ApiKey);
            }
        }        
    }
}
