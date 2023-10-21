using RTH.Business.Objects.JSON;
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
    public class ProductIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(e => e == DependencyProperty.UnsetValue || e == null || string.IsNullOrEmpty(e.ToString())))
            {
                List<Product> products = values[0] as List<Product>;
                if (products.Count > 0)
                    return products[(Int32)values[1]];
                else
                    return null;
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
