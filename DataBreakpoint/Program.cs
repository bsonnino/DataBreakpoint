using System;
using System.Linq;

namespace DataBreakpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("usage: GetPrimesLessThan <number>");
                return;
            }

            if (!int.TryParse(args[0], out int number))
            {
                Console.WriteLine("parameter should be a valid integer number");
                return;
            }
            var primes = GetPrimesLessThan(number);
            Console.WriteLine($"Found {primes.Length} primes less than {number}");
            Console.WriteLine($"Last prime last than 10000 is {primes.Last()}");
        }
        private static int[] GetPrimesLessThan(int maxValue)
        {
            if (maxValue <= 1)
                return new int[0];
            ;
            var primeArray = Enumerable.Range(0, maxValue).ToArray();
            var sizeOfArray = primeArray.Length;

            primeArray[0] = primeArray[1] = 0;

            for (int i = 2; i < Math.Sqrt(sizeOfArray - 1) + 1; i++)
            {
                if (primeArray[i] <= 0) continue;
                for (var j = 2 * i; j < sizeOfArray; j += i)
                    primeArray[j] = 0;
            }

            return primeArray.Where(n => n > 0).ToArray();
        }
    }
}
