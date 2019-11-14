using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ConquerTheNetworkApp.Data;
using Polly;
using Refit;

namespace ConquerTheNetworkApp.Services
{
    public class ServiceClient
    {
        public static string ApiBaseAddress = "http://conquerthenetworksampleservice.azurewebsites.net";

        private IConferenceApi _client;

        public ServiceClient()
        {
            _client = RestService.For<IConferenceApi>(ApiBaseAddress);
        }

        public async Task<List<City>> GetCities()
        {
            return await Policy
                 .Handle<ApiException>(ex => ex.StatusCode != HttpStatusCode.NotFound)
                 .CircuitBreakerAsync(exceptionsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromMinutes(1))
                 .ExecuteAsync(async () =>
                 {
                     Debug.WriteLine("Trying cities service call...");
                     return await _client.GetCities();
                 });
        }

        public async Task<Schedule> GetScheduleForCity(string id)
        {
            return await Policy
                     .Handle<ApiException>(ex => ex.StatusCode != HttpStatusCode.NotFound)
                     .WaitAndRetryAsync
                     (
                         retryCount: 3,
                         sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                     )
                     .ExecuteAsync(async () =>
                     {
                         Debug.WriteLine("Trying schedule service call...");
                         return await _client.GetScheduleForCity(id);
                     });
        }

        public async Task SendRating(double rating)
        {
            await Policy
                .Handle<ApiException>(ex => ex.StatusCode != HttpStatusCode.NotFound)
                .WaitAndRetryAsync
                (
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))
                )
                .ExecuteAsync(async () =>
                {
                    Debug.WriteLine("Trying rating service call...");
                    await _client.Rate(rating);
                });
        }
    }
}
