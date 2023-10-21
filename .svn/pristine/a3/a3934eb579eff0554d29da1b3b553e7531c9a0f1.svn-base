using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RTH.Windows.Views.Helpers
{
    public class PlaceholderTextBox : TextBox
    {

        public String Value { get; set; }
       
        public string PlaceholderText
        {
            get { return (string)GetValue(PlaceholderTextProperty); }
            set { SetValue(PlaceholderTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.Register("PlaceholderText", typeof(string), typeof(PlaceholderTextBox), new PropertyMetadata(null));



        public System.Windows.Media.Brush PlaceholderBrush
        {
            get { return (System.Windows.Media.Brush)GetValue(PlaceholderBrushProperty); }
            set { SetValue(PlaceholderBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlaceholderBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlaceholderBrushProperty =
            DependencyProperty.Register("PlaceholderBrush", typeof(System.Windows.Media.Brush), typeof(PlaceholderTextBox), new PropertyMetadata(null));



        public System.Windows.Media.Brush ValuedBrush
        {
            get { return (System.Windows.Media.Brush)GetValue(ValuedBrushProperty); }
            set { SetValue(ValuedBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ValuedBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValuedBrushProperty =
            DependencyProperty.Register("ValuedBrush", typeof(System.Windows.Media.Brush), typeof(PlaceholderTextBox), new PropertyMetadata(null));
 

        public PlaceholderTextBox() : base() { }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ValuedBrush = this.Foreground;
            Value = this.GetValue(TextBox.TextProperty) as string;
            if (String.IsNullOrEmpty(Value))
            {                
                this.SetCurrentValue(TextBox.TextProperty, PlaceholderText);
                this.SetCurrentValue(TextBox.ForegroundProperty, PlaceholderBrush);
            }
        }

        protected override void OnGotFocus(System.Windows.RoutedEventArgs e)
        {
            this.SetCurrentValue(TextBox.ForegroundProperty, ValuedBrush);
            Value = this.GetValue(TextBox.TextProperty) as string;
            if (String.IsNullOrEmpty(Value) || Value == PlaceholderText)
            {
                this.SetCurrentValue(TextBox.TextProperty, string.Empty);
            }
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(System.Windows.RoutedEventArgs e)
        {
            Value = this.GetValue(TextBox.TextProperty) as string;
            if (String.IsNullOrEmpty(Value))
            {
                this.SetCurrentValue(TextBox.TextProperty, PlaceholderText);
                this.SetCurrentValue(TextBox.ForegroundProperty, PlaceholderBrush);
            }

            base.OnLostFocus(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            Value = this.GetValue(TextBox.TextProperty) as string;
            if (String.IsNullOrEmpty(Value) && this.IsFocused==false)
            {
                this.SetCurrentValue(TextBox.TextProperty, PlaceholderText);
                this.SetCurrentValue(TextBox.ForegroundProperty, PlaceholderBrush);
            }else if (Value== PlaceholderText && this.IsFocused == false)
            {               
                this.SetCurrentValue(TextBox.ForegroundProperty, PlaceholderBrush);
            }

            base.OnTextChanged(e);
        }
    }
}
