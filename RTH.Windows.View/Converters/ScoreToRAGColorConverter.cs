using RTH.Windows.ViewModels.Common;
using System;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class ScoreToRAGColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
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
                            int score=(int)System.Convert.ToDecimal(value.ToString());

                            if (score > 0 && score <= 20) colorCode = GlobalData.RED;
                            if (score > 20 && score <= 60) colorCode = GlobalData.AMBER;
                            if (score > 60) colorCode = GlobalData.GREEN;
                        }
                    }
                    else if (parameter.Equals("RiskString"))
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            int score = (int)System.Convert.ToDecimal(value.ToString());
                            if (score > 0 && score <= 20) return "High Risk";
                            if (score > 20 && score <= 60) return "Medium Risk";
                            if (score > 60) return "Low Risk";
                        }
                    }
                }
                else
                {
                    if (parameter == null)
                    {
                        double score;
                        double.TryParse(value.ToString(), out score);
                        if (score > 0 && score <= 20) colorCode = GlobalData.RED;
                        if (score > 20 && score <= 60) colorCode = GlobalData.AMBER;
                        if (score > 60) colorCode = GlobalData.GREEN;
                    }
                    else if (parameter.Equals("RiskString"))
                    {
                        if (!string.IsNullOrEmpty(value.ToString()))
                        {
                            double score;
                            double.TryParse(value.ToString(), out score);
                            if (score > 0 && score <= 20) return "High Risk";
                            if (score > 20 && score <= 60) return "Medium Risk";
                            if (score > 60) return "Low Risk";
                        }
                    }
                }
            }
            return new SolidColorBrush((Color)ColorConverter.ConvertFromString(colorCode));
        }



        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
