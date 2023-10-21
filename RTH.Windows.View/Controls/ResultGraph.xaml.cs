﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.Controls
{
    /// <summary>
    /// Interaction logic for ResultGraph.xaml
    /// </summary>
    public partial class ResultGraph : UserControl
    {
        public ResultGraph()
        {
            InitializeComponent();
        }



        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(IEnumerable<object>), typeof(ResultGraph), new PropertyMetadata(null, (o, e) =>
            {
                var resultGraph = o as ResultGraph;
                //resultGraph.BindItemsSourceChangedHandler();
                resultGraph.scoreSummaries.ItemsSource = e.NewValue as IEnumerable<object>;
            }));
        //private double GetControlHeight()
        //{
        //    return (double)GetValue(ControlHeightProperty);
        //}
        //public double ControlHeight
        //{
        //    get { return (double)GetValue(ControlHeightProperty); }
        //    set { SetValue(ControlHeightProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ControlHeight.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ControlHeightProperty =
        //    DependencyProperty.Register("ControlHeight", typeof(double), typeof(ResultGraph), new FrameworkPropertyMetadata(0D, null, OnCoerceValue));

        //private bool GetAnimateValue()
        //{
        //    return ((bool?)GetValue(AnimateGraphProperty)).HasValue && ((bool?)GetValue(AnimateGraphProperty)).Value;
        //}
        //public bool? AnimateGraph
        //{
        //    get { return (bool?)GetValue(AnimateGraphProperty); }
        //    set { SetValue(AnimateGraphProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for AnimateControls.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty AnimateGraphProperty =
        //    DependencyProperty.RegisterAttached("AnimateGraph", typeof(bool?), typeof(ResultGraph), new FrameworkPropertyMetadata(null, null,
        //        OnCoerceValue));
        //private static object OnCoerceValue(DependencyObject obj, object val)
        //{
        //    return val;
        //}
        ////private static void OnAnimateControlsPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        ////{
        ////    var resultGraph = o as ResultGraph;
        ////    bool animate = ((bool?)e.NewValue).HasValue && ((bool?)e.NewValue).Value;
        ////    if (animate)
        ////    {
        ////        resultGraph.BindItemsSourceChangedHandler();
        ////    }
        ////    else
        ////    {
        ////        resultGraph.ResetLayout();
        ////    }
        ////}
        //public void BindItemsSourceChangedHandler()
        //{
        //    DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(ResultGraph)).AddValueChanged(scoreSummaries, OnItemsSourceChanged);
        //}
        //private void OnItemsSourceChanged(object o, EventArgs e)
        //{
        //    DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, typeof(ResultGraph)).RemoveValueChanged(scoreSummaries, OnItemsSourceChanged);
        //    CoerceValue(ControlHeightProperty);
        //    if (AnimateGraph.HasValue && AnimateGraph.Value)
        //    {
        //        RunAnimation();
        //    }
        //    else
        //    {
        //        ResetLayout();
        //    }
        //}
        //int seconds = 0;
        Storyboard storyboard = null;
        public void PrepareHeightAnimation(int beginTime, int duration, double height)
        {
            var heightAnim = new DoubleAnimation();
            heightAnim.BeginTime = TimeSpan.FromSeconds(beginTime);// To be started after line of men animation that runs for 3 seconds
            heightAnim.From = 0;
            heightAnim.To = 325 - 15;//325 is the ActualHeight of ragContainer in the ResultView.xaml. This should strictly be maintained as such
            heightAnim.Duration = new Duration(TimeSpan.FromSeconds(duration));

            storyboard = new Storyboard();
            storyboard.Children.Add(heightAnim);
            Storyboard.SetTarget(heightAnim, scoreSummaries);
            Storyboard.SetTargetProperty(heightAnim, new PropertyPath(ItemsControl.HeightProperty));
        }
        public void BeginHeightAnimation()
        {
            if (storyboard != null) storyboard.Begin();
        }
        //private void OnstoryBoardCompleted(object sender, EventArgs e)
        //{
        //    int secondsElapsed = DateTime.Now.Second - seconds;
        //    if (AnimationExecuted != null) AnimationExecuted(3 + secondsElapsed);
        //}

        //public delegate void AnimationExecutedDelegate(double duration);
        //public event AnimationExecutedDelegate AnimationExecuted;
        public void ResetLayout(double height)
        {
            scoreSummaries.Height = 325 - 15;//325 is the ActualHeight of ragContainer in the ResultView.xaml. This should strictly be maintained as such
        }
    }
}
