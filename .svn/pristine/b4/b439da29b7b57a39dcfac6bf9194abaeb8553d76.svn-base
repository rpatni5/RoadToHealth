using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class ImageUrlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && !string.IsNullOrEmpty(value.ToString()))
            {
                string url = System.IO.Path.Combine(Configurations.ImagePath, value.ToString());
                var imgThumbCvtr = new ImageThumbnailConverter();
                int size = 0;
                imgThumbCvtr.Width = imgThumbCvtr.Height = parameter != null && int.TryParse(parameter.ToString(), out size) ? size : 32;
                return imgThumbCvtr.Convert(url, targetType, null, culture);
            }
            return "/Assets/circle.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
