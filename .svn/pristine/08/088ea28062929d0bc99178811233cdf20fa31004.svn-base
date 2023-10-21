using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using System.Windows;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProductSummaryView.xaml
    /// </summary>
    public partial class ProductSummaryView : ViewBase
    {
        public ProductSummaryView()
        {
            InitializeComponent();
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ProductSummaryViewModel>();
            base.LoadViewModel();

        }
        public override void OnViewLoaded()
        {
            partnerImage.Visibility = Visibility.Visible;            
        }
        public void SetProduct(Product _ProductSummary)
        {
            (this.ViewModel as ProductSummaryViewModel).ProductSummary = _ProductSummary;
            if (_ProductSummary != null)
                ViewModelBase.ExecuteTrackNavigation("products", "products-" + (this.ViewModel as ProductSummaryViewModel).ProductSummary.key_string, 1);
        }

        

    }
}
