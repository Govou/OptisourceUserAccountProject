using Newtonsoft.Json;
using OptisourceProject.FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OptisourceProject.FrontEnd.Services
{
    public class LoginService
    {

        public static ServiceResponse Post(LoginModel model)
        {

     

            var serviceresponse = new ServiceResponse();
           
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["OptisourceUserAccountApi"].ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var custJson = JsonConvert.SerializeObject(model);

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "Login");

                request.Content = new StringContent(custJson, Encoding.UTF8, "application/json");//CONTENT-TYPE header

                try
                {

                    HttpResponseMessage httpresponse = client.SendAsync(request).Result;

                    if (httpresponse.IsSuccessStatusCode)
                    {
                        serviceresponse = JsonConvert.DeserializeObject<ServiceResponse>(httpresponse.Content.ReadAsStringAsync().Result);
                    }
                }

                catch (Exception ex)
                {
                    serviceresponse.StatusCode = "22";
                    serviceresponse.StatusResponse = ex.Message;
                }

            }
            return serviceresponse;
        }
    }
}