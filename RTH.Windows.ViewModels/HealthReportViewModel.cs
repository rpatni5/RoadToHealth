using RTH.Business.Objects;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class HealthReportViewModel : ViewModels.Common.ViewModelBase
    {

        public String HealthReportCoachImage
        {
            get { return GetValue(() => HealthReportCoachImage); }
            set { SetValue(() => HealthReportCoachImage, value); }
        }
        public Coache CoachesDetails
        {
            get; set;
        }
        public HealthReportViewModel()
        {
            AsyncCall.Invoke(() =>
            {
                if (ViewModelBase.UserDetails.coach != null)
                {
                    CoachesDetails = RTH.Business.Services.DashboardService.GetCoaches().data.Where(x => x._id.Equals(ViewModelBase.UserDetails.coach)).FirstOrDefault();
                    HealthReportCoachImage = Configurations.UploadUrlPath + @"coaches/" + CoachesDetails.image;
                }
            });
        }

        public async Task<object> SendReportEmail()
        {
            return await AsyncCall.Invoke(() =>
            {
                return RTH.Business.Services.DashboardService.ReportEmail(ViewModelBase.UserDetails._id);

            });
        }
    }
}
