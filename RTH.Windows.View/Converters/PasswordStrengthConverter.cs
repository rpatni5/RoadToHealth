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
    public class PasswordStrengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && (int)value!=0)
            {
                return CheckVisibility(parameter.ToString(), (int)value);
            }
            return Visibility.Hidden;
        }

        private Visibility CheckVisibility(string type,int value)
        {
            if (type == "One")
            {
                if (value > 0) return Visibility.Visible;
            }else if (type == "Two")
            {
                if (value > 1) return Visibility.Visible;
            }
            else if (type == "Three")
            {
                if (value > 2) return Visibility.Visible;
            }
            else if (type == "Four")
            {
                if (value > 3) return Visibility.Visible;
            }
            return Visibility.Hidden;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
