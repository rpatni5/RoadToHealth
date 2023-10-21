﻿using RTH.Helpers;
using RTH.Helpers.Exceptions;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.Objects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for QuestionNavigatorView.xaml
    /// </summary>
    public partial class QuestionNavigatorView : ViewBase, ITutorialHost
    {
        public QuestionNavigatorView()
        {
            InitializeComponent();
            Loaded += OnViewLoaded;
        }
        public override void LoadViewModel()
        {
            if (App.IsOnline())
            {
                App.Current.MainWindow.Opacity = 1;
            }
            else
            {
                throw new CachedObjectNotFoundException("You are not connected to internet. Please try again later.");
            }
            this.ViewModel = ViewModelLocator.Get<QuestionNavigatorViewModel>();
            base.LoadViewModel();
        }

        private bool submitted = false;
        public override bool CanUnload()
        {
            if (!submitted && App.IsOnline())
            {
                MessageBoxResult result = QuealthMessageBox.ShowWarning(
                    App.SharedValues.LanguageResource.hra_warning_message,
                    "",
                    showCancel: true, options: MessageBoxOptions.None);
                //App.SharedValues.LanguageResource.warning
                if (result == MessageBoxResult.Cancel)
                {
                    return false;
                }

            }
            return true;
        }
        private void OnViewLoaded(object sender, RoutedEventArgs e)
        {
            InitializeTutorials();
        }


        #region Continue button
        private RelayCommand continueCommand;
        private RelayCommand m_ShowQuestionHelperCommand;
        private RelayCommand m_CategoryChangeCommand;

        public RelayCommand ContinueCommand
        {
            get
            {
                return continueCommand ?? (continueCommand = new RelayCommand(
                    vm => ExecuteContinueCommand(vm), (vm) =>
                    {
                        return true;
                    }));
            }
        }

        public async void ExecuteContinueCommand(object obj)
        {
            transition.Transition = Transition.LeftWithFade;
            if (questionHelperControl != null) questionHelperControl.LoadControl(null, Controls.Transition.Right);
            QuestionNavigatorViewModel vm = obj as QuestionNavigatorViewModel;
            string QuestionSubmitted = await vm.MoveToQuestion(1, Properties.Settings.Default.SecurePwd);
            submitted = false;
            if (QuestionSubmitted == HRASubmit.Completed.ToString())
            {
                if (GlobalData.Default.ClickedHRA.type != 4)
                {
                    RunScoreAnimation();
                }
                else
                {
                    RunLifestyleAnimation();
                }
                this.ViewModel.HeaderVisibility = false;
                qGrid.Visibility = Visibility.Collapsed;
                cv.Visibility = Visibility.Visible;
                submitted = true;
            }
            if (QuestionSubmitted == HRASubmit.ServiceError.ToString())
            {
                submitted = true;
                MessageBoxResult result = QuealthMessageBox.ShowInformation(
                   "Missing Data", "", showCancel: false, options: MessageBoxOptions.None);
                if (result == MessageBoxResult.OK)
                {
                    App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.DashboardView, param: true);
                }
            }
            transition.Transition = Transition.Fade;

        }

        private void RunLifestyleAnimation()
        {
            cv.Background = (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FF9D9D9E"); ;
            diseaseName.SetValue(Canvas.LeftProperty, cv.ActualWidth / 2 - diseaseName.ActualWidth / 2);
            diseaseName.SetValue(Canvas.TopProperty, cv.ActualHeight / 2 - 50);
            qScore.Text = "Assesment is complete";
            qScore.Visibility = Visibility.Visible;
            qScore.SetValue(Canvas.LeftProperty, cv.ActualWidth / 2 - qScore.ActualWidth+40);
            qScore.SetValue(Canvas.TopProperty, cv.ActualHeight / 2);

            diseaseName.Visibility = Visibility.Visible;
            qScore.Visibility = Visibility.Visible;
            RunBubbleAnimation();
        }



        #endregion
        #region Next Button
        private RelayCommand nextCommand;

        public RelayCommand NextCommand
        {
            get
            {
                return nextCommand ?? (nextCommand = new RelayCommand(
                    vm => ExecuteContinueCommand(vm), (vm) =>
                    {
                        QuestionNavigatorViewModel v = vm as QuestionNavigatorViewModel;
                        if (
                        v != null &&
                        v.CurrentQuestion != null &&
                        v.CurrentQuestion.HasErrors)
                        {
                            v.CurrentQuestion.ErrorMessage = ViewModelBase.AppMessages.missing_answer;
                            return false;
                        }
                        return true;
                    }));
            }
        }

        #endregion
        #region Previous Button
        private RelayCommand previousCommand;

        public RelayCommand PreviousCommand
        {
            get
            {
                return previousCommand ?? (previousCommand = new RelayCommand(
                    vm => ExecutePreviousCommand(vm), (vm) => true));
            }
        }

        private void ExecutePreviousCommand(object obj)
        {
            transition.Transition = Transition.RightWithFade;
            if (questionHelperControl != null) questionHelperControl.LoadControl(null, Controls.Transition.Right);
            QuestionNavigatorViewModel vm = obj as QuestionNavigatorViewModel;
            vm.MoveToQuestionPrevious(-1);
            transition.Transition = Transition.Fade;
        }
        #endregion
        #region Category Change
        public RelayCommand CategoryChangeCommand
        {
            get
            {
                return m_CategoryChangeCommand ?? (m_CategoryChangeCommand = new RelayCommand(
                    vm => ExecuteCategoryChangeCommand(vm), (vm) =>
                    {
                        return true;
                    }));
            }
        }

        private void ExecuteCategoryChangeCommand(object vm)
        {
            if (questionHelperControl != null) questionHelperControl.LoadControl(null, Controls.Transition.Right);
            QuestionNavigatorViewModel oQuestionNavigatorViewModel = this.DataContext as QuestionNavigatorViewModel;
            oQuestionNavigatorViewModel.LoadCategoryQuestion((string)vm, Properties.Settings.Default.SecurePwd);
            //var a = vm;

        }
        #endregion

        public RelayCommand ShowQuestionHelperCommand
        {
            get
            {
                return m_ShowQuestionHelperCommand ?? (m_ShowQuestionHelperCommand = new RelayCommand(
                    ve => ShowQuestionHelper(ve), (t) => true));
            }
        }
        AnimatedContentControl questionHelperControl;
        private void ShowQuestionHelper(object ve)
        {
            //ic_clear_ev

            questionHelperControl = ve as AnimatedContentControl;
            QuestionNavigatorViewModel vm = DataContext as QuestionNavigatorViewModel;
            if (!vm.CurrentQuestion.summary.Contains("<img") && vm.CurrentQuestion.helper_image != string.Empty)
            {
                string path = Config.ApiUrl + @"uploads/questions_helper/" + vm.CurrentQuestion.helper_image;
                vm.CurrentQuestion.summary = string.Format("<strong> {2}</strong> <br/> <img height='150' width='360' src ='{0}'/>{1}", path, vm.CurrentQuestion.summary, vm.CurrentQuestion.helper_title);
            }
            if (!questionHelperControl.HasContent)
            {
                var htmlPanel = new HtmlPanel();
                htmlPanel.SetBinding(HtmlPanel.HtmlProperty, new Binding("summary") { Source = vm.CurrentQuestion });
                questionHelperControl.LoadControl(htmlPanel);
            }
            else
            {
                questionHelperControl.LoadControl(null, Controls.Transition.Right);
            }
            if (vm.SourceHelperImage.OriginalString.Equals(@"/RTH.Windows.Views;component/Assets/cross_window_sml.png"))
            {
                vm.SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/info_icon.png", UriKind.Relative);

            }
            else
            {
                vm.SourceHelperImage = new Uri(@"/RTH.Windows.Views;component/Assets/cross_window_sml.png", UriKind.Relative);
            }
        }

        private void transition_ContentAnimated(object sender)
        {
            var control = sender as AnimatedContentControl;
            IInputElement element = FocusManager.GetFocusedElement(control);
            if (element != null)
            {
                FocusManager.SetFocusedElement(grdFocusedScope, element);
            }
            else
            {
                grdFocusedScope.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }
            if (Properties.Settings.Default.Tutorials && ((QuestionNavigatorViewModel)this.ViewModel).QuestionnaireCompleted)
            {
                this.SetValue(ShowTutorialProperty, true);
            }
        }





        private void RunScoreAnimation()
        {
            qScore.Text = "Quealth Score";
            diseaseName.Visibility = Visibility.Visible;
            qScore.Visibility = Visibility.Visible;
            riskButton.Visibility = Visibility.Visible;
            TotalScoreText.SetValue(Canvas.LeftProperty, cv.ActualWidth / 2 - TotalScoreText.ActualWidth / 2);
            TotalScoreText.Visibility = Visibility.Visible;
            var storyboard = new Storyboard();
            var rnd = new Random();
            var daTop = new DoubleAnimation(cv.ActualHeight, 250, TimeSpan.FromSeconds(1.2));
            var daContent = new DoubleAnimation(0, (this.ViewModel as QuestionNavigatorViewModel).Score, TimeSpan.FromSeconds(1.2));
            var daOpacity = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1.2))
            {
                BeginTime = TimeSpan.FromSeconds(1),
                EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 20, EasingMode = EasingMode.EaseOut }
            };


            var daDiseaseLeft = new DoubleAnimation(cv.Width, cv.Width / 2 - diseaseName.ActualWidth / 2, TimeSpan.FromSeconds(1.2)) { BeginTime = TimeSpan.FromSeconds(1.2) };
            var daScoreLeft = new DoubleAnimation(cv.Width, cv.Width / 2 - qScore.ActualWidth / 2, TimeSpan.FromSeconds(1.2)) { BeginTime = TimeSpan.FromSeconds(1.2) };
            var daRiskLeft = new DoubleAnimation(cv.Width, cv.Width / 2 - riskButton.ActualWidth / 2, TimeSpan.FromSeconds(1.2)) { BeginTime = TimeSpan.FromSeconds(1.2) };

            Storyboard.SetTarget(daDiseaseLeft, diseaseName);
            Storyboard.SetTarget(daScoreLeft, qScore);
            Storyboard.SetTarget(daRiskLeft, riskButton);

            Storyboard.SetTargetProperty(daDiseaseLeft, new PropertyPath(("(Canvas.Left)")));
            Storyboard.SetTargetProperty(daScoreLeft, new PropertyPath(("(Canvas.Left)")));
            Storyboard.SetTargetProperty(daRiskLeft, new PropertyPath(("(Canvas.Left)")));

            Storyboard.SetTarget(daTop, TotalScoreText);
            Storyboard.SetTarget(daOpacity, TotalScoreText);
            Storyboard.SetTarget(daContent, txtTransparent);

            Storyboard.SetTargetProperty(daTop, new PropertyPath(("(Canvas.Top)")));
            Storyboard.SetTargetProperty(daOpacity, new PropertyPath("Opacity"));
            Storyboard.SetTargetProperty(daContent, new PropertyPath("Width"));

            storyboard.Children.Add(daDiseaseLeft);
            storyboard.Children.Add(daScoreLeft);
            storyboard.Children.Add(daRiskLeft);

            storyboard.Children.Add(daTop);
            storyboard.Children.Add(daOpacity);
            storyboard.Children.Add(daContent);

            storyboard.Completed += StoryboardRunScoreAnimation_Completed; ;
            storyboard.Begin();
        }

        private void StoryboardRunScoreAnimation_Completed(object sender, EventArgs e)
        {
            RunBubbleAnimation();
        }

        private void RunBubbleAnimation()
        {
            var storyboard = new Storyboard();
            var rnd = new Random();
            var center = new Point(cv.ActualWidth / 2, cv.ActualHeight / 2);
            for (int i = 20; i < 300; i++)
            {
                var circle = new Ellipse() { Fill = Brushes.White, Opacity = 0 };

                var duration = TimeSpan.FromSeconds(5 * rnd.NextDouble());
                var beginTime = TimeSpan.FromSeconds(2 * rnd.NextDouble());

                var daLeft = new DoubleAnimation(center.X, cv.ActualWidth * rnd.NextDouble(), duration) { BeginTime = beginTime };
                var daTop = new DoubleAnimation(center.Y, cv.ActualHeight * rnd.NextDouble(), duration) { BeginTime = beginTime };
                var daHeight = new DoubleAnimation(0, 30, duration) { BeginTime = beginTime };
                var daWidth = new DoubleAnimation(0, 30, duration) { BeginTime = beginTime };
                var daOpacity = new DoubleAnimation(0, 0.3, duration, FillBehavior.Stop)
                {
                    BeginTime = beginTime,
                    EasingFunction = new ElasticEase { Oscillations = 1, Springiness = 20, EasingMode = EasingMode.EaseOut }
                };

                cv.Children.Add(circle);
                cv.Visibility = System.Windows.Visibility.Visible;

                Storyboard.SetTarget(daHeight, circle);
                Storyboard.SetTarget(daWidth, circle);
                Storyboard.SetTarget(daLeft, circle);
                Storyboard.SetTarget(daTop, circle);
                Storyboard.SetTarget(daOpacity, circle);

                Storyboard.SetTargetProperty(daOpacity, new PropertyPath("Opacity"));
                Storyboard.SetTargetProperty(daHeight, new PropertyPath("Height"));
                Storyboard.SetTargetProperty(daWidth, new PropertyPath("Width"));
                Storyboard.SetTargetProperty(daLeft, new PropertyPath("(Canvas.Left)"));
                Storyboard.SetTargetProperty(daTop, new PropertyPath("(Canvas.Top)"));

                storyboard.Children.Add(daHeight);
                storyboard.Children.Add(daWidth);
                storyboard.Children.Add(daLeft);
                storyboard.Children.Add(daTop);
                storyboard.Children.Add(daOpacity);
            }
            storyboard.Completed += storyboard_Completed;
            storyboard.Begin();
        }

        void storyboard_Completed(object sender, EventArgs e)
        {
            OnAnimationComplete();
        }

        private void OnAnimationComplete()
        {
            cv.Visibility = Visibility.Hidden;
            cv.Visibility = Visibility.Visible;

            if ((this.ViewModel as QuestionNavigatorViewModel).IsFirstHra())
            {
                App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.HealthAgendaView);
            }
            else
            {
                App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.ResultView);
            }

        }

        #region Tutorials

        Dictionary<int, Tuple<string, FrameworkElement>> tutorialObjects;
        public void InitializeTutorials()
        {

            tutorialObjects = new Dictionary<int, Tuple<string, FrameworkElement>>();
            if (TutorialHelper.ShowTutorial("questionnaire_tutorial_windows"))
            {
                tutorialObjects.Add(tutorialObjects.Count, new Tuple<string, FrameworkElement>("questionnaire_tutorial_windows", icQuestions));
            }

        }

        int currentTutIndex = 0;
        public override TutorialContent GetTutorials()
        {
            if (currentTutIndex >= this.MaxTutorials)
            {
                ShowTutorial = false;
                return null;
            }
            var tuple = tutorialObjects[currentTutIndex++];

            if (tuple.Item1.ShowTutorial())
            {
                tuple.Item1.TutorialComplete();
                return tuple.Item2.GetTutorial(this, tuple.Item1);
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


        public override void SkipTutorials()
        {
            string[] keys = { TutorialHelper.QuestionIcon };
            TutorialHelper.SkipTutorials(keys);
            this.SetValue(ShowTutorialProperty, false);
        }

        #endregion Tutorials

        private void riskButton_Click(object sender, RoutedEventArgs e)
        {
            OnAnimationComplete();
        }
    }
}
