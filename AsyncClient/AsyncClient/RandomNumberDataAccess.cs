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
                var result = await client.GetAsync("http://api.leo-sanchez.com/api/random");

                return await result.Content.ReadAsAsync<int>();
            }
        }
    }
}
