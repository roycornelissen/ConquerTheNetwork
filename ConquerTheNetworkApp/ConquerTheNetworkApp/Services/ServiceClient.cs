using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Data;
using Refit;

namespace ConquerTheNetworkApp.Services
{
    public class ServiceClient
    {
        public static string ApiBaseAddress = "http://conquerthenetworksampleservice.azurewebsites.net";

        private IConferenceApi _client;

        public ServiceClient()
        {
            // HttpClient needs to be instantiated using the parameterless constructor
            // otherwise the native handler won't be automatically injected.
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };
            _client = RestService.For<IConferenceApi>(httpClient);
        }

        public Task<List<City>> GetCities()
        {
            return _client.GetCities();
        }

        public async Task<Schedule> GetScheduleForCity(string id)
        {
            try
            {
                return await _client.GetScheduleForCity(id);
            }
            catch (ApiException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public Task SendRating(double rating)
        {
            return _client.Rate(rating);
        }
    }
}
