using RTH.Helpers.DataCaching;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Converters
{
    public class ImagePathToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var img = new Image();

            BitmapImage bitmap = new BitmapImage(new Uri(value.ToString(), UriKind.Absolute), AppCachePolicy.ImageCachePolicy);
            img.SetValue(Image.SourceProperty, bitmap);
            return img;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
