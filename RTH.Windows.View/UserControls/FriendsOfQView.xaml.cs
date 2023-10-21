﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for FriendsOfQView.xaml
    /// </summary>
    public partial class FriendsOfQView : ViewBase
    {
        public FriendsOfQView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<FriendsOfQViewModel>(refreshRequired:true);
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }

        public  void PerformTask(string param)
        {
            switch (param)
            {
                case "foq":
                    (this.ViewModel as FriendsOfQViewModel).FriendsOfQ();
                    break;
                case "products":
                    (this.ViewModel as FriendsOfQViewModel).RelatedProducts();
                    break;
            }
        }
    }
}
