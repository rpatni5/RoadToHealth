using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for uc_UserRegistration.xaml
    /// </summary>
    public partial class UserRegistrationView : ViewBase
    {
        public UserRegistrationView()
        {
            InitializeComponent();
            ViewModel.PropertyChanged += ViewModel_PropertyChanged;
        }
        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var vm = sender as UserRegistrationViewModel;
            if (e.PropertyName == "ErrorMessage" && !string.IsNullOrEmpty(vm.ErrorMessage))
            {
                Dispatcher.BeginInvoke((Action)(() =>
                {
                    sbRegistration.ScrollToHome();
                }));
            }
        }



        public bool IsSocialUser
        {
            get { return (bool)GetValue(IsSocialUserProperty); }
            set { SetValue(IsSocialUserProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSocialUser.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSocialUserProperty =
            DependencyProperty.Register("IsSocialUser", typeof(bool), typeof(UserRegistrationView), new PropertyMetadata(false));


        public void SetPrimaryData()
        {
            if (ViewModelBase.UserDetails!=null && !string.IsNullOrEmpty(ViewModelBase.UserDetails.type) && ViewModelBase.UserDetails.type != Configurations.NORMAL_USER_TYPE)
            {                
                (this.ViewModel as UserRegistrationViewModel).email = ViewModelBase.UserDetails.email;
                IsSocialUser = true;
            }
            else
            {
                IsSocialUser = false;
            }   
            this.ViewModel.ErrorMessage = ViewModelBase.Errors;
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<UserRegistrationViewModel>();
            base.LoadViewModel();
        }

        public int PasswordStrength
        {
            get { return (int)GetValue(PasswordStrengthProperty); }
            set { SetValue(PasswordStrengthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PasswordStrength.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordStrengthProperty =
            DependencyProperty.Register("PasswordStrength", typeof(int), typeof(UserRegistrationView), new PropertyMetadata(0));



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


        private void password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int count = password.SecurePassword.Length;
            PasswordClear.Visibility = count == 0 ? Visibility.Collapsed : Visibility.Visible;
            txtPassword.Visibility= count == 0 ? Visibility.Visible : Visibility.Collapsed;
            if (count <= 4 && count > 0)
                PasswordStrength = 1;
            else if (count < 6 && count > 4)
                PasswordStrength = 2;
            else if (count >= 6)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(password.Password, @"^(?=(?=.*\d){1,})(?=.*[a-z])(?=.*[^a-zA-Z\d]).{6,}$"))
                {
                    PasswordStrength = 4;
                }
                else if (System.Text.RegularExpressions.Regex.IsMatch(password.Password, @"^(?=.*[a-z])(?=(.*[^a-zA-Z\d])|(?=.*\d){1,}).{6,}$"))
                {
                    PasswordStrength = 3;
                }

            }
            else {
                PasswordStrength = 0;
            }
        }

        private void FullName_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as TextBox).Focus();
        }

        private void HandlePreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is PasswordBox && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        private void confirm_PasswordChanged(object sender, RoutedEventArgs e)
        {
            int count = confirm.SecurePassword.Length;
            ConfirmPasswordClear.Visibility = count == 0 ? Visibility.Collapsed : Visibility.Visible;
            txtCPassword.Visibility = count == 0 ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
