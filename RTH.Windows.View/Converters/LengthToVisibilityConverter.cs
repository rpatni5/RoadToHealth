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
    public class LengthToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {

                if (value is double)
                {
                    if (parameter == null)
                    {
                        if ((double)value > 0)
                            return Visibility.Visible;
                        return Visibility.Collapsed;
                    }
                    else if (parameter.Equals("Not"))
                    {
                        if ((double)value > 0)
                            return Visibility.Collapsed;
                        return Visibility.Visible;
                    }
                }
                else if (value is int)
                {
                    if (parameter == null)
                    {
                        if ((int)value > 0)
                            return Visibility.Visible;
                        return Visibility.Collapsed;
                    }
                    else if (parameter.Equals("Not"))
                    {
                        if ((int)value > 0)
                            return Visibility.Collapsed;
                        return Visibility.Visible;
                    }
                }
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
