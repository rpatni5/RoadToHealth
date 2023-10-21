﻿using RTH.Windows.ViewModels;
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
    /// Interaction logic for UserRegistrationProfileView.xaml
    /// </summary>
    public partial class UserRegistrationProfileView : ViewBase
    {
        public UserRegistrationProfileView()
        {
            InitializeComponent();
           
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.GetNew<UserRegistrationProfileViewModel>();
            base.LoadViewModel();
        }
        public override void OnViewLoaded()
        {
            DateAnswer.DisplayDateEnd = DateTime.Now.AddYears(-22);
            base.OnViewLoaded();            
        }
        private void DateAnswer_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void DateAnswer_CalendarOpened(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Today.AddYears(-20);
            DateAnswer.Text = dt.ToString();
        }
    }
}
