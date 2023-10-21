using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class ErrorMessageColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if((int)value==1)
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#76b72a"));
            }
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e5332a"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
