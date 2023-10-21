using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using RTH.Helpers;
using System.Windows.Media;
using System.Windows;

namespace RTH.Windows.Views.Controls
{
    public class ExtendedRadioButton : RadioButton
    {
        public ExtendedRadioButton()
        {
            //DependencyPropertyDescriptor.FromProperty(IsCheckedProperty, typeof(RadioButton)).AddValueChanged(this, OnIsCheckedChanged);
        }



        public SolidColorBrush CheckedBackground
        {
            get { return (SolidColorBrush)GetValue(CheckedBackgroundProperty); }
            set { SetValue(CheckedBackgroundProperty, value); }
        }


        // Using a DependencyProperty as the backing store for CheckedBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CheckedBackgroundProperty =
            DependencyProperty.Register("CheckedBackground", typeof(SolidColorBrush), typeof(ExtendedRadioButton),null);

        //private static void OnCheckedBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    ExtendedRadioButton erd = d as ExtendedRadioButton;
        //    if (erd.IsChecked.HasValue && erd.IsChecked.Value)
        //        erd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(e.NewValue.ToString()));
        //}

        //private void OnIsCheckedChanged(object sender, EventArgs e)
        //{
        //    (sender as ExtendedRadioButton).CheckedBackground = "#FFFFFF";
        //}
    }
}
