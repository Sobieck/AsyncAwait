using System;
using System.Threading.Tasks;

namespace TheRandomNumberService.FakeDataAccess
{
    public interface IRandomNumberDataAccess
    {
        Task<int> Get();
    }

    public class RandomNumberDataAccess : IRandomNumberDataAccess
    {
        private Random random;

        public RandomNumberDataAccess()
        {
            random = new Random();
        }

        public async Task<int> Get()
        {
            var delay = random.Next(20, 200);

            await Task.Delay(delay);

            return random.Next();
        }
    }
}