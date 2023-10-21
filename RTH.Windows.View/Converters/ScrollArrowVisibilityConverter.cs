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
    public class ScrollArrowVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null)
                throw new ArgumentException("Values cannot be null.");
            if (values.Count() != 2)
                throw new ArgumentException("Incorrect number of bindings (" + values.Count() + ")");

            var offset = Double.Parse(values[0].ToString());
            var maxHeight = Double.Parse(values[1].ToString());

            return offset == maxHeight ? Visibility.Collapsed : Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
