using RTH.Windows.Views.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace RTH.Windows.Views.Controls
{
    public delegate void AnimationCompletedEvent(object sender);
    public partial class LineofMen : UserControl
    {
        //public bool? AnimateLineOfMen
        //{
        //    get { return (bool?)GetValue(AnimateLineOfMenProperty); }
        //    set { SetValue(AnimateLineOfMenProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Animate.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty AnimateLineOfMenProperty = DependencyProperty.Register("AnimateLineOfMen",
        //    typeof(bool?), typeof(LineofMen), new PropertyMetadata(null, new PropertyChangedCallback(OnScorePropertyChanged)));

        public double CurrentOffset
        {
            get { return (double)GetValue(CurrentOffsetProperty); }
            set { SetValue(CurrentOffsetProperty, value); }
        }
        public static readonly DependencyProperty CurrentOffsetProperty = DependencyProperty.Register("CurrentOffset", typeof(double),
            typeof(LineofMen), new FrameworkPropertyMetadata(0.0, null));

        //public double Score
        //{
        //    get { return (double)GetValue(ScoreProperty); }
        //    set { SetValue(ScoreProperty, value); }
        //}

        //public static readonly DependencyProperty ScoreProperty = DependencyProperty.Register("Score", typeof(double),
        //    typeof(LineofMen), new FrameworkPropertyMetadata(0.0, null, (o, e) => { return e; }));

        //private static void OnScorePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    var uc = (d as LineofMen);
        //    if (uc.IsLoaded == false)
        //    {
        //        RoutedEventHandler handler = null;
        //        handler = (a, b) =>
        //        {
        //            uc.Loaded -= handler;
        //            if (e.Property == ScoreProperty)
        //            {
        //                uc.SetCurrentScore((double)e.OldValue, (double)e.NewValue);
        //            }
        //            else if (e.Property == AnimateLineOfMenProperty)
        //            {
        //                uc.SetCurrentScore(0.0, uc.Score);
        //            }
        //        };
        //        uc.Loaded += handler;
        //    }
        //    else
        //    {
        //        if (e.Property == ScoreProperty)
        //        {
        //            uc.SetCurrentScore((double)e.OldValue, (double)e.NewValue);
        //        }
        //        else if (e.Property == AnimateLineOfMenProperty)
        //        {
        //            uc.SetCurrentScore(0.0, uc.Score);
        //        }
        //    }
        //}

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.Property == LineofMen.CurrentOffsetProperty)
            {
                scrView.ScrollToHorizontalOffset((double)e.NewValue);
            }
        }

        Storyboard storyboard = null;
        Dictionary<int, string> chartItems = new Dictionary<int, string>();
        public LineofMen()
        {
            InitializeComponent();
            menSquad.ItemsSource = chartItems = Enumerable.Range(-9, 120).ToDictionary(k => k + 10, v => v.ToString());
        }

        public void PrepareAnimation(int score)
        {
            SetScore(5);
            ContentPresenter item = GetItem(score);
            if (item != null)
            {
                double horizontalOffset = GetHorizontalOffset(item);

                storyboard = new Storyboard();
                var scrollAnim = new DoubleAnimation();
                //scrollAnim.From = 0;
                scrollAnim.To = horizontalOffset;
                PowerEase easeFunction = new PowerEase();
                easeFunction.Power = 3;
                easeFunction.EasingMode = EasingMode.EaseInOut;
                scrollAnim.EasingFunction = easeFunction;
                scrollAnim.Duration = new Duration(TimeSpan.FromSeconds(3));


                storyboard.Children.Add(scrollAnim);
                Storyboard.SetTarget(scrollAnim, this);
                Storyboard.SetTargetProperty(scrollAnim, new PropertyPath(LineofMen.CurrentOffsetProperty));
            }
        }

        public void SetScore(int score)
        {
            ContentPresenter item = GetItem(score);
            if (item != null)
            {
                CurrentOffset = GetHorizontalOffset(item);
            }
        }

        private ContentPresenter GetItem(int score)
        {
            var obj = chartItems.First(t => t.Value.Equals(score.ToString()));
            ContentPresenter item = (ContentPresenter)menSquad.ItemContainerGenerator.ContainerFromItem(obj);
            return item;
        }

        private double GetHorizontalOffset(ContentPresenter item)
        {
            return ((scrView.ExtentWidth / 120 * ((KeyValuePair<int, string>)item.Content).Key) - (scrView.ActualWidth / 2) - item.ActualWidth);
        }

        public void BeginScoreAnimation()
        {
            if (storyboard != null)
            {
                storyboard.Completed += OnAnimationCompleted;
                storyboard.Begin();
            }
        }
        public event AnimationCompletedEvent AnimationCompleted;
        private void OnAnimationCompleted(object sender, EventArgs e)
        {
            storyboard.Completed -= OnAnimationCompleted;
            if (AnimationCompleted != null)
            {
                AnimationCompleted(this);
            }
        }
    }
}
