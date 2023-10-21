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
    public class StringToNumericConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            double num;
            string strvalue = value as string;
            if (double.TryParse(strvalue, out num))
            {
                if (parameter == null || parameter.ToString() == "int")
                    return (int)num;
                else if (parameter.ToString() == "decimal")
                    return (decimal)num;
                else if (parameter.ToString() == "double")
                    return (double)num;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.ToString();
        }
    }
}
