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
    public class AnalysisRepository
    {
        public static HttpClient client = new HttpClient();

        public async Task<List<DateEvent>> GetDateEvents()
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://eyetractor.azurewebsites.net/api/CameraData"),
                    Method = HttpMethod.Get
                };

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", LoginRepository.AuthenticationToken);

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<DateEvent>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
