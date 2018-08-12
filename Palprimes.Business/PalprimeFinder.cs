using log4net;
using Palprimes.BL.BinaryNumber;
using Palprimes.BL.DecimalNumber;
using Palprimes.Helpers;
using Palprimes.Shared.Models.Common;
using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;

namespace Palprimes.Handlers
{
    public class PalprimeFinder : IPalprimeFinder
    {
        private static readonly ILog _log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        IBinaryNumberBL _binaryNumberBL;
        IDecimalNumberBL _decimalNumberBL;

        public PalprimeFinder(IBinaryNumberBL binaryNumberBL, IDecimalNumberBL decimalNumberBL)
        {
            _binaryNumberBL = binaryNumberBL;
            _decimalNumberBL = decimalNumberBL;
        }

        /// <summary>
        /// Finding all Palprimes from 1 to 1000
        /// </summary>
        /// <param name="numberSystem"></param>
        /// <returns></returns>
        public List<Number> FindPalprimes(int numberSystem)
        {
            List<Number> palprimes = new List<Number>();
            Number number;

            try
            {
                for (int i = 2; i <= 1000; i++)
                {
                    number = new Number();

                    number.IsPrime = Finder.IsPrimeNumber(i);

                    if (number.IsPrime)
                    {
                        if (numberSystem == Convert.ToInt32(NumberSystem.Binary))
                        {
                            number.Value = Convert.ToString(i, 2);
                        }
                        else if (numberSystem == Convert.ToInt32(NumberSystem.Decimal))
                        {
                            number.Value = i.ToString();
                        }

                        // TODO hex system convert

                        number.IsPalindrom = Finder.IsPalindrom(number.Value);
                        if (number.IsPalindrom)
                        {
                            _log.Info($"The number, {number.Value} is palprime");
                            palprimes.Add(number);
                        }
                    }
                }
                if(numberSystem == Convert.ToInt32(NumberSystem.Binary))
                {
                    _binaryNumberBL.SavePalprimesBL(palprimes);

                }else if (numberSystem == Convert.ToInt32(NumberSystem.Decimal))
                {
                    _decimalNumberBL.SavePalprimesBL(palprimes);
                }
                    Printer.PrintPalprimes(palprimes);
            }
            catch (Exception ex)
            {
                _log.Error($"Error in FindPalprimes with Ex msg: ", ex);
            }

            return palprimes;
        }
    }
}
