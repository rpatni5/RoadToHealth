using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class StringToUriConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (string.IsNullOrEmpty(value.ToString())) return null;
            if (parameter == null || string.IsNullOrEmpty(parameter.ToString()))
                return new Uri(value.ToString(), UriKind.RelativeOrAbsolute);
            else
            {
                Uri path = new Uri(value.ToString(), UriKind.RelativeOrAbsolute);
                string name = path.Segments[path.Segments.Length - 1];
                string[] arr = name.Split('.');
                arr[0] += "_flipped";
                path.Segments[path.Segments.Length - 1].Replace(name, string.Join("", arr));
                return path;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (string.IsNullOrEmpty(value.ToString())) return null;
            return ((Uri)value).ToString();
        }
    }
}
