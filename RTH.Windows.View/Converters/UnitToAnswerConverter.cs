﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class UnitToAnswerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) { return false; }
            if (value.ToString() == parameter.ToString()) return true;
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return null;
            bool val = (bool)value;
            if (val) return parameter.ToString();
            return string.Empty;
        }
    }
}
