using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

using AsyncConsole;

namespace AsyncClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();

            var result = GetOneHundredRandomNumbers().Result;

            DisplayResults(stopWatch, result.ToList());
        }

        private static async Task<ICollection<int>> GetOneHundredRandomNumbers()
        {
            var dataAccess = new RandomNumberDataAccess();

            var tasks = new List<Task<int>>();

            for (int i = 0; i < 4000; i++)
            {
                tasks.Add(dataAccess.GetAsync());
            }

            return await Task.WhenAll(tasks);
        }

        private static void DisplayResults(Stopwatch sw, List<int> numbers)
        {
            sw.Stop();

            Console.WriteLine("It Took {0} miliseconds to get {1} numbers", sw.ElapsedMilliseconds, numbers.Count);
            Console.WriteLine(" ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" ");
            Console.WriteLine("Numbers: {0}", string.Join(", ", numbers));
            Console.WriteLine(" ");
            var sum = numbers.Sum(x => (long)x);

            Console.WriteLine("Result = {0}", sum.ToString("N1", CultureInfo.InvariantCulture));
            Console.Read();
        }
    }
}
