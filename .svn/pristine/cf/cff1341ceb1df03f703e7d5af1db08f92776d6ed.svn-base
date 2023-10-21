
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RTH.Windows.Views.Controls
{
    public class ChatBox : Label
    {
        public ChatBox(string text, bool isResponse)
        {
            ControlTemplate template = new ControlTemplate(typeof(ChatBox));

            var outerPanel = new FrameworkElementFactory(typeof(StackPanel));
            outerPanel.SetValue(StackPanel.OrientationProperty, Orientation.Vertical);
            outerPanel.SetValue(MarginProperty, new Thickness(10, 0, 10, 0));

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(MarginProperty, new Thickness(8, 10, 8, 0));
            border.SetValue(Border.CornerRadiusProperty, new CornerRadius(15));

            var txt = new FrameworkElementFactory(typeof(TextBlock));
            txt.SetValue(FontSizeProperty, 14.0);
            txt.SetValue(MarginProperty, new Thickness(15));
            txt.SetValue(TextBlock.TextProperty, text);
            txt.SetValue(TextBlock.TextWrappingProperty, TextWrapping.Wrap);

            if (isResponse)
            {
                border.SetValue(BackgroundProperty, new BrushConverter().ConvertFrom("#FF5ABBE6"));
                txt.SetValue(ForegroundProperty, Brushes.White);
                border.SetValue(Border.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                border.AppendChild(txt);

                outerPanel.AppendChild(border);

                var chatImage = new FrameworkElementFactory(typeof(Image));
                chatImage.SetValue(Image.StretchProperty, Stretch.None);
                chatImage.SetValue(Image.SourceProperty, new BitmapImage(new Uri("pack://application:,,/Assets/blue-chat_arw_blue.png", UriKind.Absolute)));
                chatImage.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                chatImage.SetValue(MarginProperty, new Thickness(0, -11, 0, 0));

                outerPanel.AppendChild(chatImage);
                outerPanel.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Right);
            }
            else
            {
                var insidePanel = new FrameworkElementFactory(typeof(Grid));
                insidePanel.SetValue(Grid.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                var image = new FrameworkElementFactory(typeof(Image));
                image.SetValue(Image.StretchProperty, Stretch.None);
                image.SetValue(MarginProperty, new Thickness(15, 15, 0, 15));
                image.SetValue(Image.SourceProperty, new BitmapImage(new Uri("pack://application:,,/Assets/chat_q.png", UriKind.Absolute)));
                image.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                image.SetValue(Image.VerticalAlignmentProperty, VerticalAlignment.Top);

                insidePanel.AppendChild(image);

                txt.SetValue(TextBlock.MarginProperty, new Thickness(50, 10, 15, 10));
                txt.SetValue(ForegroundProperty, Brushes.Black);
                txt.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
                insidePanel.AppendChild(txt);

                border.SetValue(Border.HorizontalAlignmentProperty, HorizontalAlignment.Left);                
                border.SetValue(BackgroundProperty, Brushes.White);
                border.AppendChild(insidePanel);

                outerPanel.AppendChild(border);

                var chatImage = new FrameworkElementFactory(typeof(Image));
                chatImage.SetValue(Image.StretchProperty, Stretch.None);
                chatImage.SetValue(Image.SourceProperty, new BitmapImage(new Uri("pack://application:,,/Assets/chat_arw_white.png", UriKind.Absolute)));
                chatImage.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                chatImage.SetValue(MarginProperty, new Thickness(0, -11, 0, 0));

                outerPanel.AppendChild(chatImage);
                outerPanel.SetValue(StackPanel.HorizontalAlignmentProperty, HorizontalAlignment.Left);

            }



            template.VisualTree = outerPanel;
            this.SetValue(TemplateProperty, template);
            this.SetValue(HorizontalContentAlignmentProperty, HorizontalAlignment.Left);
        }
    }
}
