using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class ScoreToRAGLightColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            String colorCode = "#00FFFFFF";
            if (value != null)
            {
                if (value is string)
                {
                    if (parameter == null)
                    {
                        colorCode = "#66FFFFFF";
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            int score = (int)System.Convert.ToDecimal(value.ToString());

                            if (score > 0 && score <= 20) colorCode = "#FFF3B8A4";
                            if (score > 20 && score <= 60) colorCode = "#FFF9D7AD";
                            if (score > 60) colorCode = "#FFB0DAAE";
                        }
                    }
                }
                else
                {
                    if (parameter == null)
                    {
                        double score;
                        double.TryParse(value.ToString(), out score);
                        if (score > 0 && score <= 20) colorCode = "#FFF3B8A4";
                        if (score > 20 && score <= 60) colorCode = "#FFF9D7AD";
                        if (score > 60) colorCode = "#FFB0DAAE";
                    }

                }
            }
            return colorCode;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
