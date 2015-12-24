using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AsyncConsole;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = GetOneHundredRandomNumbers().Result;

            var sumOfRandomNumbers = result.Select(x => (long)x).Sum();

            Console.WriteLine(sumOfRandomNumbers);

            Console.ReadLine();
        }

        private static async Task<ICollection<int>> GetOneHundredRandomNumbers()
        {
            var dataAccess = new RandomNumberDataAccess();

            var tasks = new List<Task<int>>();

            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(dataAccess.GetAsync());
            }

            return await Task.WhenAll(tasks);
        }
    }
}
