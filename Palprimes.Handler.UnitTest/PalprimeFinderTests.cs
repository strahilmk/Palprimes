using System;
using NUnit.Framework;
using Palprimes.BL.BinaryNumber;
using Palprimes.BL.DecimalNumber;
using Palprimes.DAL;
using Palprimes.DAL.BinaryNumber;
using Palprimes.DAL.DecimalNumber;
using Palprimes.Handlers;
using Palprimes.Shared.Models.Common;

namespace Palprimes.Handler.UnitTests
{
    [TestFixture]
    public class PalprimeFinderTests
    {
        private static UnitOfWorkFactory _unitOfWorkFactory = new UnitOfWorkFactory();
        private static DecimalNumberDAL _decimalNumberDAL = new DecimalNumberDAL();
        private static BinaryNumberDAL _binaryNumberDAL = new BinaryNumberDAL();
        IDecimalNumberBL _decimalNumberBL = new DecimalNumberBL(_decimalNumberDAL, _unitOfWorkFactory);
        IBinaryNumberBL _binaryNumberBL = new BinaryNumberBL(_binaryNumberDAL, _unitOfWorkFactory);

        [Test]
        public void Binary_Palprimes()
        {

            //Arrange
            var findPalprimes = new PalprimeFinder(_binaryNumberBL,_decimalNumberBL);

            //Act
            var ressult = findPalprimes.FindPalprimes(Convert.ToInt32(NumberSystem.Binary));

            //Asert
            Assert.AreEqual(ressult.Count, 11);
        }

        [Test]
        public void Decimal_Palprimes()
        {
            //Arrange
            var findPalprimes = new PalprimeFinder(_binaryNumberBL, _decimalNumberBL);

            //Act
            var ressult = findPalprimes.FindPalprimes(Convert.ToInt32(NumberSystem.Decimal));

            //Asert
            Assert.AreEqual(ressult.Count, 20);
        }

    }
}
