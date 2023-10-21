using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTH.Windows.Views.Helpers
{
    public class UIHelper
    {
        public static T FindParent<T>(DependencyObject fe, int level = 1) where T : DependencyObject
        {
            T parent = fe.FindAncestor<T>();
            if (parent != null && (!(parent is T) || level > 1))
            {
                return FindParent<T>(parent, level - 1);
            }
            return parent;
        }
    }
}
