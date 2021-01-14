using Newtonsoft.Json.Linq;
using RestSharp;
using System.Linq;

namespace AutomationExam.API_Logic
{
    public class API_WorkFlow
    {
        public API_WorkFlow()
        {

        }

        public bool VerifyEmailExistInResponse(string email)
        {
            var validation = false;

            RestClient restClient = new RestClient("https://reqres.in/api/users?page=2");
            RestRequest restRequest = new RestRequest(Method.GET);
            
            IRestResponse restResponse = restClient.Execute(restRequest);
            if(restResponse.IsSuccessful)
            {
                var response = restResponse.Content;
                var JSonResult = new JObject();

                JSonResult = JObject.Parse(response);
                var jresult = JSonResult["data"];

                var token = jresult.Children<JObject>().FirstOrDefault(x => x.Value<string>("email") == email);
                validation = token != null;
            }
            return validation;
        }
        

    }
}
