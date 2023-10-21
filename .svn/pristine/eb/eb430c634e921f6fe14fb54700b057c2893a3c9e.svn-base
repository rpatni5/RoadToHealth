using RTH.Windows.Views.Helpers;
using RTH.Windows.Views.Objects;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for DashboardHeaderView.xaml
    /// </summary>
    public partial class DashboardHeaderView : UserControl
    {
        public DashboardHeaderView()
        {
            InitializeComponent();
        }
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiseaseText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(DashboardHeaderView), new PropertyMetadata(null));

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DiseaseImagePath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(DashboardHeaderView), new PropertyMetadata(null));

        public string ColorCode
        {
            get { return (string)GetValue(ColorCodeProperty); }
            set { SetValue(ColorCodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorCode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorCodeProperty =
            DependencyProperty.Register("ColorCode", typeof(string), typeof(DashboardHeaderView), new PropertyMetadata());

        public bool IsInverted
        {
            get { return (bool)GetValue(IsInvertedProperty); }
            set { SetValue(IsInvertedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsConverted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInvertedProperty =
            DependencyProperty.Register("IsInverted", typeof(bool), typeof(DashboardHeaderView), new PropertyMetadata(null));

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var window = ((Grid)sender).FindAncestor<Window>();
            if (e.LeftButton == MouseButtonState.Pressed && window != null)
            {
                window.DragMove();
            }
        }
        public void HideMenu()
        {
            if (tbtnExp.IsChecked == true)
                tbtnExp.IsChecked = false;
        }

        public TutorialContent GetTutorials()
        {
            var pt1 = this.tbtnExp.TranslatePoint(new Point(0, 0), App.SharedValues.WindowMain);
            TutorialContent _t = new TutorialContent();
            _t.Bounds = new Rect(pt1.X, pt1.Y, this.tbtnExp.ActualWidth, this.tbtnExp.ActualHeight);
            _t.CurrentItem = 1;
            _t.TotalItem = 10;
            _t.FooterText = "Tab any one of the above";
            _t.KeyString = "MenuIcon";
            _t.HeaderContent = new Dictionary<string, Rect>();
            _t.HeaderContent.Add(string.Empty, _t.Bounds);
            return _t;            
        }
    }
}
