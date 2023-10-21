using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Interop;

namespace RTH.Windows.Views.Helpers
{
    public class SingleInstanceHelper : IDisposable
    {
        private Mutex _mutexInstance = null;
        private uint m_Message;//= NativeMethods.RegisterWindowMessage(mutexName);
        private HwndSourceHook windowHook;

        public static IntPtr HWND_BROADCAST = new IntPtr(0xffff);

        [DllImport("user32.dll", EntryPoint = "RegisterWindowMessageW", SetLastError = true)]
        private static extern uint RegisterWindowMessage(string lpString);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private Window MainWindow = null;

        public bool Register()
        {
            bool createdNew;
            Assembly assembly = Assembly.GetExecutingAssembly();
            string mutexName = string.Format(@"Global:Quealth/{0}/{1}", assembly.GetType().GUID, Environment.UserName);

            _mutexInstance = new Mutex(true, mutexName, out createdNew);
            m_Message = RegisterWindowMessage(mutexName);

            if (!createdNew)
            {
                _mutexInstance = null;
                PostMessage(HWND_BROADCAST, m_Message, IntPtr.Zero, IntPtr.Zero);
                Application.Current.Shutdown();
                return false;
            }

            return true;
        }

        public void SetHook(Window window)
        {
            this.MainWindow = window;
            var windowHandle = (new WindowInteropHelper(window)).Handle;
            windowHook = new HwndSourceHook(HandleMessages);
            HwndSource.FromHwnd(windowHandle).AddHook(windowHook);
            App.SharedValues.IsHooked = true;
            this.MainWindow.Closing += MainWindow_Closing;
        }

        void MainWindow_Closing(object sender, EventArgs e)
        {
            this.MainWindow.Closing -= MainWindow_Closing;

            if (App.SharedValues.IsHooked)
            {
                var windowHandle = (new WindowInteropHelper(this.MainWindow)).Handle;
                HwndSource.FromHwnd(windowHandle).RemoveHook(windowHook);
                App.SharedValues.IsHooked = false;
            }
        }

        private IntPtr HandleMessages(IntPtr handle, Int32 message, IntPtr wParameter, IntPtr lParameter, ref Boolean handled)
        {
            if (message == m_Message)
            {
                if (MainWindow.WindowState == WindowState.Minimized)
                    MainWindow.WindowState = WindowState.Normal;

                MainWindow.Activate();
            }
            return IntPtr.Zero;
        }

        public void Dispose()
        {
            if (_mutexInstance != null)
            {
                _mutexInstance.ReleaseMutex();
                _mutexInstance.Close();
                _mutexInstance.Dispose();
            }
        }
    }
}
