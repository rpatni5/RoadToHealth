using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class GroupNameToSeperatorBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            if (value.ToString() == App.SharedValues.LanguageResource.high_risk) return GlobalData.RED;
            if (value.ToString() == App.SharedValues.LanguageResource.medium_risk) return GlobalData.AMBER;
            if (value.ToString() == App.SharedValues.LanguageResource.low_risk) return GlobalData.GREEN;
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
