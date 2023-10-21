using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Windows.ViewModels.Objects;
using System.Collections.Generic;

namespace RTH.Windows.ViewModels.Common
{
    public class GlobalData : NotifyBase
    {
        private GlobalData()
        {

        }
        private static GlobalData m_Instance;
        public static GlobalData Default
        {
            get
            {
                return m_Instance ?? (m_Instance = new GlobalData());
            }
        }
        public string LastVisitedDiseaseID
        {
            get { return GetValue(() => this.LastVisitedDiseaseID); }
            set { SetValue(() => LastVisitedDiseaseID, value); }
        }

        public bool LoaderVisibility
        {
            get { return GetValue(() => this.LoaderVisibility); }
            set { SetValue(() => LoaderVisibility, value); }
        }
        public List<ProductInfo> Products
        {
            get { return GetValue(() => this.Products); }
            set
            {

                SetValue(() => Products, value);
            }
        }
        public List<string> ProductsFilter
        {
            get { return GetValue(() => this.ProductsFilter); }
            set
            {

                SetValue(() => ProductsFilter, value);
            }
        }

        public DiseaseData ClickedHRA
        {
            get { return GetValue(() => this.ClickedHRA); }
            set { SetValue(() => ClickedHRA, value); }
        }

        public const string RED = "#FFE14E1B";
        public const string AMBER = "#f29100";
        public const string GREEN = "#76b72a";
        public const string FACEBOOOK = "facebook";
        public const string TWITTER = "twitter";

        public static List<TrackNavigation> lstTrackNavigation;
        public static Dictionary<string, string> dictTrackViewName = new Dictionary<string, string>
        {
            {"None", "None" },
            {"DashboardView", "dashboard" },
            {"ForgotPasswordView", "forgotPassword" },
            {"HomeView", "entry" },
            {"LoginView","login-in"},
            {"UserRegistrationView","register"},
            {"ResultView","result"},
            {"FaceBookAuthenticationView","facebookauthenticationview"},
            {"QuestionNavigatorView","questionnavigator"},
            {"SettingsView","setting"},
            {"FriendsOfQView","products"},
            {"RelatedProducts","relatedproducts"},
            {"FBUserRegistrationView","socialregistration"},
            {"ProductCategoriesView","products-categories"},
            {"HealthAreasView","healthareas"},
            {"DeactivateView","deactivate"},
            {"TermsAndConditionsView","termsandconditions"},
            {"TwitterAuthenticationView","twitterauthentication"},
            {"TwitterPost","twitterpost"},
            {"TwitterConnect","twitterconnect"},
            {"PolicyView","policy"},
            {"AllQScoreView","allQscore"},
            {"AboutUsView","about"},
            {"MWHealthierView","tell-a-friend"},
            {"DevicesServicesView","devices-Services"},
            {"ProductSummaryView","productsummary"},
            {"SupportView","supportview"},
            {"FaceBookSharingToWallView","facebooksharing"},
            {"ShowCoaches","welcome"},

        };
        public string[] UITrack = { "DashboardView", "LoginView", "UserRegistrationView", "ResultView", "SettingsView", "FriendsOfQView", "RelatedProducts", "ProductCategoriesView", "AllQScoreView", "AboutUsView", "MWHealthierView", "DevicesServicesView", "ShowCoaches" };
        
    }
}
