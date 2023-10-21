using RTH.Windows.ViewModels.Objects;
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
    public class DiseaseIconIndicatorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!values.Any(e => e == DependencyProperty.UnsetValue || e == null))
            {
                if (parameter.Equals("checked"))
                {
                    return values[0].Equals(values[1]) ? true : false;
                }
                else
                {
                    var lst = values[0] as List<List<DiseaseData>>;
                    var disease = values[1] as List<DiseaseData>;
                    int index = lst.IndexOf(disease);
                    if (parameter.Equals("current"))
                    {
                        return index;
                    }
                    else if (parameter.Equals("previous"))
                    {
                        return index == 0 ? Visibility.Hidden : Visibility.Visible;

                    }
                    else if (parameter.Equals("next"))
                    {
                        return index < lst.Count - 1 ? Visibility.Visible : Visibility.Hidden;
                    }
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
