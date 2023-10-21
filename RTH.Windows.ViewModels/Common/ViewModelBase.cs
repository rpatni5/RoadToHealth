using System;
using System.Windows.Input;

using RTH.Helpers;
using RTH.Business.Objects;
using System.Configuration;
using RTH.Windows.ViewModels.Objects;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using RTH.Business.Services;
using RTH.Business.Objects.JSON;
using System.Linq;

namespace RTH.Windows.ViewModels.Common
{
    public delegate void LoadedEventHandler(object sender);
    public abstract class ViewModelBase : NotifyBase
    {
        public ViewModelBase()
        {
            GetAllConversation();
        }

        public static Questionnaires QuestionnaireData;
        public string TickColor
        {
            get { return GetValue(() => TickColor); }
            set { SetValue(() => TickColor, value); }
        }
        public List<Engagement> CoachingConversations
        {
            get { return GetValue(() => CoachingConversations); }
            set { SetValue(() => CoachingConversations, value); }
        }

        protected string clientDate
        {
            get
            {
                return (DateTime.Now.Subtract(new DateTime(1970, 1, 1))).TotalMilliseconds.ToString();
            }
        }
        protected string dateOffset
        {
            get
            {
                return (DateTime.UtcNow - DateTime.Now).TotalMinutes.ToString();
            }
        }
        protected void GetAllConversation()
        {
            AsyncCall.Invoke(() =>
            {
                if (UserDetails != null && !string.IsNullOrEmpty(UserDetails._id))
                {
                    CoachingConversations = CoachingDashboardService.GetAllConversation(UserDetails._id, clientDate, dateOffset, UserDetails.AuthToken.access_token);
                }
            }, false);
            //if (lst != null && lst.Count > 0)
            //{
            //    GetSpecificActivity(lst.FirstOrDefault()._id);
            //}
        }
        public virtual void Refresh()
        {
            GetAllConversation();
            IsLoaded = false;
        }
        public virtual void Refresh(bool withLoader)
        {
            GetAllConversation();
            IsLoaded = false;
        }
        public virtual void Reset()
        {
            GetAllConversation();
        }

        public static string preAmbleId;
        public ShareData SharingData
        {
            get { return GetValue(() => SharingData); }
            set { SetValue(() => SharingData, value); }
        }
        public Guid ViewToken
        {
            get { return GetValue(() => ViewToken); }
            set { SetValue(() => ViewToken, value); }
        }
        //"#FFD3D3D3";FF00A8E7
        public static string AppHeaderColor = "#f0f0f5";
        public static string AppHeaderBlueColor = "#4C5bc2ed";
        public bool SharingIconVisibility
        {
            get { return GetValue(() => SharingIconVisibility); }
            set { SetValue(() => SharingIconVisibility, value); }
        }
        public bool HeaderVisibility
        {
            get { return GetValue(() => HeaderVisibility); }
            set { SetValue(() => HeaderVisibility, value); }
        }
        public string HeaderTitle
        {
            get { return GetValue(() => this.HeaderTitle); }
            set { SetValue(() => HeaderTitle, value); }
        }
        public bool HeaderState
        {
            get { return GetValue(() => this.HeaderState); }
            set { SetValue(() => HeaderState, value); }
        }
        public string HeaderColor
        {
            get { return GetValue(() => this.HeaderColor); }
            set { SetValue(() => HeaderColor, value); }
        }
        public string KeyString
        {
            get { return GetValue(() => this.KeyString); }
            set { SetValue(() => KeyString, value); }
        }
        public bool FooterVisibility
        {
            get { return GetValue(() => this.FooterVisibility); }
            set { SetValue(() => FooterVisibility, value); }
        }
        public string LastVisitedDiseaseID
        {
            get { return GetValue(() => LastVisitedDiseaseID); }
            set
            {
                SetValue(() => LastVisitedDiseaseID, value);
            }
        }

        public double DementiaScore
        {
            get { return GetValue(() => this.DementiaScore); }
            set { SetValue(() => DementiaScore, value); }
        }
        public double CardioScore
        {
            get { return GetValue(() => this.CardioScore); }
            set { SetValue(() => CardioScore, value); }
        }
        public double DiabetesScore
        {
            get { return GetValue(() => this.DiabetesScore); }
            set { SetValue(() => DiabetesScore, value); }
        }
        public double LungsScore
        {
            get { return GetValue(() => this.LungsScore); }
            set { SetValue(() => LungsScore, value); }
        }
        public double TotalScore
        {
            get { return GetValue(() => this.TotalScore); }
            set { SetValue(() => TotalScore, value); }
        }

        public static List<DiseaseData> SaveDiseases
        {
            get;
            set;
        }

        public static void SubmitChatHRA(List<Answer> conversationAnswer)
        {

            List<AnswerRequest> oAnswerRequest = new List<AnswerRequest>();
            UserDetails.answers = UserDetails.answers ?? new List<Answer>();
            foreach (var item in ViewModelBase.conversationAnswer)
            {
                AnswerRequest obj = new AnswerRequest
                {
                    answer = item.answer == null ? "none" : item.answer,
                    date = Convert.ToString(DateTime.Now.Ticks),
                    key_string = item.key_string,
                    element_type = item.element_type,
                    question = item.question,
                    response2 = Convert.ToString(item.response2) == "" ? "none" : item.response2,
                    response1 = Convert.ToString(item.response1) == "" ? "none" : item.response1,
                    response = Convert.ToString(item.response) == "" ? "none" : item.response
                };
                oAnswerRequest.Add(obj);

                var ans = UserDetails.answers.FirstOrDefault(x => x.question == item.question);
                if (ans == null)
                {
                    UserDetails.answers.Remove(ans);
                }
                UserDetails.answers.Add(
                    new Answer()
                    {
                        answer = item.answer == null ? "none" : item.answer,
                        date = Convert.ToString(DateTime.Now.Ticks),
                        key_string = item.key_string,
                        element_type = item.element_type,
                        question = item.question,
                        response2 = Convert.ToString(item.response2) == "" ? "none" : item.response2,
                        response1 = Convert.ToString(item.response1) == "" ? "none" : item.response1,
                        response = Convert.ToString(item.response) == "" ? "none" : item.response
                    });
            }
            QuestionnairesResponse oQuestionnairesResponse = QuestionnaireService.PutQuestionnaire(UserDetails._id, preAmbleId, UserDetails.AuthToken.access_token, oAnswerRequest);

            UpdateDataAterQuestionnaire(oQuestionnairesResponse); ;

        }

        private static void UpdateDataAterQuestionnaire(QuestionnairesResponse oQuestionnairesResponse)
        {
            //UserDetails.score = oQuestionnairesResponse.data.averageQ?? UserDetails.score;
            UserDetails.score_history = oQuestionnairesResponse.data.score_history ?? UserDetails.score_history;
            //UserDetails.age = oQuestionnairesResponse.data.age==;
            UserDetails.gender = oQuestionnairesResponse.data.gender;
            UserDetails.answered_questionnaire_ids_arr = oQuestionnairesResponse.data.answered_questionnaire_ids_arr ?? UserDetails.answered_questionnaire_ids_arr;
        }

        public double CancerScore
        {
            get { return GetValue(() => this.CancerScore); }
            set { SetValue(() => CancerScore, value); }
        }
        public String ErrorMessage
        {
            get { return GetValue(() => ErrorMessage); }
            set
            {
                SetValue(() => ErrorMessage, value);
            }
        }

        public String ErrorMessage2
        {
            get { return GetValue(() => ErrorMessage2); }
            set
            {
                SetValue(() => ErrorMessage2, value);
            }
        }

        public static string Errors { get; set; }
        public static String Lang
        {
            get; set;
        }
        public static String Country
        {
            get; set;
        }
        public static Variable AppMessages
        {
            get; set;
        }
        public static User UserDetails
        {
            get; set;
        }
        public String HeaderLabel
        {
            get { return GetValue(() => HeaderLabel); }
            set
            {
                SetValue(() => HeaderLabel, value);
            }
        }

        public static IDictionary<string, string> GetViewModelSettings()
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            foreach (SettingsProperty sp in Properties.Settings.Default.Properties)
            {
                dict.Add(sp.Name, Properties.Settings.Default.GetPropValue(sp.Name).ToString());
            }
            return dict;
        }

        public static bool ClearViewModelSettings()
        {
            ViewModelBase.UserDetails = null;
            ViewModelBase.conversationAnswer.Clear();
            Properties.Settings.Default.SocialType = string.Empty;
            ClearTwitterSettings();
            ClearFacebookSettings();

            return true;
        }
        public static bool ClearFacebookSettings()
        {
            Properties.Settings.Default.FacebookUserId = string.Empty;
            Properties.Settings.Default.Save();
            return true;
        }
        public static bool ClearTwitterSettings()
        {
            Properties.Settings.Default.TwitterUserId =
                Properties.Settings.Default.TwitterToken =
                Properties.Settings.Default.TwitterToken2 =
                Properties.Settings.Default.TwitterTokenSecret =
                Properties.Settings.Default.TwitterTokenSecret2 =
                Properties.Settings.Default.TwitterScreenName = string.Empty;
            Properties.Settings.Default.Save();
            return true;
        }
        public static bool SaveViewModelSettings(string SocialUserId, string SocialType)
        {
            if (SocialType == GlobalData.FACEBOOOK)
            {
                Properties.Settings.Default.FacebookUserId = SocialUserId;
            }
            else if (SocialType == GlobalData.TWITTER)
            {
                Properties.Settings.Default.TwitterUserId = SocialUserId;
            }
            Properties.Settings.Default.SocialType = SocialType;
            Properties.Settings.Default.Save();
            return true;
        }
        public User ValidateSocialLogin(string userId, string type)
        {
            //return RTH.Business.Services.UserService.ValidateSocialLogin(userId, type, Configurations.DefaultPassword.ToSecureString());
            return UserService.UserLogin(new Business.Objects.User() { socialmedia_id = userId, type = type });
        }

        public static VersionInfo GetLatestVersionInfo()
        {
            var infoResponse = AppService.GetLatestVersionInfo();
            if (infoResponse != null) return infoResponse.data;
            return null;
        }
        public DiseaseData SelectedDisease
        {
            get { return GetValue(() => SelectedDisease); }
            set { SetValue(() => SelectedDisease, value); }
        }

        public DiseaseData Disease
        {
            get { return GetValue(() => Disease); }
            set { SetValue(() => Disease, value); }
        }
        public static HealthQuestionnaireRequest HealthStrategyRequest
        {
            get; set;
        }

        public async Task<object> ExecuteHttp(string stringUrl)
        {
            return await RTH.Business.Services.Http.GetAsync(stringUrl);
        }

        public event LoadedEventHandler Loaded;
        /// <summary>
        /// Tells if the ViewModel is already loaded.
        /// </summary>
        public bool IsLoaded
        {
            get { return GetValue(() => IsLoaded); }
            protected set { SetValue(() => IsLoaded, value); }
        }
        /// <summary>
        /// Notifies anyone interested in handling the Loaded event.
        /// </summary>
        protected virtual void RaiseLoadedEvent()
        {
            IsLoaded = true;
            if (Loaded != null)
            {
                Loaded(this);
            }
        }
        public static List<Answer> conversationAnswer = new List<Answer>();
        public static void ExecuteTrackNavigation(string source_key_string,
                                                    string destination_key_string,
                                                    int screen)
        {
            //string access_token,
            //string user_id,
            source_key_string = source_key_string.ToLower();
            destination_key_string = destination_key_string.ToLower();
            if (source_key_string != "None")
            {
                if (ViewModelBase.UserDetails == null)
                {
                    GlobalData.lstTrackNavigation.Add(new TrackNavigation { user_id = null, access_token = null, destination_key_string = GlobalData.dictTrackViewName.ContainsKey(destination_key_string) ? GlobalData.dictTrackViewName[destination_key_string] : destination_key_string, source_key_string = GlobalData.dictTrackViewName.ContainsKey(source_key_string) ? GlobalData.dictTrackViewName[source_key_string] : source_key_string, screen = screen });
                }
            }
            if (ViewModelBase.UserDetails != null)
            {
                source_key_string = source_key_string == "HealthAreasView".ToLower() ? GlobalData.Default.ClickedHRA.KeyString + "-pha" : source_key_string;
                destination_key_string = destination_key_string == "HealthAreasView".ToLower() ? GlobalData.Default.ClickedHRA.KeyString + "-pha" : destination_key_string;

                source_key_string = source_key_string == "ResultView".ToLower() ? GlobalData.Default.ClickedHRA.KeyString + "-qsummary" : source_key_string;
                destination_key_string = destination_key_string == "ResultView".ToLower() ? GlobalData.Default.ClickedHRA.KeyString + "-qsummary" : destination_key_string;

                if (ViewModelBase.UserDetails.AuthToken == null)
                {
                    GlobalData.lstTrackNavigation.Add(new TrackNavigation { user_id = null, access_token = null, destination_key_string = GlobalData.dictTrackViewName.ContainsKey(destination_key_string) ? GlobalData.dictTrackViewName[destination_key_string] : destination_key_string, source_key_string = GlobalData.dictTrackViewName.ContainsKey(source_key_string) ? GlobalData.dictTrackViewName[source_key_string] : source_key_string, screen = screen });
                }
                else
                {
                    GlobalData.lstTrackNavigation.Add(new TrackNavigation { user_id = ViewModelBase.UserDetails._id, access_token = ViewModelBase.UserDetails.AuthToken.access_token, destination_key_string = GlobalData.dictTrackViewName.ContainsKey(destination_key_string) ? GlobalData.dictTrackViewName[destination_key_string] : destination_key_string, source_key_string = GlobalData.dictTrackViewName.ContainsKey(source_key_string) ? GlobalData.dictTrackViewName[source_key_string] : source_key_string, screen = screen });
                    if (GlobalData.lstTrackNavigation.Count > 0)
                    {
                        var navigations = GlobalData.lstTrackNavigation.ToArray();
                        NavigationTrackingService.TrackNavigation(navigations, ViewModelBase.UserDetails.AuthToken.access_token);
                        GlobalData.lstTrackNavigation.Clear();
                    }
                }

            }
        }


    }
}