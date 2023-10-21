﻿using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for us_Dashboard.xaml
    /// </summary>
    public partial class DashboardView : ViewBase, ITutorialHost
    {
        #region properties

        private RelayCommand m_LoadTimeLine;
        public RelayCommand LoadTimeLine
        {
            get
            {
                return m_LoadTimeLine ?? (m_LoadTimeLine = new RelayCommand(
                    ve => OnLoadTimeLine(ve), (t) => true));
            }
        }



        private void OnLoadTimeLine(object ve)
        {
            var diseaseData = SummeryContainer.DataContext as DiseaseData;
            diseaseData.IsChecked = false;
            //SwitchRightControl(true);
            SwitchRightControl(false);
        }
        #endregion
        public object Summarydisease { get; set; }
        private bool IsLoaded = false;
        DashboardViewModel dashboardViewModel;
        public DashboardView()
        {
            InitializeComponent();
            ViewModelBase.UserDetails.Securepwd = Properties.Settings.Default.SecurePwd;
            qStoryboard = new Storyboard();
            DBContextMenu.ItemsSource = App.SharedValues.WindowMain.QuealthMenuItems;
        }
        public override void LoadViewModel()
        {
            if (Properties.Settings.Default.SecurePwd.Length > 0)
            {
                ViewModelBase.UserDetails.Securepwd = Properties.Settings.Default.SecurePwd;
            }
            dashboardViewModel = ViewModelLocator.Get<DashboardViewModel>(refreshRequired: true);
            this.ViewModel = dashboardViewModel;
            this.RefreshOnLoad = true;
            base.LoadViewModel();
        }
        private void DiseaseButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton button = sender as RadioButton;
            DiseaseData diseaseData = (DiseaseData)button.DataContext;

            RedoContainer.DataContext = button.DataContext;
            if (diseaseData.IsCompleted == HRAStatusEnum.NotCompleted)
            {
                SummeryContainer.DataContext = button.DataContext;
                App.SharedValues.WindowMain.HeaderMenu.HideMenu();
                ViewModelBase.ExecuteTrackNavigation("DashboardView", diseaseData.KeyString + "-intro", 1);
                if (SummeryContainer.Visibility == Visibility.Collapsed)
                {
                    SwitchRightControl(false);
                }
                else
                {
                    SetGoButtonTutorial();
                }

            }
            else if (diseaseData.IsCompleted == HRAStatusEnum.Completed)
            {
                double leftPosition, topPosition;
                if (timelineContainer.Visibility == Visibility.Collapsed)
                {
                    //SwitchRightControl(true);
                    //SwitchRightControl(false);
                }

                button.IsChecked = false;
                if (SummeryContainer.DataContext != null)
                {
                    (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.ID == ((DiseaseData)SummeryContainer.DataContext).ID).IsChecked = true;
                }
                if (diseaseData.KeyString == "lung" || diseaseData.KeyString == "dementia")
                {
                    leftPosition = 14;
                    topPosition = 60;
                }
                else
                {
                    leftPosition = 88.0;
                    topPosition = 40;
                }

                if (RedoPopup.IsOpen)
                {
                    RedoPopup.IsOpen = false;
                    App.SharedValues.WindowMain.Opacity = 1;
                }
                else
                {
                    RedoPopup.PlacementTarget = button;
                    StartPopUpAnimation(leftPosition, topPosition);
                    App.SharedValues.WindowMain.Opacity = .5;
                    RedoPopup.IsOpen = true;
                }
            }
            else if (diseaseData.IsCompleted == HRAStatusEnum.Redo)
            {
                App.SharedValues.WindowMain.ViewHRACommand.Execute(diseaseData);
            }
        }
        private void SwitchRightControl(bool ShowTimeLine)
        {
            var actWidth = RightPanel.ActualWidth;
            var thickness1 = new Thickness(0, 0, -actWidth, 0);
            var thickness2 = new Thickness(actWidth, 0, 0, 0);
            var thickness3 = new Thickness(-actWidth, 0, 0, 0);

            var thickness0 = new Thickness(0, 0, 0, 0);

            var sb = new Storyboard();
            var duration = TimeSpan.FromSeconds(0.8);

            var daFadeIn = new DoubleAnimation(0, 1, duration, FillBehavior.HoldEnd);
            var daFadeOut = new DoubleAnimation(1, 0, duration, FillBehavior.HoldEnd);
            var daSlideOut = new ThicknessAnimation(thickness0, thickness2, duration, FillBehavior.HoldEnd);
            var daSlideIn = new ThicknessAnimation(thickness1, thickness0, duration, FillBehavior.HoldEnd);

            daFadeIn.SetCurrentValue(Storyboard.TargetPropertyProperty, new PropertyPath("Opacity"));
            daFadeOut.SetCurrentValue(Storyboard.TargetPropertyProperty, new PropertyPath("Opacity"));
            daSlideIn.SetCurrentValue(Storyboard.TargetPropertyProperty, new PropertyPath("Margin"));
            daSlideOut.SetCurrentValue(Storyboard.TargetPropertyProperty, new PropertyPath("Margin"));

            if (ShowTimeLine) //R => L : RED
            {
                timelineContainer.Visibility = System.Windows.Visibility.Visible;
                daFadeIn.SetCurrentValue(Storyboard.TargetProperty, timelineContainer);
                daFadeOut.SetCurrentValue(Storyboard.TargetProperty, SummeryContainer);
                daSlideIn.SetCurrentValue(Storyboard.TargetProperty, timelineContainer);
                daSlideOut.SetCurrentValue(Storyboard.TargetProperty, SummeryContainer);
                daSlideOut.To = thickness3;

                sb.Completed += (o, ea) => SummeryContainer.Visibility = Visibility.Collapsed;
            }
            else //L => R : BLUE
            {
                SummeryContainer.Visibility = Visibility.Visible;
                daFadeIn.SetCurrentValue(Storyboard.TargetProperty, SummeryContainer);
                daFadeOut.SetCurrentValue(Storyboard.TargetProperty, timelineContainer);
                daSlideIn.SetCurrentValue(Storyboard.TargetProperty, SummeryContainer);
                daSlideOut.SetCurrentValue(Storyboard.TargetProperty, timelineContainer);
                daSlideOut.To = daSlideIn.From; daSlideIn.From = thickness3;
                sb.Completed += (o, ea) =>
                {
                    timelineContainer.Visibility = Visibility.Collapsed;
                    SetGoButtonTutorial();
                };
            }

            sb.Children.Add(daFadeIn);
            sb.Children.Add(daFadeOut);
            sb.Children.Add(daSlideIn);
            sb.Children.Add(daSlideOut);
            sb.Begin();
        }
        private void RedoPopup_Closed(object sender, EventArgs e)
        {
            if (App.SharedValues.WindowMain != null)
                App.SharedValues.WindowMain.Opacity = 1;

            //btnResult.BeginAnimation(Canvas.TopProperty, null);
            //btnResult.BeginAnimation(Canvas.LeftProperty, null);
            btnRedo.BeginAnimation(Canvas.LeftProperty, null);
            btnRedo.BeginAnimation(Canvas.TopProperty, null);

            //btnResult.SetValue(Canvas.TopProperty, 80.0);
            btnRedo.SetValue(Canvas.LeftProperty, 50.0);
            btnRedo.SetValue(Canvas.LeftProperty, 50.0);
            btnRedo.SetValue(Canvas.TopProperty, 80.0);
        }
        Storyboard qStoryboard = null;
        private void StartPopUpAnimation(double leftPosition, double topPosition)
        {
            //var daCanvasTop1 = new DoubleAnimation(80, 14, TimeSpan.FromSeconds(0.3));
            //daCanvasTop1.BeginTime = TimeSpan.FromSeconds(0.1);
            //Storyboard.SetTarget(daCanvasTop1, btnResult);
            //Storyboard.SetTargetProperty(daCanvasTop1, new PropertyPath("(Canvas.Top)"));

            //var daCanvasLeft1 = new DoubleAnimation(50, topPosition, TimeSpan.FromSeconds(0.3));
            //daCanvasLeft1.BeginTime = TimeSpan.FromSeconds(0.1);
            //Storyboard.SetTarget(daCanvasLeft1, btnResult);
            //Storyboard.SetTargetProperty(daCanvasLeft1, new PropertyPath("(Canvas.Left)"));

            var daCanvasTop2 = new DoubleAnimation(80, 27, TimeSpan.FromSeconds(0.3));
            daCanvasTop2.BeginTime = TimeSpan.FromSeconds(0.1);
            Storyboard.SetTarget(daCanvasTop2, btnRedo);
            Storyboard.SetTargetProperty(daCanvasTop2, new PropertyPath("(Canvas.Top)"));

            var daCanvasLeft = new DoubleAnimation(50, leftPosition, TimeSpan.FromSeconds(0.3));
            daCanvasLeft.BeginTime = TimeSpan.FromSeconds(0.1);
            Storyboard.SetTarget(daCanvasLeft, btnRedo);
            Storyboard.SetTargetProperty(daCanvasLeft, new PropertyPath("(Canvas.Left)"));

            //qStoryboard.Children.Add(daCanvasTop1);
            //qStoryboard.Children.Add(daCanvasLeft1);
            qStoryboard.Children.Add(daCanvasTop2);
            qStoryboard.Children.Add(daCanvasLeft);
            qStoryboard.Begin();
        }
        public override void OnMessage(Message e)
        {
            if (e.Type == MessageType.AnimateHRA)
            {
                MainScore.StartQAnimation();
            }
            else if (e.Type == MessageType.RefreshComplete)
            {
                if (!IsLoaded)
                {
                    IsLoaded = true;
                    if ((this.ViewModel as DashboardViewModel).OverLayVisibility)
                    {
                        chatControl.ChatStrat(OnChatComplete);
                    }
                    else
                    {
                        rightPanel.SetValue(VisibilityProperty, Visibility.Visible);
                        rightPanel.SetValue(MarginProperty, new Thickness(0));
                    }
                }
                if (Summarydisease == null)
                {
                    if ((this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted) != null)
                    {
                        (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted).IsChecked = true;
                        SummeryContainer.DataContext = (this.ViewModel as DashboardViewModel).Disease;
                    }
                }
                else
                {
                    if ((this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted) != null)
                    {
                        (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.ID == ((DiseaseData)Summarydisease).ID).IsChecked = true;
                        (this.ViewModel as DashboardViewModel).Disease = (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.ID == ((DiseaseData)Summarydisease).ID);
                        SummeryContainer.DataContext = (this.ViewModel as DashboardViewModel).Disease;
                    }
                    Summarydisease = null;
                }

                DiseaseContainer.IsEnabled = BtnGo.IsEnabled = btnRedo.IsEnabled = true;
                if (HasShowTutorials())
                {
                    if (TutorialHelper.CoachesTutorial.ShowTutorial())
                    {
                        //App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.ShowCoaches, param: true);
                        DialogWindow coachesWindow = new DialogWindow(Enums.ViewEnum.ShowCoaches);
                        TutorialHelper.TutorialComplete(TutorialHelper.CoachesTutorial);
                        coachesWindow.ShowInTaskbar = false;
                        coachesWindow.Owner = Application.Current.MainWindow;
                        coachesWindow.ShowDialog();
                    }

                    DiseaseData diseaseData = (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.Completed);
                    if (diseaseData != null)
                    {
                        AddTutorialToList(TutorialHelper.ShareIcon, App.SharedValues.WindowMain.ShareButton);
                        AddTutorialToList(TutorialHelper.HealthReportIcon, App.SharedValues.WindowMain.ReportButton);
                    }
                    //AddTutorialToList(TutorialHelper.CreateHealthPlanIcon, btnHealthPlan);
                    if (diseaseData != null)
                    {
                        AddTutorialToList(TutorialHelper.DiseaseIcon, null);
                        //AddTutorialToList(TutorialHelper.DashboardTab, App.SharedValues.WindowMain.footerContainer.rdoHome);
                        //AddTutorialToList(TutorialHelper.InsightTab, App.SharedValues.WindowMain.footerContainer.rdoRight);
                        //AddTutorialToList(TutorialHelper.AdviceTab, App.SharedValues.WindowMain.footerContainer.rdoMiddle);
                        //AddTutorialToList(TutorialHelper.ScoreTab, App.SharedValues.WindowMain.footerContainer.rdoLeft);
                    }
                    if ((this.ViewModel as DashboardViewModel).TotalHRA > 1)
                    {
                        AddTutorialToList(TutorialHelper.MainScore, this.MainScore.HRAEllipse);
                    }

                    this.SetValue(ShowTutorialProperty, true);

                }
            }
        }


        #region Tutorials

        Dictionary<int, Tuple<string, FrameworkElement>> tutorialObjects;
        public void InitializeTutorials()
        {
            tutorialObjects = new Dictionary<int, Tuple<string, FrameworkElement>>();
            AddTutorialToList(TutorialHelper.DiseaseIcons, this.DiseaseContainer);
            AddTutorialToList(TutorialHelper.MenuIcon, App.SharedValues.WindowMain.HeaderMenu.tbtnExp);
            AddTutorialToList(TutorialHelper.Timeline, timelineContainer);
        }
        public override void OnViewLoaded()
        {
            //DiseaseContainer.IsEnabled = BtnGo.IsEnabled = btnRedo.IsEnabled = btnResult.IsEnabled = false;
            DiseaseContainer.IsEnabled = BtnGo.IsEnabled = btnRedo.IsEnabled = false;
            InitializeTutorials();
            if (Summarydisease != null)
            {
                SummeryContainer.DataContext = Summarydisease;
                (this.ViewModel as DashboardViewModel).Diseases.FirstOrDefault(x => x.ID == ((DiseaseData)Summarydisease).ID).IsChecked = true;
            }
            BtnGo.IsChecked = false;
            SetTimerForMotivation();
        }

        private bool OnChatComplete()
        {
            rightPanel.SetValue(VisibilityProperty, Visibility.Visible);
            Storyboard qSB = new Storyboard();
            ThicknessAnimation da = new ThicknessAnimation(new Thickness(0, 600, 0, 0), new Thickness(0, 0, 0, 0), TimeSpan.FromSeconds(1.0));
            Storyboard.SetTarget(da, RightPanel);
            Storyboard.SetTargetProperty(da, new PropertyPath(Border.MarginProperty));
            qSB.Children.Add(da);
            qSB.Begin();
            return true;
        }

        int currentTutIndex = 0;
        public override TutorialContent GetTutorials()
        {
            if (currentTutIndex >= this.MaxTutorials)
            {
                currentTutIndex = 0;
                tutorialObjects.Clear();
                ShowTutorial = false;
                return null;
            }
            var tuple = tutorialObjects[currentTutIndex++];
            if (tuple.Item1.ShowTutorial())
            {

                tuple.Item1.TutorialComplete();
                if (tuple.Item2 == null)
                {
                    var item = DiseaseContainer.Items.Cast<DiseaseData>().First(x => x.IsCompleted == HRAStatusEnum.Completed);
                    return (DiseaseContainer.ItemContainerGenerator.ContainerFromItem(item) as ContentPresenter).GetTutorial(this, tuple.Item1, true);
                }
                return tuple.Item2.GetTutorial(this, tuple.Item1, true);
            }
            ShowTutorial = false;
            return null;
        }
        public int MaxTutorials
        {
            get
            {
                return tutorialObjects.Count;
            }
        }

        public int GetTutorialIndex()
        {
            return currentTutIndex;
        }
        public string GetTutorialText(string keyString)
        {
            if (App.SharedValues.LanguageResource.GetType().GetProperty(keyString) != null)
            {
                return App.SharedValues.LanguageResource.GetType().GetProperty(keyString).GetValue(App.SharedValues.LanguageResource).ToString();
            }
            return string.Empty;

        }
        private void SetGoButtonTutorial()
        {
            AsyncCall.Invoke(() =>
            {
                if (HasShowTutorials())
                {
                    Thread.Sleep(100);
                    AddTutorialToList(TutorialHelper.GoIcon, BtnGo);
                    Dispatcher.Invoke(() => { this.SetValue(ShowTutorialProperty, true); });
                }
            }, showLoader: false);
        }
        private bool HasShowTutorials()
        {
            return Properties.Settings.Default.Tutorials;
        }
        private bool AddTutorialToList(string keyString, FrameworkElement element)
        {
            if (TutorialHelper.ShowTutorial(keyString))
            {
                tutorialObjects.Add(tutorialObjects.Count, new Tuple<string, FrameworkElement>(keyString, element));
                return true;
            }
            return false;
        }
        public override void SkipTutorials()
        {
            string[] keys;
            if ((this.ViewModel as DashboardViewModel).TotalHRA > 1)
            {
                keys = new string[] { TutorialHelper.DiseaseIcons, TutorialHelper.MenuIcon, TutorialHelper.Timeline, TutorialHelper.GoIcon, TutorialHelper.MainScore, TutorialHelper.ShareIcon, TutorialHelper.HealthReportIcon, TutorialHelper.CreateHealthPlanIcon, TutorialHelper.DiseaseIcon, TutorialHelper.DashboardTab, TutorialHelper.InsightTab, TutorialHelper.AdviceTab, TutorialHelper.ScoreTab };

            }
            else if ((this.ViewModel as DashboardViewModel).TotalHRA == 1)
            {
                keys = new string[] { TutorialHelper.DiseaseIcons, TutorialHelper.MenuIcon, TutorialHelper.Timeline, TutorialHelper.GoIcon, TutorialHelper.ShareIcon, TutorialHelper.HealthReportIcon, TutorialHelper.CreateHealthPlanIcon, TutorialHelper.DiseaseIcon, TutorialHelper.DashboardTab, TutorialHelper.InsightTab, TutorialHelper.AdviceTab, TutorialHelper.ScoreTab };
            }
            else
            {
                keys = new string[] { TutorialHelper.DiseaseIcons, TutorialHelper.MenuIcon, TutorialHelper.Timeline, TutorialHelper.GoIcon };
            }
            TutorialHelper.SkipTutorials(keys);
            this.SetValue(ShowTutorialProperty, false);
        }

        #endregion Tutorials

        private void ViewBase_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if ((this.ViewModel as DashboardViewModel).OverLayVisibility)
            {
                chatControl.MoveNext(OnChatComplete);
            }
        }
        private RelayCommand m_ItemCommand;

        public RelayCommand ItemCommand
        {
            get
            {
                return m_ItemCommand ?? (m_ItemCommand = new RelayCommand(
                    ve => Move(ve), (t) => true));
            }
        }

        private void Move(object ve)
        {
            if (ve != null)
            {
                dashboardViewModel.Move(false, true, (int)ve);
                if (dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted) != null)
                {
                    dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted).IsChecked = true;
                    SummeryContainer.DataContext = dashboardViewModel.Disease;
                }
            }
        }

        private void Btn_next_Click(object sender, RoutedEventArgs e)
        {
            dashboardViewModel.Move(true);
            if (dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted) != null)
            {
                dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted).IsChecked = true;
                SummeryContainer.DataContext = dashboardViewModel.Disease;
            }
        }

        private void Btn_previes_Click(object sender, RoutedEventArgs e)
        {
            dashboardViewModel.Move(false);
            if (dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted) != null)
            {
                dashboardViewModel.Diseases.FirstOrDefault(x => x.IsCompleted == HRAStatusEnum.NotCompleted).IsChecked = true;
                SummeryContainer.DataContext = dashboardViewModel.Disease;
            }
        }
        private DispatcherTimer _tmrMain = new DispatcherTimer();
        private void SetTimerForMotivation()
        {
            _tmrMain.Interval = new TimeSpan(0, 0, 4);
            _tmrMain.Tick += new EventHandler(AutoMotivationMove);
            _tmrMain.Start();
        }

        private void AutoMotivationMove(object sender, EventArgs e)
        {
            if (dashboardViewModel.Motivations != null && dashboardViewModel.Motivations.Count > 1)
            {
                MotivationMove();
            }
        }

        private void Btn_next_Click_1(object sender, RoutedEventArgs e)
        {
            MotivationMove();
        }
        private void MotivationMove()
        {
            int index = dashboardViewModel.Motivations.IndexOf(dashboardViewModel.CurrentMotivation); ;
            dashboardViewModel.Motivations.FirstOrDefault(x => x.RowNo == dashboardViewModel.CurrentMotivation.RowNo).IsPressed = false;
            if (index < (dashboardViewModel.Motivations.Count - 1))
            {
                transition.Transition = Transition.Left;
                dashboardViewModel.Motivations[index + 1].IsPressed = true;
                dashboardViewModel.CurrentMotivation = dashboardViewModel.Motivations[index + 1];
            }
            else
            {
                transition.Transition = Transition.Right;
                dashboardViewModel.Motivations[0].IsPressed = true;
                dashboardViewModel.CurrentMotivation = dashboardViewModel.Motivations[0];
            }
        }


    }
}
