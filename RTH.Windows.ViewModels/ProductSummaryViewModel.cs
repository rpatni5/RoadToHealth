﻿using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class ProductSummaryViewModel : ViewModelBase
    {
        public ProductSummaryViewModel()
        {
            SharingIconVisibility = false;
        }

        #region Global Properties
        public Product ProductSummary
        {
            get { return GetValue(() => this.ProductSummary); }
            set
            {
                SetValue(() => ProductSummary, value);
                SetSharingData();

            }
        }

        #endregion Global Properties

        private void SetSharingData()
        {
            if (ProductSummary != null)
            {
                SharingData = new ShareData()
                {
                    title = "Check this out!",
                    name = "Quealth",
                    description = "Quealth\'s just recommened this cool health product - thought you might be interested...!",
                    url = ProductSummary.url,
                    thumb_image = ProductSummary.MainImage,
                    twitter_title = "Check this out! Quealth\'s just recommened this cool health product - thought you might be interested...! "+
                    ProductSummary.MainImage
                };
            }
        }
    }
}
