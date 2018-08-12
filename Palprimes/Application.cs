using Palprimes.Handlers;
using System;

namespace Palprimes
{
    public class Application : IApplication
    {
        IValidator _validator;

        public Application(IValidator validator)
        {
            _validator = validator;
        }

        /// <summary>
        /// Run the application
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Choose one of the following numbering systems and see their Palprimes");
            Console.WriteLine("1. Decimal numbering system");
            Console.WriteLine("2. Binary numbering system");
            Console.WriteLine("3. Hexadecimal numbering system");
            Console.Write("Insert from 1 to 3: ");

            _validator.IsRightInputInserted();
        }
    }
}
