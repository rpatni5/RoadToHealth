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

namespace RTH.Windows.Views.Controls
{
    /// <summary>
    /// Interaction logic for ResultRAG.xaml
    /// </summary>
    public partial class ResultRAG : UserControl
    {
        public ResultRAG()
        {
            InitializeComponent();
        }



        //public bool? AnimateRAG
        //{
        //    get { return (bool?)GetValue(AnimateRAGProperty); }
        //    set { SetValue(AnimateRAGProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for AnimateRAG.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty AnimateRAGProperty =
        //    DependencyProperty.Register("AnimateRAG", typeof(bool?), typeof(ResultRAG), new FrameworkPropertyMetadata(null, OnAnimateRAGChanged, OnCoerceValue));

        //private static void OnAnimateRAGChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        //{
        //    var resultRAG = obj as ResultRAG;
        //    if (resultRAG.IsLoaded)
        //    {
        //        bool animate = ((bool?)args.NewValue).HasValue && ((bool?)args.NewValue).Value;
        //        if (animate)
        //        {
        //            resultRAG.RunRectangleSlideRTL();
        //        }
        //        else
        //        {
        //            resultRAG.ResetLayout();
        //        }
        //    }
        //    else
        //    {
        //        RoutedEventHandler OnResultRAGLoaded = null;
        //        OnResultRAGLoaded = (o, e) =>
        //        {
        //            resultRAG.Loaded -= OnResultRAGLoaded;
        //            bool animate = ((bool?)args.NewValue).HasValue && ((bool?)args.NewValue).Value;
        //            if (animate)
        //            {
        //                resultRAG.RunRectangleSlideRTL();
        //            }
        //            else
        //            {
        //                resultRAG.ResetLayout();
        //            }
        //        };
        //        resultRAG.Loaded += OnResultRAGLoaded;
        //    }
        //}

        //private static object OnCoerceValue(DependencyObject obj, object value)
        //{
        //    return value;
        //}
        Storyboard storyboard = null;

        public void PrepareRAGSlideAnimation(int beginTime, int duration)
        {
            storyboard = new Storyboard();
            ThicknessAnimation rectAnimation = new ThicknessAnimation();
            rectAnimation.To = new Thickness(0);
            rectAnimation.BeginTime = TimeSpan.FromSeconds(beginTime);
            rectAnimation.Duration = new Duration(TimeSpan.FromSeconds(duration));

            storyboard.Children.Add(rectAnimation);
            Storyboard.SetTarget(rectAnimation, ragContainer);
            Storyboard.SetTargetProperty(rectAnimation, new PropertyPath(Grid.MarginProperty));
        }

        public void BeginRAGAnimation(EventHandler onAnimationComplete)
        {
            if (storyboard != null)
            {
                storyboard.Completed += onAnimationComplete;
                storyboard.Begin();
            }
        }

        

        public void ResetLayout()
        {
            ragContainer.Margin = new Thickness(0);
        }
    }
}
