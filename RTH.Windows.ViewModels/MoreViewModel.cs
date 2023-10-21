using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class MoreViewModel : ViewModelBase
    {
        public MoreViewModel()
        {
            SetHeader();
        }

        private void SetHeader()
        {
            HeaderState = true;
            FooterVisibility = true;       
            SharingIconVisibility = false;
            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = false;
            //HeaderState = false;
            HeaderTitle = "More";
            KeyString = "None";

        }
    }
}
