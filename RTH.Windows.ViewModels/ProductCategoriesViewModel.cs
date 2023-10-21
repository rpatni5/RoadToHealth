using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class ProductCategoriesViewModel : FriendsOfQViewModel
    {
        public ProductCategoriesViewModel() : base()
        {
            FooterVisibility = false;
        }
        private RelayCommand m_ProductListCommand;
        public RelayCommand ProductListCommand
        {
            get
            {
                return m_ProductListCommand ?? (m_ProductListCommand = new RelayCommand(
                    ve => ExecuteCategories(ve), (t) => true));
            }
        }

        private void ExecuteCategories(object ve)
        {
            if (ve != null)
            {
                ProductInfo productInfo = (ProductInfo)ve;                
                NonFeatureProduct = GlobalData.Default.Products.Where(x => x.IsChecked == true).ToList();
            }
            
        }
    }
}
