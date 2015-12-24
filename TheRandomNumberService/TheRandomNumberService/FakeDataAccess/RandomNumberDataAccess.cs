using System;
using System.Threading.Tasks;

namespace TheRandomNumberService.FakeDataAccess
{
    public interface IRandomNumberDataAccess
    {
        Task<int> GetAsync();
    }

    public class RandomNumberDataAccess : IRandomNumberDataAccess
    {
        private Random random;

        public RandomNumberDataAccess()
        {
            random = new Random();
        }

        public async Task<int> GetAsync()
        {
            var delay = random.Next(200, 1000);

            await Task.Delay(delay);

            return random.Next();
        }
    }
}