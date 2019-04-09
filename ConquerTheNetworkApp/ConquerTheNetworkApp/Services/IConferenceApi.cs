using ConquerTheNetworkApp.Data;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConquerTheNetworkApp.Services
{
	[Headers("Accept: application/json")]
	public interface IConferenceApi
	{
		[Get("/api/cities")]
		Task<List<City>> GetCities();

		[Get("/api/schedule/{id}")]
		Task<Schedule> GetScheduleForCity(string id);

		[Post("/api/rating")]
		Task Rate([Body] double rating);
	}
}