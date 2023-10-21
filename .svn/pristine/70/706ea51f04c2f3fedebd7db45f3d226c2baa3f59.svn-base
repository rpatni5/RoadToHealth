using RTH.Windows.ViewModels;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RTH.Windows.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ProductCategoriesView.xaml
    /// </summary>
    public partial class ProductCategoriesView : ViewBase
    {

        List<ProductInfo> oListProduct;
        public ProductCategoriesView()
        {
            InitializeComponent();
            
        }
        public override void LoadViewModel()
        {
            this.ViewModel = ViewModelLocator.Get<ProductCategoriesViewModel>();
            base.LoadViewModel();
        }
        private void CheckBox_Loaded(object sender, RoutedEventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            List<ProductInfo> P = (List<ProductInfo>)ProductList.ItemsSource;
            chk.IsChecked = false;
            chk.IsChecked = P.Any(x => x.ID == chk.Tag.ToString() && x.IsChecked == true);
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            oListProduct = (List<ProductInfo>)GlobalData.Default.Products;
            CheckBox chkMultiSelect = sender as CheckBox;
            List<ProductInfo> ProductList = new List<ProductInfo>();
            if (chkMultiSelect.IsChecked == true)
            {
                if (chkMultiSelect.Tag.ToString() == string.Empty)
                {
                    foreach (var item in oListProduct)
                    {
                        if (item.ID == string.Empty)
                        {
                            ProductList.Add(new ProductInfo { ID = item.ID, Name = item.Name, ProductImage = item.ProductImage, Products = item.Products, IsChecked = true });
                        }
                        else
                        {
                            ProductList.Add(new ProductInfo { ID = item.ID, Name = item.Name, ProductImage = item.ProductImage, Products = item.Products, IsChecked = false });
                        }
                    }
                }
                else
                {
                    foreach (var item in oListProduct)
                    {
                        if (item.ID == string.Empty)
                        {
                            ProductList.Add(new ProductInfo { ID = item.ID, Name = item.Name, ProductImage = item.ProductImage, Products = item.Products, IsChecked = false });
                        }
                        else
                        {
                            if (item.ID == chkMultiSelect.Tag.ToString())
                            {
                                ProductList.Add(new ProductInfo { ID = item.ID, Name = item.Name, ProductImage = item.ProductImage, Products = item.Products, IsChecked = true });
                            }
                            else
                            {
                                ProductList.Add(item);
                            }
                        }
                    }
                }
            }
            else
            {
                var Item = GlobalData.Default.Products.Where(x => x.ID.Equals(chkMultiSelect.Tag.ToString())).FirstOrDefault();
                int index = GlobalData.Default.Products.IndexOf((ProductInfo)Item);
                ProductInfo P = (ProductInfo)Item;
                P.IsChecked = false;
                GlobalData.Default.Products.Remove((ProductInfo)Item);
                GlobalData.Default.Products.Insert(index, P);
            }
            if (ProductList.Count > 0)
            {
                GlobalData.Default.Products = ProductList;
            }

        }
    }
}