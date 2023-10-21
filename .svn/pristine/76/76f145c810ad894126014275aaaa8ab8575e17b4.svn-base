using System;
using System.Globalization;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class StringToFloorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value.Equals(string.Empty))
            {
                return Math.Floor(System.Convert.ToDouble(value)).ToString();
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
