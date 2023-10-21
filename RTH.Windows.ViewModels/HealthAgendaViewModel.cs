using Newtonsoft.Json;
using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class HealthAgendaViewModel : ViewModelBase
    {
        private void Init()
        {
            HeaderState = false;
            HeaderColor = ViewModelBase.AppHeaderColor;
            FooterVisibility = false;
            SharingIconVisibility = true;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = "Health Agenda";
            KeyString = "None";
        }
        public HealthAgendaViewModel()
        {
            AsyncCall.Invoke(() =>
            {
                Init();
                GetHealthPHA();
            });
        }

        public List<HealthAgenda> HealthAreas
        {
            get { return GetValue(() => HealthAreas); }
            set { SetValue(() => HealthAreas, value); }
        }

        public List<Answer> Motivations
        {
            get { return GetValue(() => Motivations); }
            set { SetValue(() => Motivations, value); }
        }

        public Answer HealthRisk
        {
            get { return GetValue(() => HealthRisk); }
            set { SetValue(() => HealthRisk, value); }
        }
        public bool MotivationVisibility
        {
            get { return GetValue(() => this.MotivationVisibility); }
            set { SetValue(() => MotivationVisibility, value); }
        }
        private void GetMotivation()
        {
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
                MotivationVisibility = true;
            }
            else
            {
                MotivationVisibility = false;
            }

            Answer risk = new Answer()
            {
                answer = "You've taken the Diabetes health assessment - here's how your risk profile breaks down:",
                next_steps = string.Empty
            };
            HealthRisk = risk;
        }

        private void GetHealthPHA()
        {
            var area = HealthPlanServices.GetHealthAgendaPHA(UserDetails._id);
            HealthAreas = area.Where(x=>x.value!=null && x.value.Count>0).ToList();
            GetMotivation();
        }

      
    }
}
