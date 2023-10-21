using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class HealthAreaSummaryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length == 0 || values[0] == null || values[1] == null) return string.Empty;
            bool? isChecked = (bool?)values[1];
            HealthArea ha = values[0] as HealthArea;
            if (isChecked.HasValue && isChecked.Value) return ha.detail;
            else {
                if (ha.summary != string.Empty)
                {
                    if (ha.summary.Substring(0, 6).Contains("h1") || ha.summary.Substring(0, 6).Contains("h2") || ha.summary.Substring(0, 6).Contains("h3"))
                    { return ha.summary + "<br/> <br/>"; }
                    else return " <br/> <br/> <br/>" + ha.summary + "<br/> <br/>";
                }
                else return ha.summary;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
