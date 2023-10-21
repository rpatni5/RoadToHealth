using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class HealthAgendaRiskAndColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                if (parameter.Equals("title"))
                {
                    switch (value.ToString())
                    {
                        case "low_risk":
                            return "LOW";
                        case "medium_risk":
                            return "MEDIUM";
                        case "high_risk":
                            return "HIGH";
                        default:
                            return null;
                    }
                }else if (parameter.Equals("color"))
                {
                    switch (value.ToString())
                    {
                        case "low_risk":
                            return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#76b72a"); 
                        case "medium_risk":
                            return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#f29100"); 
                        case "high_risk":
                            return (SolidColorBrush)(new BrushConverter()).ConvertFromString("#e5332a");
                        default:
                            return null;
                    }
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
