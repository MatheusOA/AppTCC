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
    public class MessageRepository
    {
        public static HttpClient client = new HttpClient();

        public async Task<List<UserMessage>> GetMessages()
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://eyetractor.azurewebsites.net/api/Messages"),
                    Method = HttpMethod.Get
                };

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", LoginRepository.AuthenticationToken);

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<UserMessage>>(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public async Task SendMessage(SendMessage sendMessage)
        {
            try
            {
                HttpRequestMessage message = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://eyetractor.azurewebsites.net/api/Messages"),
                    Method = HttpMethod.Post
                };

                message.Content = new StringContent(JsonConvert.SerializeObject(sendMessage), Encoding.UTF8, "application/json");

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", LoginRepository.AuthenticationToken);

                HttpResponseMessage response = await client.SendAsync(message);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                return;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return;
            }
        }
    }
}
