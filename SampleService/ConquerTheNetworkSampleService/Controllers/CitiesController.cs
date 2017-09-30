using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConquerTheNetworkSampleService.Data;

namespace ConquerTheNetworkSampleService.Controllers
{
    public class CitiesController : ApiController
    {
        // GET: api/cities
        public IEnumerable<City> Get()
        {
            var cities = MockDatabase.Cities;
            foreach (var city in cities)
            {
                city.LastUpdated = DateTime.Now;
            }
            return cities;
        }

        // GET api/cities/5
        public City Get(string id)
        {
            if (MockDatabase.Cities.Any(c => c.Id == id))
            {
                var city = MockDatabase.Cities.FirstOrDefault(c => c.Id == id);
                city.LastUpdated = DateTime.Now;
                return city;
            }

            var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
            {
                Content = new StringContent($"No city with ID = {id}"),
                ReasonPhrase = "City ID Not Found"
            };
            throw new HttpResponseException(resp);
        }
    }
}
