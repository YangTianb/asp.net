using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
   public class OAuthClientTest
    {
        private HttpClient _httpClient;

        public OAuthClientTest()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://openapi.cnblogs.com");
        }

       
        public void Get_Accesss_Token_By_Client_Credentials_Grant()
        {
            var parameters = new Dictionary<string, string>();
            parameters.Add("client_id", "1234");
            parameters.Add("client_secret", "5678");
            parameters.Add("grant_type", "client_credentials");

            Console.WriteLine(_httpClient.PostAsync("/token", new FormUrlEncodedContent(parameters))
                .Result.Content.ReadAsStringAsync().Result);
        }
    }
}
