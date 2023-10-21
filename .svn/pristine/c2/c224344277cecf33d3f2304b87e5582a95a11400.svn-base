using System;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class TitleCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var content = value as string;
            if (string.IsNullOrEmpty(content) == false)
            {
                var txtinfo = culture.TextInfo;
                return txtinfo.ToTitleCase(content);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var content = value as string;
            if (string.IsNullOrEmpty(content) == false)
            {
                var txtinfo = culture.TextInfo;
                return txtinfo.ToTitleCase(content);
            }
            return value;
        }
    }
}
