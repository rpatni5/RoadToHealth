using RTH.Business.Objects;
using RTH.Business.Services;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RTH.Windows.ViewModels
{
    public class ResultViewModel : ViewModels.Common.ViewModelBase
    {
        public List<DiseaseData> Diseases
        {
            get { return GetValue(() => this.Diseases); }
            set { SetValue(() => Diseases, value); }
        }
        public bool IsScore
        {
            get { return GetValue(() => this.IsScore); }
            set { SetValue(() => IsScore, value); }
        }
        public bool IsLifeStyle
        {
            get { return GetValue(() => this.IsLifeStyle); }
            set { SetValue(() => IsLifeStyle, value); }
        }


        public ResultViewModel()
        {
            SetHeader();
            SharingIconVisibility = true;
            PropertyChanged += OnSelectedDiseaseChanged;
            SelectedDisease = new DiseaseData(GlobalData.Default.ClickedHRA);
            if (SelectedDisease.KeyString == Configurations.LifeStyleKeyString)
            {
                IsLifeStyle = true;
                IsScore = false;
            }
            else
            {
                IsLifeStyle = false;
                IsScore = true;
            }
            LoadMainScores();

        }
        private async void OnSelectedDiseaseChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedDisease")
            {
                await Reload().ConfigureAwait(false);
            }
        }
        public override void Refresh()
        {
            SetHeader();
            SelectedDisease = new DiseaseData(GlobalData.Default.ClickedHRA);
            if (SelectedDisease.KeyString == Configurations.LifeStyleKeyString)
            {
                IsLifeStyle = true;
                IsScore = false;
            }
            else
            {
                IsLifeStyle = false;
                IsScore = true;
            }
            LoadMainScores();
        }

        private void LoadMainScores()
        {
            TotalScore = 0;
            OptimumScore = ViewModelBase.UserDetails.score_history.FirstOrDefault(x => x.questionnaire == null).optimum_score;
            TotalScore = UserDetails.score;
            DiabetesScore = AssignScore(Configurations.DiabetesId);
            CardioScore = AssignScore(Configurations.CardioId);
            DementiaScore = AssignScore(Configurations.DementiaId);
            LungsScore = AssignScore(Configurations.LungsId);
            CancerScore = AssignScore(Configurations.CancerId);
            Diseases = ViewModelLocator.Get<DashboardViewModel>().GetDiseasesData();
            //RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.AnimateHRA });
        }
        private async Task<bool> Reload()
        {
            LatestScoreSummary = null;
            Summary = null;
            IsLoaded = false;
            ScoreSummaries = null;
            //await SetSharingData().ConfigureAwait(false);
            await LoadHealthAreas().ConfigureAwait(false);
            return true;
        }

        private async Task<bool> LoadHealthAreas()
        {
            await AsyncCall.Invoke(() =>
            {
                Summary = ResultService.GetSummaries(UserDetails._id, SelectedDisease.ID, UserDetails.AuthToken.access_token).data;
                ObservableCollection<ScoreSummary> summaries = ResultService.GetScoreSummaryDetails(UserDetails._id, SelectedDisease.ID, UserDetails.AuthToken.access_token);
                if (summaries != null && summaries.Any())
                {
                    ObservableCollection<ScoreSummary> temp = new ObservableCollection<ScoreSummary>();
                    int idx = 0;
                    foreach (ScoreSummary s in summaries)
                    {
                        if (temp.Count < 7)
                        {
                            if (temp.Count > 0 && temp[idx - 1].total_score.Split('.')[0] != s.total_score.Split('.')[0])
                            {
                                temp.Add(s); idx += 1;
                            }
                            else if (temp.Count == 0)
                            {
                                temp.Add(s); idx += 1;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    ScoreSummaries = temp;
                    LatestScoreSummary = summaries[0];
                    RaiseLoadedEvent();
                }
                return true;
            });
            return true;
        }
        void SetHeader()
        {
            if (SelectedDisease != null)
            {
                HeaderTitle = SelectedDisease.Title;
                HeaderColor = SelectedDisease.BgColor;
                KeyString = SelectedDisease.KeyString;
                GlobalData.Default.LastVisitedDiseaseID = SelectedDisease.ID;
            }
            else
            {
                HeaderTitle = HeaderColor = KeyString = GlobalData.Default.LastVisitedDiseaseID = string.Empty;
            }
            HeaderVisibility = true;
            HeaderState = false;
            FooterVisibility = true;

            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = "";
            KeyString = "None";
        }

        private async Task<bool> SetSharingData()
        {
            string keyValue = "dashboard";
            if (SelectedDisease != null)
            {
                double score = AssignScore(SelectedDisease.ID);
                keyValue = score <= 59 ? string.Format("{0}_0_59", SelectedDisease.KeyString) : score <= 79 ? string.Format("{0}_60_79", SelectedDisease.KeyString) :
                    string.Format("{0}_80_100", SelectedDisease.KeyString);
            }
            SharingData = await AsyncCall.Invoke(() =>
            {
                return TwitterService.GetSharingData(ViewModelBase.UserDetails._id, keyValue, ViewModelBase.UserDetails.AuthToken.access_token);
            });
            SharingData.thumb_image = Config.ApiUrl + SharingData.thumb_image;
            SharingData.name = "Quealth";
            return true;
        }
        private double AssignScore(string Id)
        {
            ScoreHistory score = ViewModelBase.UserDetails.score_history.FirstOrDefault(x => x.questionnaire == Id);
            return score != null ? score.total_score : 0.00;
        }

        public ObservableCollection<QSummaries> Summary
        {
            get { return GetValue(() => Summary); }
            set { SetValue(() => Summary, value); }
        }
        public ScoreSummary LatestScoreSummary
        {
            get { return GetValue(() => LatestScoreSummary); }
            set { SetValue(() => LatestScoreSummary, value); }
        }

        public ObservableCollection<ScoreSummary> ScoreSummaries
        {
            get { return GetValue(() => ScoreSummaries); }
            set { SetValue(() => ScoreSummaries, value); }
        }

        #region new property
        public double OptimumScore
        {
            get { return GetValue(() => OptimumScore); }
            set { SetValue(() => OptimumScore, value); }
        }

        #endregion
    }
}
