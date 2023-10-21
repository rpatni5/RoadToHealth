using RTH.Business.Objects;
using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RTH.Windows.ViewModels.Common;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using Newtonsoft.Json;

namespace RTH.Windows.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel()
        {
            HeaderVisibility = false;
            FooterVisibility = false;
        }

        public int lastSelected { get; set; }
        public Variables GetLanguageVariables(string lang = "en")
        {
            return RTH.Business.Services.AppService.GetVariable(lang);
        }

        public IEnumerable<DiseaseInfo> FetchDiseaseIcons(string lang = "en")
        {
            Questionnaires qData = RTH.Business.Services.DashboardService.GetQuestionaires(Configurations.ClientId, lang);
            return qData.data;
        }
        public bool IsMotivationCompleted()
        {
            List<Answer> Motivations = null;
            MotivationQuestionaire obj = QuestionnaireService.GetHealthAgendaQuestionaire(UserDetails._id)?.FirstOrDefault(x => x.key_string == "your_motivations");
            if (obj != null)
            {
                List<Answer> answer = new List<Answer>();
                if (obj.element_type == "7")
                {
                    answer = JsonConvert.DeserializeObject<List<Answer>>(obj.answer.ToString());
                }
                else
                {
                    Answer objAnswer = JsonConvert.DeserializeObject<Answer>(obj.answer.ToString());
                    answer.Add(objAnswer);
                }
                Motivations = answer;
            }
            if (Motivations != null && Motivations.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
