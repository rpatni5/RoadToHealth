﻿using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for AllQScoreView.xaml
    /// </summary>
    public partial class AllQScoreView : ViewBase
    {
        public AllQScoreView()
        {
            InitializeComponent();
        }

        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<AllQScoreViewModel>(refreshRequired: true);
            this.RefreshOnLoad = true;

            base.LoadViewModel();
        }
    }
}
