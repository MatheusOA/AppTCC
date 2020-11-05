using AppTCC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppTCC.Repositories
{
    public class LoginRepository
    {
        public static HttpClient client = new HttpClient();
        public static string AuthenticationToken { get; set; }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateModel authenticate)
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://eyetractor.azurewebsites.net/api/Users/authenticate"),
                    Method = HttpMethod.Post
                };

                message.Content = new StringContent(JsonConvert.SerializeObject(authenticate), Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                AuthenticateResponse authResponse = JsonConvert.DeserializeObject<AuthenticateResponse>(responseBody);

                if (!string.IsNullOrWhiteSpace(authResponse.Token))
                {
                    AuthenticationToken = authResponse.Token;
                }

                return authResponse;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
