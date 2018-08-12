using Palprimes.DAL;
using Palprimes.DAL.BinaryNumber;
using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.BL.BinaryNumber
{
    public class BinaryNumberBL : IBinaryNumberBL
    {
        IBinaryNumberDAL _binaryNumberDAL;
        IUnitOfWorkFactory _unitOfWorkFactory;

        public BinaryNumberBL(IBinaryNumberDAL binaryNumberDAL, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _binaryNumberDAL = binaryNumberDAL;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<Number> GetNumberByValueBL(string value)
        {
            Number number;
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                number = await _binaryNumberDAL.GetNumberByValueDAL(unitOfWork, value);
            }

            return number;
        }

        public async Task SavePalprimesBL(List<Number> numbers)
        {
            using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork())
            {
                await _binaryNumberDAL.SavePalprimesDAL(unitOfWork, numbers);
                await unitOfWork.Complete();
            }
        }
    }
}
