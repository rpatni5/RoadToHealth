﻿using RTH.Helpers;
using System.Collections.Generic;
using System.Windows;

namespace RTH.Windows.Views.Objects
{
    public class TutorialContent : NotifyBase
    {
        public string KeyString
        {
            get { return GetValue(() => this.KeyString); }
            set { SetValue(() => KeyString, value); }
        }
        public Rect Bounds
        {
            get { return GetValue(() => this.Bounds); }
            set { SetValue(() => Bounds, value); }
        }
        public Dictionary<string,Rect> HeaderContent
        {
            get { return GetValue(() => this.HeaderContent); }
            set { SetValue(() => HeaderContent, value); }
        }
        public string FooterText
        {
            get { return GetValue(() => this.FooterText); }
            set { SetValue(() => FooterText, value); }
        }
        public int CurrentItem
        {
            get { return GetValue(() => this.CurrentItem); }
            set { SetValue(() => CurrentItem, value); }
        }
        public int TotalItem
        {
            get { return GetValue(() => this.TotalItem); }
            set { SetValue(() => TotalItem, value); }
        }
        public string HeaderText
        {
            get { return GetValue(() => this.HeaderText); }
            set { SetValue(() => HeaderText, value); }
        }
        
    }
}
