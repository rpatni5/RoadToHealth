using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Converters
{
    public class IconStateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var kvItem = (KeyValuePair<string, bool>)value;

                if (kvItem.Value == false)
                {
                    return GetGrayScaleImage(App.SharedValues.DiseaseIcons[kvItem.Key]);
                }
                else
                {
                    return App.SharedValues.DiseaseIcons[kvItem.Key];
                }
            }
            return null;
        }

        private ImageSource GetGrayScaleImage(ImageSource bmpImage)
        {
            FormatConvertedBitmap grayBitmap = new FormatConvertedBitmap();
            grayBitmap.BeginInit();
            grayBitmap.Source = bmpImage as BitmapImage; 
            grayBitmap.DestinationFormat = PixelFormats.Gray8;
            grayBitmap.EndInit();
            return grayBitmap;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
