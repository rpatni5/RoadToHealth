using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class NavigationTrackingService
    {
        public static void TrackNavigation(IEnumerable<TrackNavigation> olstTrackNavigation, string accessToken)
        {
            Http.PostAsync("users/api/record_user_activity", olstTrackNavigation, accessToken);
        }
    }
}
