using log4net;
using System;

namespace Palprimes.Helpers
{
    public static class Finder
    {
        private static readonly ILog _log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Checking if the number is prime
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPrimeNumber(int number)
        {
            bool isPrime = true;

            try
            {

                for (int i = 2; i <= 100; i++)
                {
                    if (number != i && number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                return isPrime;
            }
            catch (Exception ex)
            {
                _log.Error($"Error finding PrimeNumber with Ex msg: ", ex);
                isPrime = false;
                return isPrime;
            }

        }

        /// <summary>
        /// Checking if the number is palindrom
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static bool IsPalindrom(string number)
        {
            bool isPalindrom = false;
            try
            {
                char[] charArray = number.ToCharArray();

                //Taking the number in reverse in order to check if it is palindrom
                Array.Reverse(charArray);
                return isPalindrom = (new string(charArray) == number);
            }
            catch (Exception ex)
            {
                _log.Error($"Error in IsPalindrom with Ex msg: ", ex);
                return isPalindrom;
            }
        }
    }
}
