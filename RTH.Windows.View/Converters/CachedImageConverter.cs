using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Converters
{
    public class CachedImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string && !string.IsNullOrEmpty(value.ToString()))
            {
                try
                {
                    var uri = new Uri(value.ToString(), UriKind.RelativeOrAbsolute);
                    if (uri.IsAbsoluteUri)
                        return new BitmapImage(new Uri(value.ToString(), UriKind.RelativeOrAbsolute), RTH.Helpers.DataCaching.AppCachePolicy.ImageCachePolicy);
                    return uri;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return string.Empty;
            //throw new FormatException("Input value for Uri is not in correct format!!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
