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
    public class SellingPointRepository
    {
        public static HttpClient client = new HttpClient();

        public async Task<List<SellingPoints>> GetSellingPoints()
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://eyetractor.azurewebsites.net/api/SellingPoints"),
                    Method = HttpMethod.Get
                };

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", LoginRepository.AuthenticationToken);

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<SellingPoints>>(responseBody);
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
