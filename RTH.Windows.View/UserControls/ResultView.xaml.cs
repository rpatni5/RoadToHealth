﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Controls;
using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.Objects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : ViewBase
    {
        Storyboard sb = null;
        public ResultView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ResultViewModel>(refreshRequired: true);
            this.RefreshOnLoad = true;
            base.LoadViewModel();
            //InitializeTutorials();
        }

        double graphHeight = 0;

        public bool Animate { get; set; }
        public override void OnViewLoaded()
        {
            base.OnViewLoaded();
           
            //gridResultMain.Visibility = Visibility.Collapsed;
            //graphHeight = ragContainer.ActualHeight;
            //var vm = this.ViewModel as ResultViewModel;

            //if (vm.IsLoaded)
            //{
            //    ExecuteAnimationIfRequired(vm);
            //}
            //else
            //{
            //    LoadedEventHandler handler = null;
            //    handler = (obj) =>
            //    {
            //        vm.Loaded -= handler;
            //        Dispatcher.BeginInvoke((Action)(() => ExecuteAnimationIfRequired(vm)));
            //    };
            //    vm.Loaded += handler;
            //}
        }

       

        //private void ExecuteAnimationIfRequired(ResultViewModel vm)
        //{
        //    if (vm != null)
        //    {
        //        double score = 0;
        //        double.TryParse(vm.LatestScoreSummary.total_score, out score);
        //        if (Animate)
        //        {
        //            Animate = false;
        //            sb = new Storyboard(); ;
        //            //Prepare all the animations
        //            PrepareScaleTransformAndLineofMenAnimation();
        //            lineOfMen.AnimationCompleted += OnLineOfMenAnimationCompleted;
        //            lineOfMen.PrepareAnimation((int)Math.Round(score));
        //            resultGraph.PrepareHeightAnimation(4, 1, graphHeight);
        //            resultRAG.PrepareRAGSlideAnimation(5, 1);
        //            //Begin all the animations
        //            RunScaleTransformAndLineOfMenAnimation();
        //            lineOfMen.BeginScoreAnimation();
        //            resultGraph.BeginHeightAnimation();
        //            resultRAG.BeginRAGAnimation(OnAnimationComplete);
        //        }
        //        else
        //        {
        //            gridResultMain.Visibility = Visibility.Visible;
        //            lineOfMen.SetScore((int)Math.Round(score));
        //            resultGraph.ResetLayout(graphHeight);
        //            resultRAG.ResetLayout();
        //        }
        //    }
        //}

        //private void OnLineOfMenAnimationCompleted(object sender)
        //{
        //    gridQscore.Visibility = Visibility.Visible;
        //}

        //private void OnAnimationComplete(object sender, EventArgs e)
        //{
        //    if (Properties.Settings.Default.Tutorials == true)
        //    {
        //        this.SetValue(ShowTutorialProperty, true);
        //        //TutorialHelper.ScoreTab.TutorialComplete();
        //    }
        //}

        //private void RunScaleTransformAndLineOfMenAnimation()
        //{
        //    //sb.Completed += OnAnimationCompleted;
        //    //sb.Begin();
        //}

        ////private void OnAnimationCompleted(object sender, EventArgs e)
        ////{
        ////    gridQscore.Visibility = Visibility.Visible;
        ////}

        //private void PrepareScaleTransformAndLineofMenAnimation()
        //{
        //    gridQscore.Visibility = Visibility.Collapsed;
        //    //gridResultDisplay.RenderTransformOrigin = new Point(0.5, 0.5);
        //    //gridResultDisplay.RenderTransform = new ScaleTransform(2.5, 2.5);
        //    gridResultMain.Visibility = Visibility.Visible;

        //    //var scaleXAnimation = new DoubleAnimationUsingKeyFrames();
        //    //scaleXAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    //scaleXAnimation.KeyFrames = new DoubleKeyFrameCollection();
        //    //scaleXAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
        //    //Storyboard.SetTarget(scaleXAnimation, gridResultDisplay);
        //    //Storyboard.SetTargetProperty(scaleXAnimation, new PropertyPath("RenderTransform.(ScaleTransform.ScaleX)"));

        //    //var scaleYAnimation = new DoubleAnimationUsingKeyFrames();
        //    //scaleYAnimation.Duration = new Duration(TimeSpan.FromSeconds(3));
        //    //scaleYAnimation.KeyFrames = new DoubleKeyFrameCollection();
        //    //scaleYAnimation.KeyFrames.Add(new EasingDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(3))));
        //    //Storyboard.SetTarget(scaleYAnimation, gridResultDisplay);
        //    //Storyboard.SetTargetProperty(scaleYAnimation, new PropertyPath("RenderTransform.(ScaleTransform.ScaleY)"));

        //    //sb.Children.Add(scaleXAnimation);
        //    //sb.Children.Add(scaleYAnimation);
        //}

        //#region Tutorials

        //Dictionary<int, Tuple<string, FrameworkElement>> tutorialObjects;
        //public void InitializeTutorials()
        //{
        //    tutorialObjects = new Dictionary<int, Tuple<string, FrameworkElement>>();
        //    //AddTutorialToList(TutorialHelper.AdviceTab, App.SharedValues.WindowMain.footerContainer.rdoMiddle);
        //    //AddTutorialToList(TutorialHelper.InsightTab, App.SharedValues.WindowMain.footerContainer.rdoRight);
        //    //AddTutorialToList(TutorialHelper.DashboardTab, App.SharedValues.WindowMain.footerContainer.rdoHome);
        //}

        //int currentTutIndex = 0;
        //public override TutorialContent GetTutorials()
        //{
        //    if (currentTutIndex >= this.MaxTutorials)
        //    {
        //        ShowTutorial = false;
        //        return null;
        //    }
        //    var tuple = tutorialObjects[currentTutIndex++];
        //    if (tuple.Item1.ShowTutorial())
        //    {
        //        tuple.Item1.TutorialComplete();
        //        return tuple.Item2.GetTutorial(this, tuple.Item1, true);
        //    }
        //    ShowTutorial = false;
        //    return null;
        //}
        //public int MaxTutorials
        //{
        //    get
        //    {
        //        return tutorialObjects.Count;
        //    }
        //}
        //public int GetTutorialIndex()
        //{
        //    return currentTutIndex;
        //}
        //public string GetTutorialText(string keyString)
        //{
        //    if (App.SharedValues.LanguageResource.GetType().GetProperty(keyString) != null)
        //    {
        //        return App.SharedValues.LanguageResource.GetType().GetProperty(keyString).GetValue(App.SharedValues.LanguageResource).ToString();
        //    }
        //    return string.Empty;
        //}

        //private void AddTutorialToList(string keyString, FrameworkElement element)
        //{
        //    if (TutorialHelper.ShowTutorial(keyString))
        //    {
        //        tutorialObjects.Add(tutorialObjects.Count, new Tuple<string, FrameworkElement>(keyString, element));
        //    }
        //}

        //public override void SkipTutorials()
        //{
        //    string[] keys = { TutorialHelper.ScoreTab, TutorialHelper.AdviceTab, TutorialHelper.InsightTab, TutorialHelper.DashboardTab };
        //    TutorialHelper.SkipTutorials(keys);
        //    this.SetValue(ShowTutorialProperty, false);
        //}

        //#endregion Tutorials


    }
}

