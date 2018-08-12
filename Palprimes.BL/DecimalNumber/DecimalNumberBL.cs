using Palprimes.DAL;
using Palprimes.DAL.DecimalNumber;
using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.BL.DecimalNumber
{
    public class DecimalNumberBL : IDecimalNumberBL
    {
        IDecimalNumberDAL _decimalNumberDAL;
        IUnitOfWorkFactory _unitOfWorkFactory;

        public DecimalNumberBL(IDecimalNumberDAL decimalNumberDAL, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _decimalNumberDAL = decimalNumberDAL;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Number> GetNumberByValueBL(string value)
        {
            Number number;
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                number = await _decimalNumberDAL.GetNumberByValueDAL(unitOfWork, value);
            }

            return number;
        }

        public async Task SavePalprimesBL(List<Number> numbers)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                await _decimalNumberDAL.SavePalprimesDAL(unitOfWork, numbers);
                await unitOfWork.Complete();
            }
        }
    }
}
