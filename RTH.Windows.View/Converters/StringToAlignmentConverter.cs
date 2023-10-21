﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class StringToAlignmentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                if (value != null)
                {
                    if (value.ToString() != string.Empty)
                        return HorizontalAlignment.Center;
                }
                return HorizontalAlignment.Left;
            }
            else if (parameter.Equals("Margin"))
            {
                if (value != null)
                {
                    if (value.ToString() != string.Empty)
                        return new Thickness(0, 0, 0, 0);
                }
                return new Thickness(76, 0, 0, 0);
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
