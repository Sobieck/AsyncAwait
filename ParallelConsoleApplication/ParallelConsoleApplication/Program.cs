using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ParallelConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please insert the number of ints you would like to sum");
            var times = Console.ReadLine();

            var number = 5;

            if (int.TryParse(times, out number))
            {
                Console.WriteLine("Thank you.");
            }
            else
            {
                Console.WriteLine("Sorry, that's not a number");
            }

            Console.WriteLine("Let's sum {0} numbers.", number);
            Console.WriteLine(" ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine(" ");

            GetSum(number);
        }

        private static void GetSum(int numberOfTimes)
        {
            var numbers = new List<int>();
            var tries = new List<string>();
            for(var i = 0 ; i < numberOfTimes ; i++)
            {
                tries.Add(i.ToString());
            }

            var sw = Stopwatch.StartNew();

            Parallel.ForEach(tries, x =>
            {
                numbers.Add(GetRandomNumberFromApi());
            });

            DisplayResults(sw, numbers);
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

        private static int GetRandomNumberFromApi()
        {
            var number = 0;

            var host = "http://api.leo-sanchez.com/api/random";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(host);

                number = response.Result.Content.ReadAsAsync<int>().Result;

            }

            return number;
        }
    }
}
