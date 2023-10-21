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
    public class SelectedQuestionHeaderConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null)
            {
                if (parameter == null)
                {
                    if (values[0].Equals(values[1]))
                        return Visibility.Visible;
                }
                else if (parameter.Equals("HeaderColor"))
                {
                    if (values[0].Equals(values[1]))
                    {
                        return new SolidColorBrush((Color)ColorConverter.ConvertFromString(values[2].ToString())); 
                    }
                    else
                    {
                        return  new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE7E7E7"));
                    }
                }
                else if (parameter.Equals("FontColor"))
                {
                    if (values[0].Equals(values[1]))
                    {
                        return Brushes.White;
                    }
                    else
                    {
                        return Brushes.Gray;
                    }
                }
                
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
