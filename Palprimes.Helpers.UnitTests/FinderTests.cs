using System;
using Palprimes.Helpers;
using NUnit.Framework;

namespace Palprimes.Helpers.UnitTests
{
    [TestFixture]
    public class FinderTests
    {
        [Test]
        public void CheckIfNumber_IsPrimeNumber()
        {
            //Arange
            int number = 2;

            //Act
            var ressult = Finder.IsPrimeNumber(number);

            //Asert
            Assert.IsTrue(ressult);
        }

        [Test]
        public void CheckIfNumber_IsNotPrimeNumber()
        {
            //Arange
            int number = 6;

            //Act
            var ressult = Finder.IsPrimeNumber(number);

            //Asert
            Assert.IsFalse(ressult);
        }

        [Test]
        public void CheckIfNumber_IsPalindrom()
        {
            //Arange
            int number = 11;

            //Act
            var ressult = Finder.IsPrimeNumber(number);

            //Asert
            Assert.IsTrue(ressult);
        }

        [Test]
        public void CheckIfNumber_IsNotPalindrom()
        {
            //Arange
            int number = 12;

            //Act
            var ressult = Finder.IsPrimeNumber(number);

            //Asert
            Assert.IsFalse(ressult);
        }
    }
}
