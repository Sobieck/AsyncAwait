using System.Threading.Tasks;
using System.Web.Http;
using TheRandomNumberService.FakeDataAccess;

namespace TheRandomNumberService.Controllers
{
    [Route("api/random")]
    public class RandomValueController : ApiController
    {
        private IRandomNumberDataAccess randomNumberDataAccess;

        public RandomValueController(IRandomNumberDataAccess randomNumberDataAccesss)
        {
            randomNumberDataAccess = randomNumberDataAccesss;
        }

        public async Task<IHttpActionResult> Get()
        {
            var randomNumber = await randomNumberDataAccess.GetAsync();

            return Ok(randomNumber);
        }
    }
}
