using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.Views.UserControls
{
    public class ViewLocator
    {
        private static object lockObject = new object();
        private static ConcurrentDictionary<Type, ViewBase> _viewObjects = new ConcurrentDictionary<Type, ViewBase>();

        public static T Get<T>(params object[] args) where T : ViewBase
        {
            var type = typeof(T);

            if (_viewObjects.ContainsKey(type))
            {
                lock (lockObject)
                {
                    var view = _viewObjects[type] as T;
                    _viewObjects[type].Refresh();
                    return view;
                }
            }
            else //Register and Return
            {
                lock (lockObject)
                {
                    T view = default(T);
                    if (args.Any())
                        view = Activator.CreateInstance(type, true, args) as T;
                    else
                        view = Activator.CreateInstance(type, true) as T;

                    _viewObjects.AddOrUpdate(type, view, (t, v) => v);
                    return view;
                }
            }
        }
        public static T GetNew<T>(params object[] args) where T : ViewBase
        {
            var type = typeof(T);
            lock (lockObject)
            {
                if (args.Any())
                {
                    return Activator.CreateInstance(type, true, args) as T;
                }
                else
                {
                    return Activator.CreateInstance(type, true) as T;
                }
            }
        }

        public static void PerformCleanUp()
        {
            _viewObjects.Clear();
        }
    }
}
