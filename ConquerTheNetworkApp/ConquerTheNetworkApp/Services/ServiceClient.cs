using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using ConquerTheNetworkApp.Data;

namespace ConquerTheNetworkApp.Services
{
    public class ServiceClient
    {
        public static string ApiBaseAddress = "http://conquerthenetworksampleservice.azurewebsites.net";

        public async Task<List<City>> GetCities()
        {
            IEnumerable<City> cities = new List<City>();

            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync("api/cities").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        cities = await Task.Run(() =>
                            JsonConvert.DeserializeObject<IEnumerable<City>>(json)
                            ).ConfigureAwait(false);

                    }
                }
            }

            return cities.ToList();
        }

        public async Task<Schedule> GetScheduleForCity(string id)
        {
            using (var httpClient = CreateClient())
            {
                var response = await httpClient.GetAsync($"api/schedule/{id}").ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        var schedule = await Task.Run(() =>
                            JsonConvert.DeserializeObject<Schedule>(json)
                            ).ConfigureAwait(false);

                        return schedule;
                    }
                }
            }
            return null;
        }

        public async Task SendRating(double rating)
        {
            using (var httpClient = CreateClient())
            {
                var message = new HttpRequestMessage(HttpMethod.Post, $"api/rating");
                var response = await httpClient.SendAsync(message).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Whoops!");
                }
            }
        }

        private HttpClient CreateClient()
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}
