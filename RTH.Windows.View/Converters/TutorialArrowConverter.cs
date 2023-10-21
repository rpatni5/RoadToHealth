using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace RTH.Windows.Views.Converters
{
    public class TutorialArrowConverter : IMultiValueConverter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values != null && values.Count() > 0 && parameter != null && values[0]!=null)
            {
                var dictionary = values[1] as Dictionary<string, Rect>;
                if (dictionary != null)
                {
                    var d = (Dictionary<string, Rect>)values[1];
                    if (d.Count > 0)
                    {
                        if (parameter.Equals("Top"))
                        {
                            if(d[values[0] as string].Y >400)
                                return d[values[0] as string].Y - 21;

                            return d[values[0] as string].Y + d[values[0] as string].Height+1;
                        }
                        else if (parameter.Equals("Left"))
                        {
                            return d[values[0] as string].X + d[values[0] as string].Width/2-16;
                        }
                        else if (parameter.Equals("Arrow"))
                        {
                            if (d[values[0] as string].Y > 400)
                                return Geometry.Parse("M0,0 L0.5,1 1,0 0,0");

                            return Geometry.Parse("M0,1 L0.5,0 1,1 0,1");
                        }
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
