﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.Objects;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for uc_insights.xaml
    /// </summary>
    public partial class InsightsView : ViewBase
    {
        public InsightsView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.GetNew<InsightsViewModel>();
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }

        private void Grid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (Properties.Settings.Default.Tutorials == true)
            {
                this.SetValue(ShowTutorialProperty, true);
            }
        }

      

        



        //#region Tutorials

        //Dictionary<int, Tuple<string, FrameworkElement>> tutorialObjects;
        //public void InitializeTutorials()
        //{
        //    currentTutIndex = 0;
        //    tutorialObjects = new Dictionary<int, Tuple<string, FrameworkElement>>();
        //    if (TutorialHelper.ShowTutorial(TutorialHelper.InsightInnerIcon))
        //    {
        //        tutorialObjects.Add(tutorialObjects.Count, new Tuple<string, FrameworkElement>(TutorialHelper.InsightInnerIcon, this.InsightTabGrid));
        //    }

        //}
        //public override void OnViewLoaded()
        //{
        //    InitializeTutorials();
        //}

        //int currentTutIndex = 0;
        //public override TutorialContent GetTutorials()
        //{
        //    if (currentTutIndex == this.MaxTutorials)
        //    {
        //        ShowTutorial = false;
        //        return null;
        //    }
        //    var tuple = tutorialObjects[currentTutIndex++];
        //    if (tuple.Item1.ShowTutorial())
        //    {
        //        tuple.Item1.TutorialComplete();
        //        return tuple.Item2.GetTutorial(this, tuple.Item1);
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
        //public override void SkipTutorials()
        //{
        //    string[] keys = { TutorialHelper.InsightInnerIcon };
        //    TutorialHelper.SkipTutorials(keys);
        //    ShowTutorial = false;
        //}
        //#endregion Tutorials
    }
}
