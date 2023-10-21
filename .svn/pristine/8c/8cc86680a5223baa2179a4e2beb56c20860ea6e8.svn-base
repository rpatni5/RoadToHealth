using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Windows.Threading;
using System.Runtime.InteropServices;

namespace RTH.Windows.Views.Helpers
{
    public class AnimatedGIF : System.Windows.Controls.Image
    {
        private Bitmap _bitmap; // Local bitmap member to cache image resource
        private BitmapSource _bitmapSource;
        public delegate void FrameUpdatedEventHandler();


        /// <summary>
        /// Delete local bitmap resource
        /// Reference: http://msdn.microsoft.com/en-us/library/dd183539(VS.85).aspx
        /// </summary>
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool DeleteObject(IntPtr hObject);


        public enum LoaderEnum
        {
            Main,
            Diabetes,
            Cancer,
            Cardio,
            Lung,
            Dementia,
            Chat,
        }


        public LoaderEnum LoaderType
        {
            get { return (LoaderEnum)GetValue(LoaderTypeProperty); }
            set { SetValue(LoaderTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoaderType.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoaderTypeProperty =
            DependencyProperty.Register("LoaderType", typeof(LoaderEnum), typeof(AnimatedGIF), new FrameworkPropertyMetadata(LoaderEnum.Main, new PropertyChangedCallback(OnLoaderChange)));

        private static void OnLoaderChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as AnimatedGIF).SetLoader();
        }

        private void SetLoader()
        {
            if (LoaderType == LoaderEnum.Main)
            {
                _bitmap = Properties.Resources.loader;
            }
            else if (LoaderType == LoaderEnum.Diabetes)
            {
                _bitmap = Properties.Resources.diabetes;
            }
            else if (LoaderType == LoaderEnum.Cancer)
            {
                _bitmap = Properties.Resources.cancer;
            }
            else if (LoaderType == LoaderEnum.Cardio)
            {
                _bitmap = Properties.Resources.cardio;
            }
            else if (LoaderType == LoaderEnum.Dementia)
            {
                _bitmap = Properties.Resources.dementia;
            }
            else if (LoaderType == LoaderEnum.Lung)
            {
                _bitmap = Properties.Resources.lung;
            }
            else if (LoaderType == LoaderEnum.Chat)
            {
                _bitmap = Properties.Resources.chatLoader;
            }
            Width = _bitmap.Width;
            Height = _bitmap.Height;

            _bitmapSource = GetBitmapSource();
            Source = _bitmapSource;
            StartAnimate();
        }




        /// <summary>
        /// Override the OnInitialized method
        /// </summary>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += new RoutedEventHandler(AnimatedGIFControl_Loaded);
            this.Unloaded += new RoutedEventHandler(AnimatedGIFControl_Unloaded);
        }

        /// <summary>
        /// Load the embedded image for the Image.Source
        /// </summary>

        void AnimatedGIFControl_Loaded(object sender, RoutedEventArgs e)
        {
            SetLoader();
        }

        /// <summary>
        /// Close the FileStream to unlock the GIF file
        /// </summary>
        private void AnimatedGIFControl_Unloaded(object sender, RoutedEventArgs e)
        {
            StopAnimate();
        }

        /// <summary>
        /// Start animation
        /// </summary>
        public void StartAnimate()
        {
            ImageAnimator.Animate(_bitmap, OnFrameChanged);
        }

        /// <summary>
        /// Stop animation
        /// </summary>
        public void StopAnimate()
        {
            ImageAnimator.StopAnimate(_bitmap, OnFrameChanged);
        }

        /// <summary>
        /// Event handler for the frame changed
        /// </summary>
        private void OnFrameChanged(object sender, EventArgs e)
        {
            Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                   new FrameUpdatedEventHandler(FrameUpdatedCallback));
        }

        private void FrameUpdatedCallback()
        {
            ImageAnimator.UpdateFrames();

            if (_bitmapSource != null)
                _bitmapSource.Freeze();

            // Convert the bitmap to BitmapSource that can be display in WPF Visual Tree
            _bitmapSource = GetBitmapSource();
            Source = _bitmapSource;
            InvalidateVisual();
        }

        private BitmapSource GetBitmapSource()
        {
            IntPtr handle = IntPtr.Zero;

            try
            {
                handle = _bitmap.GetHbitmap();
                _bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
                    handle, IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                if (handle != IntPtr.Zero)
                    DeleteObject(handle);
            }

            return _bitmapSource;
        }

    }
}
