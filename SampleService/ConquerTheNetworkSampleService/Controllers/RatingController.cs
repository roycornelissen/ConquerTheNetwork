using System.Threading.Tasks;
using System.Web.Http;

namespace ConquerTheNetworkSampleService.Controllers
{
    public class RatingController : ApiController
    {
        // POST: api/Rating
        public async Task<IHttpActionResult> Post([FromBody]string value)
        {
            // just a dummy method
            await Task.Delay(1000);
            return Ok();
        }
    }
}
