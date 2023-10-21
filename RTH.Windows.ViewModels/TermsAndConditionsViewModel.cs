using RTH.Business.Objects;
using RTH.Business.Objects.JSON;
using RTH.Business.Services;
using RTH.Windows.ViewModels.Common;
using System.Collections.Generic;
using System.Linq;

namespace RTH.Windows.ViewModels
{
    public class TermsAndConditionsViewModel : ViewModelBase
    {
        #region Global Properties
        public PrivatePolicy.Data TermsData
        {
            get { return GetValue(() => this.TermsData); }
            set { SetValue(() => TermsData, value); }
        }

        #endregion Global Properties
        public TermsAndConditionsViewModel()
        {
            AsyncCall.Invoke(() =>
            {
                TermsData = RTH.Business.Services.PolicyService.GetTermsAndConditions(Lang ?? "en");
            });
        }


        public List<Question> GetPreConversation()
        {
            var con = ConversationService.PreRegistrationConversation();
            preAmbleId = con._id;
            return con.questions.FirstOrDefault().questions.ToList();
            //List<Question> preConList = new List<Question>();
            //Question element = lst.FirstOrDefault(x => x.dependency.dependency_question == null);
            //preConList.Add(element);
            //Traverse(preConList, lst, element.answers.FirstOrDefault()._id);
            //return preConList;
        }



        private void Traverse(List<Question> preConList, List<Question> lst, string dependendAnswerId)
        {
            Question element = lst.FirstOrDefault(x => x.dependency.dependency_answer.Any(y => (string)y == dependendAnswerId));
            if (element != null)
            {
                preConList.Add(element);
                Traverse(preConList, lst, element.answers.FirstOrDefault()._id);
            }
        }

        public List<Question> GetPostConversation()
        {
            var con = ConversationService.PostRegistrationConversation(lang: "en", accessToken: UserDetails.AuthToken.access_token);
            preAmbleId = con._id;
            return con.questions.FirstOrDefault().questions.ToList();
            //List<Question> postConList = new List<Question>();
            //Question element = lst.FirstOrDefault(x => x.dependency.dependency_question == null);
            //postConList.Add(element);
            //Traverse(postConList, lst, element.answers.FirstOrDefault()._id);
            //return postConList;
        }
    }
}
