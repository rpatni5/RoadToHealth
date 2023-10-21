using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RTH.Windows.Views.Objects
{
    public class QuealthMenuItem : NotifyBase
    {
        public ICommand ExecuteCommand
        {
            get { return GetValue(() => this.ExecuteCommand); }
            set { SetValue(() => ExecuteCommand, value); }
        }
        public string DefaultIcon
        {
            get { return GetValue(() => this.DefaultIcon); }
            set { SetValue(() => DefaultIcon, value); }
        }
        public string HoverIcon
        {
            get { return GetValue(() => this.HoverIcon); }
            set { SetValue(() => HoverIcon, value); }
        }
        public string PressedIcon
        {
            get { return GetValue(() => this.PressedIcon); }
            set { SetValue(() => PressedIcon, value); }
        }
        public string MenuTitle
        {
            get { return GetValue(() => this.MenuTitle); }
            set { SetValue(() => MenuTitle, value); }
        }
        public bool IsChecked
        {
            get { return GetValue(() => this.IsChecked); }
            set { SetValue(() => IsChecked, value); }
        }
        public bool IsEnabled
        {
            get { return GetValue(() => this.IsEnabled); }
            set { SetValue(() => IsEnabled, value); }
        }
        public bool IsNotification
        {
            get { return GetValue(() => this.IsNotification); }
            set { SetValue(() => IsNotification, value); }
        }
        public Enums.ViewEnum ResultView
        {
            get { return GetValue(() => this.ResultView); }
            set { SetValue(() => ResultView, value); }
        }       
    }
}
