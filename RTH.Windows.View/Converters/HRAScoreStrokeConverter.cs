﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class HRAScoreStrokeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter.Equals("StrokeColor"))
                {
                    if ((bool)value)
                        return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FFBFB9B9"); 
                    return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#FFEEEFEF");
                }
                else if (parameter.Equals("HRAMouseOver"))
                {
                    if ((int)value > 1)
                        return true;
                    return false;
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
