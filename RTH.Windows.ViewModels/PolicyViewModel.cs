using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class PolicyViewModel: ViewModelBase
    {
        #region Global Properties
        public PrivatePolicy.Data PolicyData
        {
            get { return GetValue(() => this.PolicyData); }
            set { SetValue(() => PolicyData, value); }
        }
        #endregion Global Properties

        public PolicyViewModel()
        {
            Init();
        }

        private void Init()
        {
            AsyncCall.Invoke(() =>
            {
                PolicyData = RTH.Business.Services.PolicyService.GetPrivatePolicy(Lang ?? "en");
            });
        }
    }
}
