﻿using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using System.Collections.Generic;

namespace RTH.Business.Services
{
    public static class QuestionnaireService
    {
        public static HRA GetQuestionnaire(string id, string questionnaireId, string accessToken)
        {
            return Http.ExecuteGET<Response<HRA>>(string.Format("apis/get_user_questionnaire/{0}/{1}", id, questionnaireId), null, accessToken).data;
        }
        public static QuestionnairesResponse PutQuestionnaire(string id, string questionnaireId, string accessToken, List<AnswerRequest> oListAnaswer)
        {
            return Http.ExecutePOST<QuestionnairesResponse>(string.Format("apis/put_user_data/{0}/{1}", id, questionnaireId), oListAnaswer, accessToken);
        }

        public static Conversation GetMotivatonQuestionaire(string lang, string accessToken)
        {
            return Http.ExecuteGET<MotivationResponse>(string.Format("apis/get_other_questionnaire/alternate_1/{0}", lang), null, accessToken).data;
        }
        public static List<MotivationQuestionaire> GetHealthAgendaQuestionaire(string userId)
        {
            return Http.ExecuteGET<MotivationQuestionaireResponse>(string.Format("apis/get_alternate_answers/alternate_1/{0}", userId), null, null).data;
        }
        public static List<MotivationQuestionaire> GetPreamble2Questionaire(string userId)
        {
            return Http.ExecuteGET<MotivationQuestionaireResponse>(string.Format("apis/get_alternate_answers/pre_amble_2/{0}", userId), null, null).data;
        }

        public static List<MotivationQuestionaire> GetQuestionaireAnswers(string userId,string keyString)
        {
            return Http.ExecuteGET<MotivationQuestionaireResponse>(string.Format("apis/get_alternate_answers/{1}/{0}", userId, keyString), null, null).data;
        }


    }
}