﻿using RTH.Windows.ViewModels.Objects;
using RTH.Helpers;

namespace RTH.Windows.ViewModels.Common
{
    public static class Configurations
    {
        public static string ImagePath
        {
            get
            {
                return Config.ApiUrl != null ? string.Concat(Config.ApiUrl, "uploads/hra/new/") : string.Empty;
            }
        }
        public static string OldImagePath
        {
            get
            {
                return Config.ApiUrl != null ? string.Concat(Config.ApiUrl, "uploads/hra/") : string.Empty;
            }
        }
        public static string ApiKey
        {
            get
            {
#if PRODUCTION
                return "";
#endif
#if STAG
                return "S";
#endif
#if DEBUG
                return "D(Debug)";
#endif
#if RELEASE
                return "D";
#endif
            }
        }
        public static string UploadUrlPath
        {
            get
            {
                return Config.ApiUrl != null ? string.Concat(Config.ApiUrl, "uploads/") : string.Empty;
            }
        }
        public static string DefaultPassword
        {
            get
            {
                return "1111";
            }
        }
        public static string CancerImagePath
        {
            get
            {
                return string.Concat(baseImagePath, "21.png");
            }
        }

        private static string baseImagePath = "/RTH.Windows.Views;component/Assets/";
        public static string DementiaId = "54bd0b493c0ac6fe880b7e62";
        public static string CardioId = "54192bbc6330920800fe70cd";
        public static string DiabetesId = "537f675a2140f60800de4531";
        public static string LungsId = "548b2333ae8f826f1898a78f";
        public static string CancerId = "54192ba46330920800fe70c8"; 
        public static string LifeStyleKeyString = "smoking_lifestyle_assessment"; 

        public static string FlashStatement
        {
            get
            {
                return "flash statement";
            }
        }
        public static DiseaseData ClickedHRA { get; set; }
        public static string ClientId
        {
            get
            {
                return "5416abeb5f0f21080024fe71";
            }
        }
        public static string BACK_GREEN
        {
            get
            {
                return "back-green";
            }
        }
        public static string BACK_GREEN_VALUE
        {
            get
            {
                return "#76b72a";
            }
        }
        public static string BACK_AMBER
        {
            get
            {
                return "back-amber";
            }
        }
        public static string BACK_AMBER_VALUE
        {
            get
            {
                return "#f29100";
            }
        }
        public static string BACK_RED
        {
            get
            {
                return "back-red";
            }
        }
        public static string BACK_RED_VALUE
        {
            get
            {
                return "#e5332a";
            }
        }
        public static string STATIC_CODE_G
        {
            get
            {
                return "g";
            }
        }
        public static string STATIC_CODE_A
        {
            get
            {
                return "a";
            }
        }
        public static string STATIC_CODE_R
        {
            get
            {
                return "r";
            }
        }
        public static string HAPPY_SMILY
        {
            get
            {
                return string.Concat(baseImagePath, "drawable/exited_insight.png");
            }
        }
        public static string THINKING_SMILY
        {
            get
            {
                return string.Concat(baseImagePath, "drawable/smily_insight.png");
            }
        }
        public static string SAD_SMILY
        {
            get
            {
                return string.Concat(baseImagePath, "drawable/sad_insight.png");
            }
        }
        public static string CUSTOM_DEACTIVATION_TEXT
        {
            get
            {
                return "Other, please explain further:";
            }
        }
        public static string SELECT_DEACTIVATION_REASON
        {
            get
            {
                return "Please select a deactivation reason.";
            }
        }
        public static string NORMAL_USER_TYPE
        {
            get
            {
                return "normal";
            }
        }
        public static string NAME_UPDATED
        {
            get
            {
                return "Name updated successfully.";
            }
        }
        public static string EMAIL_UPDATED
        {
            get
            {
                return "Email updated successfully.";
            }
        }
        public static string PASSWORD_UPDATED
        {
            get
            {
                return "Password updated successfully.";
            }
        }
        public static string LANGUAGE_UPDATED
        {
            get
            {
                return "Language updated successfully.";
            }
        }
        public static string COUNTRY_UPDATED
        {
            get
            {
                return "Health Guidelines updated successfully.";
            }
        }
        public static string TwitterAccessBaseUrl
        {
            get
            {
                return "https://api.twitter.com/";
            }
        }
        public static string AndroidQuealthUrl
        {
            get
            {
                return "https://play.google.com/store/apps/details?id=com.roadtohealth.qscore";
            }
        }
        public static string IosQuealthUrl
        {
            get
            {
                return "https://itunes.apple.com/gb/app/health-wellbeing-assessment/id1013837824?mt=8";
            }
        }

        public static int TwitterCharacterLimit
        {
            get
            {
                return 135;
            }
        }
        public static int TwitterUrlLength
        {
            get
            {
                return 22;
            }
        }

        public static string FacebookClientID
        {
            get
            {
                return "774094325978804";
                //return "1626126174305294";
            }
        }

        public static string PasswordRegex
        {
            get
            {
                return @"^(?=.*[a-z])(?=(.*[^a-zA-Z\d])|(?=.*\d){1,}).{6,}$";
                //return "1626126174305294";
            }
        }

        public static int CurrentBuild
        {
            get
            {
                int build = 0;
                int.TryParse(System.Configuration.ConfigurationManager.AppSettings.Get("CurrentBuild"),out build);
                return build;
            }
        }
    }
}
