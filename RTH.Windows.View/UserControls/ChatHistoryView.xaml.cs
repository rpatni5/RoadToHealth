using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
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
    /// Interaction logic for ChatHistoryView.xaml
    /// </summary>
    public partial class ChatHistoryView : ViewBase
    {
        public ChatHistoryView()
        {
            InitializeComponent();
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ChatHistoryViewModel>(refreshRequired:true);
            base.LoadViewModel();
        }

        private RelayCommand m_ChatActivityCommand;
        public RelayCommand ChatActivityCommand
        {
            get
            {
                return m_ChatActivityCommand ?? (m_ChatActivityCommand = new RelayCommand(
                    ve => ExecuteActivity(ve), (t) => true));
            }
        }

        private void ExecuteActivity(object ve)
        {
            if (ve != null)
            {
                App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.ExploreChatHistoryView, param: ve);
            }
        }
    }
}
