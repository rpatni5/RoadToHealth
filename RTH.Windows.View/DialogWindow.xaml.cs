using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Enums;
using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.UserControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RTH.Windows.Views
{
    /// <summary>
    /// Interaction logic for CoachesWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow(ViewEnum view)
        {
            InitializeComponent();
            DialogGrid.Children.Clear();
            UserControls.ViewBase viewname = null;
            if (view == ViewEnum.ShowCoaches)
            {
                DialogGrid.Children.Add(viewname = new ShowCoachesView());
            }
            else if (view == ViewEnum.AllQScoreView)
            {
                DialogGrid.Children.Add(viewname = new AllQScoreView());
                labelText.Content = App.SharedValues.LanguageResource.your_quealth_win;
                header.Visibility = Visibility.Visible;
            }
            else if (view == ViewEnum.HealthReportView)
            {
                HraControl.Visibility = Visibility.Collapsed;
                DialogGrid.Children.Add(viewname = new HealthReportView());
                labelText.Content = App.SharedValues.LanguageResource.health_report;
                header.Visibility = Visibility.Visible;
            }
            this.DataContext = viewname.ViewModel;
        }

        private RelayCommand m_CloseDialog;
        public RelayCommand CloseDialog
        {
            get
            {
                return m_CloseDialog ?? (m_CloseDialog = new RelayCommand(
                    ve =>
                    {
                        this.Close();
                    }, (t) => true));
            }
        }
    }
}
