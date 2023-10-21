﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using System.Windows;
using System.Windows.Input;
using RTH.Business.Services;

namespace RTH.Windows.ViewModels
{
    public class AboutUsViewModel : Common.ViewModelBase
    {
        #region Global Properties
        public string AboutUsData
        {
            get { return GetValue(() => this.AboutUsData); }
            set { SetValue(() => AboutUsData, value); }
        }

        public int SelectedTabId
        {
            get { return GetValue(() => this.SelectedTabId); }
            set { SetValue(() => SelectedTabId, value); }
        }
        #endregion Global Properties

        private AboutUsViewModel()
        {
            SharingIconVisibility = false;
            FooterVisibility = true;

            GetAboutUs();           
        }

        public void GetAboutUs()
        {
            AsyncCall.Invoke(() =>
            {
                AboutUsData = PolicyService.GetAboutUs(UserDetails.language).text;
                SetSharingData();
            });
        }

        private void SetSharingData()
        {
            string keyValue = "about";           
            SharingData = TwitterService.GetSharingData(ViewModelBase.UserDetails._id, keyValue, ViewModelBase.UserDetails.AuthToken.access_token);
            SharingData.thumb_image = Config.ApiUrl + SharingData.thumb_image;
            SharingData.name = "Quealth";
        }
    }
}
