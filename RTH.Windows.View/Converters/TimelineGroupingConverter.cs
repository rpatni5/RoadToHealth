using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class TimelineGroupingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {           
            DateTime date = System.Convert.ToDateTime(value);
            return date.Date == DateTime.Today ? "Today" : date.Date ==
                DateTime.Today.AddDays(-1).Date ? "Yesterday" : date.ToString("d MMMM"); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
