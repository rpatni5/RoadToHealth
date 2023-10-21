using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class DecreaseOpacityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                int colorTrans = 255 - ((Int32)value * 40);
                string str = colorTrans.ToString("X2");
                return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#" + str + "5BC1ED");
            }
            return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#5BC1ED");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
