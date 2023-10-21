using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for uc_Login.xaml
    /// </summary>
    public partial class LoginView : ViewBase
    {
        public LoginView()
        {
            InitializeComponent();           
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<LoginViewModel>();
            base.LoadViewModel();
        }
        private RelayCommand<object[]> m_ControlClearCommand;
        public RelayCommand<object[]> ControlClearCommand
        {
            get
            {
                return m_ControlClearCommand ?? (m_ControlClearCommand = new RelayCommand<object[]>(
                    ve => ControlClear(ve), (t) => (t) != null));
            }
        }

        private void ControlClear(object[] ve)
        {
            if (ve[0] is PasswordBox)
            {
                PasswordBox control = ve[0] as PasswordBox;
                control.Clear();
                if (ve[1] is Button)
                {
                    Button btn = ve[1] as Button;
                    btn.Visibility = Visibility.Hidden;
                    txtPassword.Visibility = Visibility.Visible;
                }
            }
            else if (ve[0] is TextBox)
            {
                TextBox control = ve[0] as TextBox;
                control.Clear();
            }
         
        }

        private void passwordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (passwordBox.SecurePassword.Length > 0) { 
                PasswordClear.Visibility = Visibility.Visible;
                txtPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                txtPassword.Visibility = Visibility.Visible ;
            }
            
        }

        private void Email_Loaded(object sender, RoutedEventArgs e)
        {
           ( sender as TextBox).Focus();
        }        
    }
}
