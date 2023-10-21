﻿using RTH.Business.Objects;
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
    /// Interaction logic for HealthAgendaView.xaml
    /// </summary>
    public partial class HealthAgendaView : ViewBase
    {
        public HealthAgendaView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.GetNew<HealthAgendaViewModel>();
            this.RefreshOnLoad = true;
            base.LoadViewModel();
        }

        public override void OnViewLoaded()
        {
            if (this.ActualHeight == 446)
            {
                this.Background = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FFDEF3FB");
                continueButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.Background = Brushes.White;
            }
            base.OnViewLoaded();
        }

        private RelayCommand<object[]> m_NextStepCommand;
        public RelayCommand<object[]> NextStepCommand
        {
            get
            {
                return m_NextStepCommand ?? (m_NextStepCommand = new RelayCommand<object[]>(
                    ve => NextSteps(ve), (t) => true));
            }
        }

        private void NextSteps(object[] ve)
        {
            if (ve != null)
            {
                Answer context = ve[0] as Answer;
                if (!string.IsNullOrEmpty(context.next_steps))
                {
                    StackPanel panel = ve[1] as StackPanel;
                    context.NextStepsData = App.SharedValues.LanguageResource.GetType().GetProperty(context.next_steps).ToString();
                    if (panel.Visibility == Visibility.Visible)
                        panel.Visibility = Visibility.Collapsed;
                    else
                        panel.Visibility = Visibility.Visible;

                }
            }
        }
    }
}
