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
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            switch (value.ToString())
            {
                case "back-red":
                case "Red":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#e5332a"));
                case "back-amber":
                case "Amber":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#f29100"));
                case "back-green":
                case "Green":
                    return new SolidColorBrush((Color)ColorConverter.ConvertFromString("#76b72a"));
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
