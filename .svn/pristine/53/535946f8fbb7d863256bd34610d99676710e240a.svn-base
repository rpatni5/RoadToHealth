using RTH.Business.Objects.JSON;
using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels.Objects
{
    public class ProductInfo : NotifyBase
    {
        public string ID
        {
            get { return GetValue(() => this.ID); }
            set { SetValue(() => ID, value); }
        }
        public string Name
        {
            get { return GetValue(() => this.Name); }
            set { SetValue(() => Name, value); }
        }
        public string ProductImage
        {
            get { return GetValue(() => this.ProductImage); }
            set { SetValue(() => ProductImage, value); }
        }
        public bool IsChecked
        {
            get { return GetValue(() => this.IsChecked); }
            set { SetValue(() => IsChecked, value); }
        }
        public List<Product> Products
        {
            get { return GetValue(() => this.Products); }
            set { SetValue(() => Products, value); }
        }
    }
}
