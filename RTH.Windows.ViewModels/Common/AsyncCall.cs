﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels.Common
{
    public static class AsyncCall
    {
        public static async void Invoke(Action action, bool showLoader = true)
        {
            if (showLoader)
                GlobalData.Default.LoaderVisibility = true;
            await Task.Run(action);
            if (showLoader)
                GlobalData.Default.LoaderVisibility = false;
        }

        public static async Task<T> Invoke<T>(Func<T> action, bool showLoader = true)
        {
            if (showLoader)
                GlobalData.Default.LoaderVisibility = true;
            var data = await Task.Run<T>(action);
            if (showLoader)
                GlobalData.Default.LoaderVisibility = false;
            return data;
        }
    }
}
