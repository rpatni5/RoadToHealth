﻿using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Services
{
    public static class ResultService
    {
        public static Response<ObservableCollection<QSummaries>> GetSummaries(string userId, string qId, string accessToken)
        {
            return Http.ExecuteGET<Response<ObservableCollection<QSummaries>>>("apis/get_qsummaries/" + userId + "/" + qId, null, accessToken);
        }
        
        public static ObservableCollection<ScoreSummary> GetScoreSummaryDetails(string userId, string qId, string accessToken)
        {
            return Http.ExecuteGET<Response<ObservableCollection<ScoreSummary>>>("apis/score_history/" + userId + "/" + qId, null, accessToken).data;

        }
    }
}
