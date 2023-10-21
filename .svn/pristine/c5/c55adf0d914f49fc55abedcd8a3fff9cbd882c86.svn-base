using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RTH.Windows.Views.Controls
{
    [TemplatePart(Name = "PART_ClearIconBorder", Type = typeof(Border))]
    public class LabelTextBox : TextBox
    {
        static LabelTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelTextBox), new FrameworkPropertyMetadata(typeof(LabelTextBox)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (this.Template != null)
            {
                Border iconBorder = GetTemplateChild("PART_ClearIconBorder") as Border;
                if (iconBorder != null)
                {
                    iconBorder.MouseLeftButtonDown += new MouseButtonEventHandler(IconBorder_MouseLeftButtonDown);
                    iconBorder.MouseLeftButtonUp += new MouseButtonEventHandler(IconBorder_MouseLeftButtonUp);
                    iconBorder.MouseLeave += new MouseEventHandler(IconBorder_MouseLeave);
                }
            }
        }

        public static DependencyProperty LabelTextProperty = DependencyProperty.Register("LabelText", typeof(string), typeof(LabelTextBox));
        public static DependencyProperty LabelTextColorProperty = DependencyProperty.Register("LabelTextColor", typeof(Brush), typeof(LabelTextBox));
        private static DependencyPropertyKey HasTextPropertyKey = DependencyProperty.RegisterReadOnly("HasText", typeof(bool), typeof(LabelTextBox), new PropertyMetadata());
        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;
        private static DependencyPropertyKey IsMouseLeftButtonDownPropertyKey = DependencyProperty.RegisterReadOnly("IsMouseLeftButtonDown",
            typeof(bool), typeof(LabelTextBox), new PropertyMetadata());


        public bool AllowIcon
        {
            get { return (bool)GetValue(AllowIconProperty); }
            set { SetValue(AllowIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AllowIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AllowIconProperty =
            DependencyProperty.Register("AllowIcon", typeof(bool), typeof(LabelTextBox), new PropertyMetadata(true));


        public static DependencyProperty IsMouseLeftButtonDownProperty = IsMouseLeftButtonDownPropertyKey.DependencyProperty;

        public bool IsMouseLeftButtonDown
        {
            get { return (bool)GetValue(IsMouseLeftButtonDownProperty); }
            private set { SetValue(IsMouseLeftButtonDownPropertyKey, value); }
        }

        private void IconBorder_MouseLeftButtonUp(object obj, MouseButtonEventArgs e)
        {
            if (!IsMouseLeftButtonDown) return;

            if (HasText)
            {
                this.SetCurrentValue(TextProperty, "");
            }
            IsMouseLeftButtonDown = false;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.SetCurrentValue(TextProperty, "");
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

        private void IconBorder_MouseLeftButtonDown(object obj, MouseButtonEventArgs e)
        {
            IsMouseLeftButtonDown = true;
        }

        private void IconBorder_MouseLeave(object obj, MouseEventArgs e)
        {
            IsMouseLeftButtonDown = false;
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            HasText = Text.Length != 0;
        }

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public Brush LabelTextColor
        {
            get { return (Brush)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }
    }
}
