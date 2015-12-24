using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class RandomNumberDataAccess
    {
        internal async Task<int> GetAsync()
        {
            using (var client = new HttpClient())
            {
                var result = await client.GetAsync("http://localhost:59329/api/random");

                return await result.Content.ReadAsAsync<int>();
            }
        }
    }
}
