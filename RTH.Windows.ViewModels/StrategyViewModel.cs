﻿using RTH.Business.Objects;
using RTH.Business.Services;
using RTH.Helpers.Messaging;
using RTH.Windows.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace RTH.Windows.ViewModels
{
    public class StrategyViewModel : ViewModelBase
    {
        public StrategyViewModel()
        {
            SetHeader();
            LeftObjectives = StrategyViewModel.NoOfObjectivesLeft;
        }
        public HealthPlanObjective CurrentHPO
        {
            get { return GetValue(() => CurrentHPO); }
            set { SetValue(() => CurrentHPO, value); }
        }
        public int LeftObjectives
        {
            get { return GetValue(() => LeftObjectives); }
            set { SetValue(() => LeftObjectives, value); }
        }

        public HealthPlanQuestionnaireData HealthplanQuestionnaire
        {
            get { return GetValue(() => HealthplanQuestionnaire); }
            set { SetValue(() => HealthplanQuestionnaire, value); }
        }
        public string ObjectiveID { get; set; }
        public static int NoOfObjectivesLeft { get; set; }

        public void GetHealthPlanQuestion(string ObjectiveId)
        {
            IsHealthPlanPosted = false;
            ObjectiveID = ObjectiveId;

            AsyncCall.Invoke(() =>
            {
                //Get Question Answer From the bellow API
                var result = HealthPlanServices.GetHealthPlan(UserDetails._id, UserDetails.AuthToken.access_token);
                CurrentHPO = result.Where(x => x._id.Equals(ObjectiveId)).FirstOrDefault();
                var ObjectiveData = HealthPlanServices.GetHealthPlanObjective(UserDetails._id, ObjectiveId, UserDetails.AuthToken.access_token).data;
                //Get Question From the below API
                var data = HealthPlanServices.GetHealthPlanQuestionaries(UserDetails._id, ObjectiveId, UserDetails.AuthToken.access_token).data;
                data.strategies = ObjectiveData.strategy ?? data.strategies;
                HealthplanQuestionnaire = data;
                RaiseLoadedEvent();
            });
        }
        public bool IsHealthPlanPosted
        {
            get { return GetValue(() => IsHealthPlanPosted); }
            set { SetValue(() => IsHealthPlanPosted, value); }
        }
        public async Task<bool> SubmitStrategy()
        {
            await AsyncCall.Invoke(() =>
            {
                ErrorMessage = string.Empty;
                if (!HealthplanQuestionnaire.strategies.Any(x => x.strategy_status == 1))
                {
                    ErrorMessage = "Please select atleast one strategy.";
                    return false;
                }
                HealthStrategyRequest.strategy = HealthplanQuestionnaire.strategies;
                HealthStrategyRequest.objective_id = ObjectiveID;
                HealthStrategyRequest.user_id = UserDetails._id;
                HealthPlanServices.PostHealthPlanQuestionaries(HealthStrategyRequest, UserDetails.AuthToken.access_token);
                SetLeftObjectives();
                IsHealthPlanPosted = true;
                return IsHealthPlanPosted;

            });
            return IsHealthPlanPosted;
        }


        private void SetLeftObjectives()
        {
            LeftObjectives =ViewModelLocator.Get<HealthPlanViewModel>().GetHealthPlanObj();
        }
        private void SetHeader()
        {
            KeyString = string.Empty;
            HeaderColor = ViewModelBase.AppHeaderColor;
            HeaderVisibility = true;
            HeaderState = false;
            HeaderTitle = AppMessages.strategies;
            KeyString = "None";
        }

        private RelayCommand m_DeleteStrategyCommand;

        public RelayCommand DeleteStrategyCommand
        {
            get
            {
                return m_DeleteStrategyCommand ?? (m_DeleteStrategyCommand = new RelayCommand(
                    ve => DeleteCustomStrategy(ve)));
            }
        }
        private void DeleteCustomStrategy(object ve)
        {
            if (ve != null)
            {
                var obj = HealthplanQuestionnaire.strategies.First(x => x.LocalGuid == (Guid)ve);
                HealthplanQuestionnaire.strategies.Remove(obj);
            }
        }
        private RelayCommand<object[]> m_AddStrategyCommand;
        public RelayCommand<object[]> AddStrategyCommand
        {
            get
            {
                return m_AddStrategyCommand ?? (m_AddStrategyCommand = new RelayCommand<object[]>(
                    ve => AddNewStrategy(ve)));
            }
        }
        private void AddNewStrategy(object[] ve)
        {

            ErrorMessage = string.Empty;
            if (string.IsNullOrEmpty(ve[0] as string))
            {
                ErrorMessage = "Please add custom strategy";
                return;
            }
            string id = ve[1] as string;
            string localID = ve[2] as string;
            if (string.IsNullOrEmpty(id))
            {
                if (string.IsNullOrEmpty(localID))
                {
                    HealthplanQuestionnaire.strategies.Insert(0, new Strategy()
                    {
                        LocalGuid = Guid.NewGuid(),
                        strategy_id = null,
                        strategy_status = 1,
                        strategy_text = ve[0] as string,
                        _id = ObjectiveID
                    });
                }
                else
                {
                    Guid localGuid = new Guid(localID);
                    Strategy obj = HealthplanQuestionnaire.strategies.First(x => x.LocalGuid == localGuid);
                    HealthplanQuestionnaire.strategies.Remove(obj);

                    HealthplanQuestionnaire.strategies.Insert(0, new Strategy()
                    {
                        LocalGuid = Guid.NewGuid(),
                        strategy_id = null,
                        strategy_status = 1,
                        strategy_text = ve[0] as string,
                        _id = ObjectiveID
                    });
                }
            }
            else
            {
                HealthplanQuestionnaire.strategies.Insert(0, new Strategy()
                {
                    LocalGuid = Guid.NewGuid(),
                    strategy_id = null,
                    strategy_status = 1,
                    strategy_text = ve[0] as string,
                    _id = ObjectiveID
                });
            }



            RTH.Helpers.Messaging.AppMessages.Send(ViewToken, new Message() { Type = MessageType.StrategyAdded });
        }
        public void UpdateStrategyStatus(string tag, int v)
        {
            var item = HealthplanQuestionnaire.strategies.FirstOrDefault(i => i.strategy_id == tag);
            if (item != null)
            {
                item.strategy_status = v;
            }
        }
    }
}
