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
    public class ScoreToMarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length <= 0) return null;
            double totalHeight = (double)values[0];
            string score = values[1].ToString();
            double controlHeight = (double)values[2];
            decimal value = 0;
            if (decimal.TryParse(score, out value))
                return new Thickness(0, 0, 0, System.Convert.ToDouble(value) / 100 * totalHeight - controlHeight / 2);// 
            return new Thickness(0);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
