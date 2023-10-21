using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class AllQScoreViewModel : ViewModelBase
    {
        #region Global Properties
        public string QSummeryData
        {
            get { return GetValue(() => this.QSummeryData); }
            set { SetValue(() => QSummeryData, value); }
        }        

        #endregion Global Properties
        public AllQScoreViewModel()
        {
            HeaderVisibility = false;
            Init();
            LoadMainScores();
        }

        public override void Refresh()
        {
            AsyncCall.Invoke(() =>
            {
                LoadMainScores();
            });
        }

        private void Init()
        {
            AsyncCall.Invoke(() =>
            {
                List<QSummery.Datum> lstData = RTH.Business.Services.AllQScoreService.GetQSummery(ViewModelBase.UserDetails._id, ViewModelBase.UserDetails.AuthToken.access_token).data;
                lstData.ForEach(c =>
                {
                    QSummeryData = QSummeryData + c.content;
                });
            });
        }

        private double AssignScore(string Id)
        {
            ScoreHistory score = ViewModelBase.UserDetails.score_history.FirstOrDefault(x => x.questionnaire == Id);
            return score != null ? 100 : 0.00;
        }
        private void LoadMainScores()
        {
            DiabetesScore = AssignScore(Configurations.DiabetesId);
            CardioScore = AssignScore(Configurations.CardioId);
            DementiaScore = AssignScore(Configurations.DementiaId);
            LungsScore = AssignScore(Configurations.LungsId);
            CancerScore = AssignScore(Configurations.CancerId);
        }
    }
}
