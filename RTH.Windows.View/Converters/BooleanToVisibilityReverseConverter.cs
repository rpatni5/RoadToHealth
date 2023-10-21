using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class BooleanToVisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                if (value == null || !(bool)value) return Visibility.Visible;
            }
            else if (parameter.Equals("hidden"))
            {
                if (value == null || !(bool)value) return Visibility.Visible;
                else return Visibility.Hidden;
            }
            else if (parameter.Equals("hiddenReverse"))
            {
                if (value == null || !(bool)value) return Visibility.Hidden;
                else return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
