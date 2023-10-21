﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RTH.Business.Objects;
using RTH.Helpers;
using RTH.Windows.ViewModels.Common;
using System.Windows.Input;
using System.Windows;

namespace RTH.Windows.ViewModels
{
    public class DeactivateViewModel : Common.ViewModelBase
    {

        #region Class Properties

        public String deactivationquestion
        {
            get { return GetValue(() => deactivationquestion); }
            set { SetValue(() => deactivationquestion, value); }
        }

        public List<DeactivateAnswer> deactivationanswer
        {
            get { return GetValue(() => this.deactivationanswer); }
            set { SetValue(() => deactivationanswer, value); }
        }


        public String CustomMessage
        {
            get { return GetValue(() => CustomMessage); }
            set { SetValue(() => CustomMessage, value); }
        }

        public DeactivateAccount objDeactivationObject;

        public static DeactivateAnswer objSelectedAnswer = new DeactivateAnswer();

        #endregion
        public override void Refresh()
        {
            this.ErrorMessage = "";
            objSelectedAnswer._id = null;
        }
        private DeactivateViewModel()
        {
            Init();
        }
        private void Init()
        {
            AsyncCall.Invoke(() =>
            {
                HeaderLabel = AppMessages.de_activate_account;
                GetDeactivationQuestionAnswers();
                objSelectedAnswer._id = null;
            });
            FooterVisibility = false;
        }
        public void GetDeactivationQuestionAnswers()
        {

            objDeactivationObject = RTH.Business.Services.UserService.GetDeactivationQuestionAnswers(ViewModelBase.UserDetails.language);

            deactivationquestion = objDeactivationObject.data.question;

            //DeactivateAnswer objCustomAnswer = new DeactivateAnswer();
            //objCustomAnswer._id = "0";
            //objCustomAnswer.deactivation_text = ConfigurationManagers.CUSTOM_DEACTIVATION_TEXT;
            //objCustomAnswer.blnIsCustomValue = true; 
            //objDeactivationObject.data.answers.Add(objCustomAnswer);

            deactivationanswer = objDeactivationObject.data.answers;

            this.CustomMessage = Configurations.CUSTOM_DEACTIVATION_TEXT;

        }
        public async Task<bool> DeactivateAccountAsync(string textBoxText)
        {

            User objUser = (User)ViewModelBase.UserDetails;

            if (objSelectedAnswer._id == null)
            {
                this.ErrorMessage = Configurations.SELECT_DEACTIVATION_REASON; return false;
            }
            else if (objSelectedAnswer._id == "" && string.IsNullOrWhiteSpace(textBoxText))
            {
                this.ErrorMessage = Configurations.SELECT_DEACTIVATION_REASON; return false;
            }
            else
            {
                if (objSelectedAnswer._id == "") // if (DeactivateViewModel.objSelectedAnswer.deactivation_text == ConfigurationManagers.CUSTOM_DEACTIVATION_TEXT)
                    objSelectedAnswer.deactivation_text = textBoxText;
                // DeactivateViewModel.DeactivateAction(DeactivateViewModel.objSelectedAnswer);
                if (objSelectedAnswer._id == "")
                    objSelectedAnswer._id = null;
                await AsyncCall.Invoke(() =>
                {
                    RTH.Business.Services.UserService.DeactivateUserProfile(objUser, objSelectedAnswer, UserDetails.AuthToken.access_token);
                    return true;
                }).ConfigureAwait(false);
                this.ErrorMessage = "";
                return true;
            }

        }

        #region Old Code

        // public static string strDeactivationText = string.Empty;

        //private ICommand m_deactivate;

        //public ICommand Deactivate { get { return m_deactivate ?? (m_deactivate = new RelayCommand((o) => DeactivateAction(o), (o) => true)); } }

        //public static void DeactivateAction( DeactivateAnswer objAnswer)
        //{

        //    User objUser = (User)ViewModelBase.UserDetails;

        //    if (objAnswer._id == "")
        //        objAnswer._id = null;

        //    RTH.Business.Services.UserService.DeactivateUserProfile(objUser, objAnswer, ViewModelBase.UserDetails.AuthToken.access_token);

        //}

        #endregion

    }
}
