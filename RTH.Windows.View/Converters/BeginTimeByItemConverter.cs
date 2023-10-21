using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class BeginTimeByItemConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ctl = values[0] as ItemsControl;
            if (ctl != null && parameter==null)
            {
                var container = ctl.ItemContainerGenerator.ContainerFromItem(values[1]);
                var index = ctl.ItemContainerGenerator.IndexFromContainer(container);
                return TimeSpan.FromSeconds(0.3 * index);
            }else if (ctl != null && parameter.Equals("Home"))
            {
                var container = ctl.ItemContainerGenerator.ContainerFromItem(values[1]);
                var index = ctl.ItemContainerGenerator.IndexFromContainer(container);
                return TimeSpan.FromSeconds(3 * index);
            }
            return TimeSpan.Zero;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
