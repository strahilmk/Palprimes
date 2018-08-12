using log4net;
using System;

namespace Palprimes.Handlers
{
    public class Validator : IValidator
    {
        IPalprimeFinder _palprimeFinder;
        private static readonly ILog _log = 
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Validator(IPalprimeFinder palprimeFinder)
        {
            _palprimeFinder = palprimeFinder;
        }

        /// <summary>
        /// Checking if the right input is inserted from the console 
        /// </summary>
        /// <returns></returns>
        public bool IsRightInputInserted()
        {
            string input = Console.ReadLine();

            bool isRightInput = false;
            int typeOfPelprimes = 0;

            while (!isRightInput)
            {
                Int32.TryParse(input, out typeOfPelprimes);

                if (typeOfPelprimes > 0 && typeOfPelprimes < 3)
                {
                    _log.Info("You Made the Correct Choice");
                    isRightInput = true;
                }
                else if (typeOfPelprimes == 3)
                {
                    Console.WriteLine("Hexadecimal system not implemented, Insert 1 or 2");
                    input = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Insert from 1 to 3!");
                    input = Console.ReadLine();
                }
            }

            _palprimeFinder.FindPalprimes(typeOfPelprimes);
            return isRightInput;
        }

    }
}
