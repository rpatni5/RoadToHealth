using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
   public class HealthlineGroupingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            switch (value.ToString())
            {
                case "back-red":
                    return App.SharedValues.LanguageResource.high_risk;
                case "back-amber":
                    return App.SharedValues.LanguageResource.medium_risk;
                case "back-green":
                    return App.SharedValues.LanguageResource.low_risk;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
