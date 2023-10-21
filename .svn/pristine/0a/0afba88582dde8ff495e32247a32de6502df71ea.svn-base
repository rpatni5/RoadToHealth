using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RTH.Windows.Views.Helpers
{
    public class DecimalTextHelper : DependencyObject
    {
        public static Regex decimalPattern = new Regex(@"^(?<Number>\d+)((?<Decimal>[.,])?(?<Precision>(?:\d{0,2}%?))?\d{0,})$?", RegexOptions.Compiled);

        // Using a DependencyProperty as the backing store for LargeTextSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LargeTextSizeProperty =
            DependencyProperty.Register("LargeTextSize", typeof(double), typeof(DecimalTextHelper), new PropertyMetadata(42.0));

        public static double GetLargeTextSize(DependencyObject obj)
        {
            return (double)obj.GetValue(LargeTextSizeProperty);
        }

        public static void SetLargeTextSize(DependencyObject obj, double value)
        {
            obj.SetValue(LargeTextSizeProperty, value);
        }

        public static double GetSmallTextSize(DependencyObject obj)
        {
            return (double)obj.GetValue(SmallTextSizeProperty);
        }

        public static void SetSmallTextSize(DependencyObject obj, double value)
        {
            obj.SetValue(SmallTextSizeProperty, value);
        }

        // Using a DependencyProperty as the backing store for GetSmallTextSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SmallTextSizeProperty =
            DependencyProperty.Register("SmallTextSize", typeof(double), typeof(DecimalTextHelper), new PropertyMetadata(12.0));

        public static string GetDecimalText(DependencyObject obj)
        {
            return (string)obj.GetValue(DecimalTextProperty);
        }

        public static void SetDecimalText(DependencyObject obj, string value)
        {
            obj.SetValue(DecimalTextProperty, value);
        }

        public static readonly DependencyProperty DecimalTextProperty = DependencyProperty.RegisterAttached("DecimalText",
            typeof(string), typeof(DecimalTextHelper), new UIPropertyMetadata("", ValueChanged));

        private static void ValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            double val = 0;
            string value = e.NewValue as string;
            TextBlock textBlock = sender as TextBlock;
            if (double.TryParse(e.NewValue as string, out val))
            {
                var exp = textBlock.GetBindingExpression(e.Property);
                string strFormat = exp.ParentBinding.StringFormat;
                if (string.IsNullOrWhiteSpace(strFormat))
                {
                    var afterDecimals = val - (int)val;
                    if (afterDecimals > 0)
                        strFormat = "0.0";
                }
                else
                {
                    strFormat = "0.0";
                }
                value = Math.Round(val, 1).ToString(strFormat);
            }
            var match = decimalPattern.Match(value);
            textBlock.Text = value;
            if (textBlock != null && match.Success)
            {
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add(new Run() { FontSize = GetLargeTextSize(textBlock), Text = match.Groups["Number"].Value });
                if (match.Groups["Number"].Value != "100")
                {
                    textBlock.Inlines.Add(new Run() { FontSize = GetSmallTextSize(textBlock), Text = match.Groups["Decimal"].Value });
                    textBlock.Inlines.Add(new Run() { FontSize = GetSmallTextSize(textBlock), Text = match.Groups["Precision"].Value });
                }
            }
            else
            {
                textBlock.Inlines.Clear();
                textBlock.Inlines.Add(new Run() { FontSize = GetLargeTextSize(textBlock), Text = value });
            }
        }
    }
}
