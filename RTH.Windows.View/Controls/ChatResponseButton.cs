﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Controls
{
    public class ChatResponseButton : Button
    {
        public ChatResponseButton(string text)
        {
            ControlTemplate template = new ControlTemplate(typeof(ChatResponseButton));

            var outerPanel = new FrameworkElementFactory(typeof(StackPanel));
            outerPanel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            outerPanel.SetValue(MarginProperty, new Thickness(10, 0, 10, 0));

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));
            border.SetValue(MarginProperty, new Thickness(20, 10, 8, 0));
            border.SetValue(BackgroundProperty, new BrushConverter().ConvertFrom("#FF5ABBE6"));
            border.SetValue(Border.HorizontalAlignmentProperty, HorizontalAlignment.Right);

            var txt = new FrameworkElementFactory(typeof(TextBlock));
            txt.SetValue(FontSizeProperty, 14.0);
            txt.SetValue(MarginProperty, new Thickness(15));
            txt.SetValue(ForegroundProperty, Brushes.White);
            txt.SetValue(TextBlock.TextProperty, text);
            txt.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);

            border.AppendChild(txt);

            outerPanel.AppendChild(border);

            var chatImage = new FrameworkElementFactory(typeof(Image));
            chatImage.SetValue(Image.StretchProperty, Stretch.None);
            chatImage.SetValue(Image.SourceProperty, new BitmapImage(new Uri("pack://application:,,/Assets/blue-chat_arw_blue.png")));
            chatImage.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            chatImage.SetValue(MarginProperty, new Thickness(0, -11, 0, 0));

            outerPanel.AppendChild(chatImage);
            outerPanel.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Right);


            template.VisualTree = outerPanel;
            this.SetValue(TemplateProperty, template);
            this.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Right);
            this.SetValue(CursorProperty, System.Windows.Input.Cursors.Hand);
        }
    }
}
