﻿using RTH.Windows.ViewModels.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Converters
{
    public class DiseaseIconConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(e => e == DependencyProperty.UnsetValue || e == null || string.IsNullOrEmpty(e.ToString())))
            {
                if (parameter == null)
                {
                    if (values[0].Equals("None"))
                    {
                        return new BitmapImage(new Uri(@"pack://application:,,,/Assets/white.png", UriKind.RelativeOrAbsolute));
                    }
                    if (values.Count() > 1 && values[1].Equals(HRAStatusEnum.Completed))
                    {
                        return App.SharedValues.DiseasePlainIcons[values[0].ToString()];
                    }
                    else if (values.Count() > 1 && values[1].Equals(HRAStatusEnum.Redo))
                    {
                        return new BitmapImage(new Uri(@"/RTH.Windows.Views;component/Assets/RedoPopup/ic_hra_redo.png", UriKind.Relative));
                    }
                    return App.SharedValues.DiseaseIcons[values[0].ToString()];

                }
                else if (parameter.Equals("FlipIcons"))
                {
                    if (values.Count() > 1 && values[1].Equals(HRAStatusEnum.Completed))
                    {
                        return App.SharedValues.DiseaseIcons[values[0].ToString()];
                    }
                    return App.SharedValues.DiseasePlainIcons[values[0].ToString()];
                }
            }
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
