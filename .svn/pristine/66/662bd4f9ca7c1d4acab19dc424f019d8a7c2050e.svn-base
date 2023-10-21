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
    public class TutorialPositionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && parameter != null)
            {
                Rect _r = (Rect)value;
                if (parameter.Equals("Footer"))
                {
                    if (_r.Y > 400)
                    {
                        return (_r.Y - 109 - 20);
                    }
                    else {
                        return (_r.Y + _r.Height + 20);
                    }
                }
                else if (parameter.Equals("Header"))
                {
                    return (_r.Y - 30);
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
