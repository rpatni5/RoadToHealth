using RTH.Windows.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for HealthPlanComplete.xaml
    /// </summary>
    public partial class HealthPlanComplete : ViewBase
    {
        public HealthPlanComplete()
        {
            InitializeComponent();
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModels.Common.ViewModelLocator.Get<StrategyViewModel>();
            ViewModel.FooterVisibility = ViewModel.HeaderVisibility = false;
            base.LoadViewModel();
        }

        public override void OnViewLoaded()
        {
            RunPlanTextAnimation();
        }

        private void RunPlanTextAnimation()
        {
            pathTick.Visibility = Visibility.Collapsed;
            txtHealthPlan.Opacity = 0;
            var sb = new Storyboard();
            var da = new DoubleAnimation(0D, 1D, new Duration(TimeSpan.FromSeconds(3)));
            sb.Children.Add(da);
            Storyboard.SetTarget(da, txtHealthPlan);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            sb.Completed += Sb_Completed;
            sb.Begin();
        }

        private void Sb_Completed(object sender, EventArgs e)
        {
            pathTick.Visibility = Visibility.Visible;
        }

        private void cv_Loaded(object sender, RoutedEventArgs e)
        {
            RunBubbleAnimation();
        }

        private void RunBubbleAnimation()
        {
            var storyboard = new Storyboard();
            var rnd = new Random();
            var center = new Point(cv.ActualWidth / 2, cv.ActualHeight / 2);
            for (int i = 0; i < 200; i++)
            {
                var circle = new Ellipse() { Fill = Brushes.White, Opacity = 0 };

                var duration = TimeSpan.FromSeconds(15 * rnd.NextDouble());
                var beginTime = TimeSpan.FromSeconds(10 * rnd.NextDouble());

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
            cv.Visibility = System.Windows.Visibility.Hidden;
            cv.Visibility = System.Windows.Visibility.Visible;
            App.SharedValues.WindowMain.LoadView(Enums.ViewEnum.HealthPlanView, false);
        }
    }
}
