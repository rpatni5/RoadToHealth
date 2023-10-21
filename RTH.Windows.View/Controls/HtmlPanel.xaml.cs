﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RTH.Windows.Views.Controls
{
    /// <summary>
    /// Interaction logic for HtmlPanel.xaml
    /// </summary>
    public partial class HtmlPanel : UserControl
    {
        public HtmlPanel()
        {
            InitializeComponent();
        }


        public string Html
        {
            get { return (string)GetValue(HtmlProperty); }
            set { SetValue(HtmlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Html.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HtmlProperty =
            DependencyProperty.Register("Html", typeof(string), typeof(HtmlPanel), new PropertyMetadata(null));

        private void HtmlPanel_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            scrMain.ScrollToTop();
        }  



        public string DiseaseName
        {
            get { return (string)GetValue(DiseaseNameProperty); }
            set { SetValue(DiseaseNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiseaseName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DiseaseNameProperty =
            DependencyProperty.Register("DiseaseName", typeof(string), typeof(HtmlPanel), new PropertyMetadata("Diabetes"));


    }
}
