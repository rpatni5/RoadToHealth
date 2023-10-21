using System.Collections.Generic;
using System.Configuration;
using RTH.Helpers;

namespace RTH.Business.Objects.JSON
{
    public partial class FriendsOfQ
    {

    }
    public partial class ProductType
    {
        public string ProductImage
        {
            get
            {
                return string.Concat(Config.ApiUrl, this.image);
            }
        }
    }
    public partial class Product : NotifyBase
    {
        public string ThumbIcon
        {
            get
            {
                return string.Concat(Config.ApiUrl, this.thumb_image);
            }
        }

        public string MainImage
        {
            get
            {
                return string.Concat(Config.ApiUrl, this.main_image);
            }
        }

        public bool IsVisible
        {
            get { return GetValue(() => this.IsVisible); }
            set { SetValue(() => this.IsVisible, value); }
        }

        public Dictionary<string, bool> DiseaseIcons { get; set; }
    }

    public partial class Client
    {
        public string LogoImage
        {
            get
            {
                return string.Concat(Config.ApiUrl, this.image);
            }
        }
    }
}
