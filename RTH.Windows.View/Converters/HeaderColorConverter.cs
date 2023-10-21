using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class HeaderColorConverter : IMultiValueConverter
    {
        //[ValueConversion(typeof(string), typeof(string))]
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(e => e == DependencyProperty.UnsetValue || e == null))
            {
                if (parameter == null)
                {
                    if (App.SharedValues.WindowMain.CurrentView == Enums.ViewEnum.MoreView)
                        return new BrushConverter().ConvertFrom("#FF31AAE1");
                    else
                        return ((bool)values[0]) ? new BrushConverter().ConvertFrom(values[1].ToString()) : Brushes.Black;
                }
                else if (parameter.ToString() == "Original")
                {
                    return ((bool)values[0]) ? Brushes.White : new BrushConverter().ConvertFrom(values[1].ToString());
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
