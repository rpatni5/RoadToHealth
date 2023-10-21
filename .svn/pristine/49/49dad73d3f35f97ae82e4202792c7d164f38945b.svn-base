using System;
using System.Collections;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RTH.Windows.Views.Controls
{
    //[TemplatePart(Name = "PART_PaintArea", Type = typeof(Shape)), TemplatePart(Name = "PART_MainContent", Type = typeof(ContentPresenter))]
    [TemplatePart(Name = "PART_Track", Type = typeof(Border)), TemplatePart(Name = "PART_Indicator", Type = typeof(Border))]
    public sealed class ScoreProgressBarControl : ContentControl
    {
        private static ControlTemplate defaultTemplate;
        FrameworkElementFactory progressLeft;
        FrameworkElementFactory progressCenter;
        FrameworkElementFactory progressRight;
        public ScoreProgressBarControl()
        {
            SetTemplate();
        }

        private void SetTemplate()
        {
            ControlTemplate template = new ControlTemplate(typeof(ScoreProgressBarControl));

            var stackPanel = new FrameworkElementFactory(typeof(StackPanel));
            stackPanel.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

         

            progressLeft = CreateProgressBar(new CornerRadius(4, 0, 0,4), "#FFE14E1B", 0, 50);

            progressCenter = CreateProgressBar(new CornerRadius(0, 0, 0, 0), "#FFF19A33", 0, 100);

            progressRight = CreateProgressBar(new CornerRadius(0, 4, 4, 0), "#FF39A235", 0, 100);

            var progress = Progress;

            if (progress >= 20)
            {
                progressLeft.SetValue(ProgressBar.ValueProperty, 100.0);
            }
            else
            {
                progressLeft.SetValue(ProgressBar.ValueProperty, (progress / 20) * 100);
            }
            if (progress >= 60)
            {
                progressCenter.SetValue(ProgressBar.ValueProperty, 100.0);
            }
            else
            {
                progressCenter.SetValue(ProgressBar.ValueProperty, ((progress-20 )/ 40) * 100);
            }
            if (progress == 100)
            {
                progressRight = CreateProgressBar(new CornerRadius(0, 4, 4, 0), "#FF39A235",100.0, 100);
            }
            else
            {
                progressRight = CreateProgressBar(new CornerRadius(0, 4, 4, 0), "#FF39A235", ((progress - 60) / 40) * 100, 100,true);
            }

            stackPanel.AppendChild(progressLeft);
            stackPanel.AppendChild(progressCenter);
            stackPanel.AppendChild(progressRight);

            template.VisualTree = stackPanel;
            defaultTemplate = template;
            this.SetValue(TemplateProperty, defaultTemplate);
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            //SetTemplate();
            base.OnRender(drawingContext);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        

        [Description("current progress of control"), Category("Behavior Settings")]
        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(double), typeof(ScoreProgressBarControl),
            new FrameworkPropertyMetadata(0.0,new PropertyChangedCallback(OnProgressChange)));

        private static void OnProgressChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ScoreProgressBarControl).SetTemplate();
        }

        private ControlTemplate CreateProgressBarTemplate(CornerRadius radious, bool IsProgress)
        {
            ControlTemplate progressBarTemplate = new ControlTemplate(typeof(ProgressBar));
            var grid = new FrameworkElementFactory(typeof(Grid));
            grid.SetValue(NameProperty, "Root");
            var PART_Track = new FrameworkElementFactory(typeof(Border), "PART_Track");
            PART_Track.SetValue(NameProperty, "PART_Track");
            PART_Track.SetValue(Border.CornerRadiusProperty, radious);
            PART_Track.SetValue(BackgroundProperty, Brushes.LightGray);

            var PART_Indicator = new FrameworkElementFactory(typeof(Border), "PART_Indicator");
            PART_Indicator.SetValue(NameProperty, "PART_Indicator");
            PART_Indicator.SetValue(Border.CornerRadiusProperty, IsProgress==false? radious:new CornerRadius(0,0,0,0));
            PART_Indicator.SetValue(BackgroundProperty, new TemplateBindingExtension(ForegroundProperty));
            PART_Indicator.SetValue(Border.HorizontalAlignmentProperty, HorizontalAlignment.Left);


            grid.AppendChild(PART_Track);
            grid.AppendChild(PART_Indicator);
            progressBarTemplate.VisualTree = grid;
            return progressBarTemplate;
        }

        private FrameworkElementFactory CreateProgressBar(CornerRadius radious, string foreColor, double value, double width = 50,bool IsProgress=false)
        {
            var progressBar = new FrameworkElementFactory(typeof(ProgressBar));
            progressBar.SetValue(HeightProperty, 10.0);
            progressBar.SetValue(WidthProperty, width);
            progressBar.SetValue(BorderThicknessProperty, new Thickness(5, 0, 0, 5));
            progressBar.SetValue(ProgressBar.MinimumProperty, 0.0);
            progressBar.SetValue(ProgressBar.MaximumProperty, 100.0);
            progressBar.SetValue(ProgressBar.ValueProperty, value);
            progressBar.SetValue(MarginProperty, new Thickness(1, 0, 1, 0));
            progressBar.SetValue(ForegroundProperty, new BrushConverter().ConvertFrom(foreColor));
            progressBar.SetValue(TemplateProperty, CreateProgressBarTemplate(radious, IsProgress));
            return progressBar;
        }


    }
}
