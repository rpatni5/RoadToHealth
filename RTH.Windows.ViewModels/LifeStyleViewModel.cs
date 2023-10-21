using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using RTH.Windows.ViewModels.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class LifeStyleViewModel : ViewModelBase
    {
        public LifeStyleViewModel()
        {
            LoadPrimaryData();
        }
        public override void Refresh()
        {
            LoadPrimaryData();
            base.Refresh();
        }

        void SetHeader()
        {
            HeaderVisibility = true;
            KeyString = GlobalData.Default.ClickedHRA.KeyString;
            HeaderState = false;
            //HeaderColor = Questionnaire.background_colour;
            //HeaderTitle = Questionnaire.title;
        }

        public bool LifestyleVisibility
        {
            get { return GetValue(() => LifestyleVisibility); }
            set { SetValue(() => LifestyleVisibility, value); }
        }
        public PHA PHADetails
        {
            get { return GetValue(() => PHADetails); }
            set { SetValue(() => PHADetails, value); }
        }
        public HealthArea CurrentHealthArea
        {
            get { return GetValue(() => CurrentHealthArea); }
            set { SetValue(() => CurrentHealthArea, value); }
        }

        public List<LifeStylePHA> LifeStylePHA
        {
            get { return GetValue(() => LifeStylePHA); }
            set { SetValue(() => LifeStylePHA, value); }
        }

        private void LoadPrimaryData()
        {
            AsyncCall.Invoke(() =>
            {
                List<LifeStylePHA> lst = new List<LifeStylePHA>();

                //CurrentHealthArea = PHADetails[0].;

                ViewModelBase.SaveDiseases.Where(x => x.type == 4).ToList().ForEach(c =>
                {
                    var ques = UserDetails.answered_questionnaire_ids_arr.FirstOrDefault(x => x.questionnaire == c.ID);
                    if (ques != null)
                    {
                        PHADetails = HealthAreasService.GetPHA(UserDetails._id, ques.questionnaire, UserDetails.AuthToken.access_token);

                        lst.Add(new LifeStylePHA() { Disease = c, HealthAreas = PHADetails.health_areas.ToList(), IsCompleted = true });
                    }
                    else
                    {
                        lst.Add(new LifeStylePHA() { Disease = c, HealthAreas = null, IsCompleted = false });
                    }


                });
                LifeStylePHA = lst;

            });
        }
        private RelayCommand _showSummaryCommand;
        public RelayCommand ShowSummaryCommand
        {
            get
            {
                return _showSummaryCommand ?? (_showSummaryCommand = new RelayCommand(vm =>
                {
                    if (vm == null) throw new ArgumentNullException("PHA details are not provided");
                    CurrentHealthArea = vm as HealthArea;

                },
                vm => { return true; }));
            }
        }
    }


    public class LifeStylePHA : NotifyBase
    {
        public bool IsCompleted
        {
            get { return GetValue(() => IsCompleted); }
            set { SetValue(() => IsCompleted, value); }
        }
        public DiseaseData Disease
        {
            get { return GetValue(() => Disease); }
            set { SetValue(() => Disease, value); }
        }
        public List<HealthArea> HealthAreas
        {
            get { return GetValue(() => HealthAreas); }
            set { SetValue(() => HealthAreas, value); }
        }
    }
}
