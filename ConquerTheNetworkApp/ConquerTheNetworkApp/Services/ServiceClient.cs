using System.Collections.Generic;
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
			_client = RestService.For<IConferenceApi>(ApiBaseAddress);
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
