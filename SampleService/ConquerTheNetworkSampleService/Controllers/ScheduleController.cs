using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Http;
using ConquerTheNetworkSampleService.Data;
using ConquerTheNetworkSampleService.Infrastructure;

namespace ConquerTheNetworkSampleService.Controllers
{
    public class ScheduleController : ApiController
    {
        // GET: api/schedule
        public IEnumerable<Schedule> Get()
        {
            return MockDatabase.Schedules;
        }

        // GET: api/schedule/{id}
        public IHttpActionResult Get(string id)
        {
            var second = DateTime.UtcNow.Second;

            // Fail half the time in case of city 3
            if (second % 2 == 0 && id == "3")
            {
                return InternalServerError();
            }

            if (MockDatabase.Cities.Any(c => c.Id == id))
            {
                Thread.Sleep(2000); // fake a slow method
                var items = MockDatabase.Schedules.Where(s => s.CityId == id);

                var result = items.FirstOrDefault();
                var hash = CalculateMD5Hash(result);
                var etag = $"\"{hash}\"";

                var noneMatchHeader = Request.Headers.IfNoneMatch.FirstOrDefault();
                if (noneMatchHeader != null)
                {
                    if (noneMatchHeader.Tag == etag)
                    {
                        return StatusCode(HttpStatusCode.NotModified);
                    }
                }

                return new CustomOkResult<Schedule>(result, this)
                {
                    ETagValue = etag
                };
            }

            return NotFound();
        }

        public string CalculateMD5Hash(object input)
        {
            var serialized = JsonConvert.SerializeObject(input);

            var md5 = MD5.Create();

            byte[] inputBytes = Encoding.ASCII.GetBytes(serialized);

            byte[] hash = md5.ComputeHash(inputBytes);

            var sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
