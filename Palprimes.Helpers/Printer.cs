using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;

namespace Palprimes.Helpers
{
    public static class Printer
    {
        /// <summary>
        /// Printing all the Palprimes in console
        /// </summary>
        /// <param name="palindroms"></param>
        public static void PrintPalprimes(List<Number> palprimes)
        {
            Console.WriteLine($"Found total of {palprimes?.Count} Palprimes");

            for (int i = 0; i < palprimes?.Count; i++)
            {
                Console.Write(palprimes[i].Value + " ");
            }
        }
    }
}
