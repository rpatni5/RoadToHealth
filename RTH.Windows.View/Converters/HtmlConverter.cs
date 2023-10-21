﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace RTH.Windows.Views.Converters
{
    public class HtmlConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string content = value as string;
            string stratTags = @"<html><head>
            <style type='text/css'> 
                h1 { font-size: 1.4em; font-weight: 100; }
                h2 { font-size: 1.3em; font-weight: 100; }
                h3 { font-size: 1.2em; font-weight: 100; }
                h4 { font-size: 1.1em; font-weight: 100; }
                h5 { font-size: 1.0em; font-weight: 100; }
                h6 { font-size: 0.9em; font-weight: 100; }
                div.helpText {padding-top:10px;text-align:justify;line-height:125%;}
                body {overflow: auto; font-size:14px;padding:10px; font-family:Lato; margin:0px;}
            </style>
            </head><body>";
            string endTags = "</body></html>";
            string html = string.Concat(stratTags, content, endTags);
            return html;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
