using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Windows;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ForgotPassword.xaml
    /// </summary>
    public partial class ForgotPasswordView : ViewBase
    {
        public ForgotPasswordView()
        {
            InitializeComponent();            
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.GetNew<ForgotPasswordViewModel>();
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
                }
            }
            else if (ve[0] is TextBox)
            {
                TextBox control = ve[0] as TextBox;
                control.Clear();
            }

        }
       

        private void Email_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Focus();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int count = passwordBox.SecurePassword.Length;
            if(count == 0)
            {
                PasswordClear.Visibility = Visibility.Collapsed;
                PasswordLabel.Visibility = Visibility.Visible;
            }
            else
            {
                PasswordClear.Visibility = Visibility.Visible;
                PasswordLabel.Visibility = Visibility.Hidden;

            }

        }

        private void ConfirmpasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int count = ConfirmpasswordBox.SecurePassword.Length;
            if (count == 0)
            {
                ConfirmPasswordClear.Visibility = Visibility.Collapsed;
                ConfirmPasswordLabel.Visibility = Visibility.Visible;
            }
            else
            {
                ConfirmPasswordClear.Visibility = Visibility.Visible;
                ConfirmPasswordLabel.Visibility = Visibility.Hidden;

            }
        }     

        private void passwordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int count = passwordBox.SecurePassword.Length;
            if (count == 0)
            {
                PasswordLabel.Visibility = Visibility.Visible;
            }
        }
        private void ConfirmpasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            int count = ConfirmpasswordBox.SecurePassword.Length;
            if (count == 0)
            {
                ConfirmPasswordLabel.Visibility = Visibility.Visible;
            }
        }
    }
}
