﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Helpers;
using System;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for HealthReportView.xaml
    /// </summary>
    public partial class HealthReportView : ViewBase
    {
        public HealthReportView()
        {
            InitializeComponent();
            LoadViewModel();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = new HealthReportViewModel();
            base.LoadViewModel();
        }
        private RelayCommand m_EmailReport;
        public RelayCommand EmailReportCommand
        {
            get
            {
                return m_EmailReport ?? (m_EmailReport = new RelayCommand(
                    ve => ExecuteEmailReport(), (t) => true));
            }
        }

        private async void ExecuteEmailReport()
        {

            HealthReportViewModel oHealthReportViewModel = this.ViewModel as HealthReportViewModel;
            var report = await oHealthReportViewModel.SendReportEmail();
            MessageBoxResult result = QuealthMessageBox.ShowInformation(App.SharedValues.LanguageResource.health_report_sent_successfully, "", showCancel: false);
            if (result == MessageBoxResult.OK)
            {
                if (UIHelper.FindParent<DialogWindow>(this) != null)
                    UIHelper.FindParent<DialogWindow>(this).CloseDialog.Execute(null);
            }
        }
    }
}
