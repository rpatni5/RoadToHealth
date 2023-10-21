using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RTH.Business.Services
{
    public static class InsightService
    {
        public static Insight GetInsights(Insight objInsight, string accessToken)
        {

            string strQuery = "apis/insight_comparison_references/" + objInsight.questionaireId + "/" + objInsight.ethnicity + "/" + objInsight.age + "/" + objInsight.male.ToString().ToLower() + "/" + objInsight.language + "/" + objInsight.userId;

            return Http.ExecuteGET<Insight>(strQuery,null, accessToken);

        }

        /* 
        public static Insight GetInsights(Insight objInsight, string accessToken)
        {

            try
            {

                using (var client = new HttpClient())
                {
                    NameValueCollection nvc = new NameValueCollection();
                    // nvc.Add("age", objInsight.age.ToString());
                    // nvc.Add("male", objInsight.male.ToString());
                    // var queryString = nvc.MakeQuery();
                    client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    if (!string.IsNullOrEmpty(accessToken))
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);

                    string strQuery = _APIURL + "apis/insight_comparison_references/" + objInsight.hraid + "/" + objInsight.val1 + "/" + objInsight.age + "/" + objInsight.male.ToString().ToLower() + "/" + objInsight.enthnicity + "/" + objInsight.val2;

                    // string strQuery = "http://172.24.1.114:3000/apis/insight_comparison_references/548b2333ae8f826f1898a78f/0/20/true/en/566fae99553bb3b80c282106";

                    HttpResponseMessage response = client.GetAsync(strQuery).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        objInsight = response.Content.ReadAsAsync<Insight>().Result;
                    }
                    else
                    {
                        // oUser.message = string.Format("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                    }
                    return objInsight;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        */


    }
}
