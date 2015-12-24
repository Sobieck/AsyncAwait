using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace TheRandomNumberService.Controllers
{
    [Route("api/random")]
    public class RandomValueController : ApiController
    {
        public async Task<int> Get()
        {
            throw new NotImplementedException();
        }
    }
}
