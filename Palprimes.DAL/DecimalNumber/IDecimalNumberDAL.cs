using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL.DecimalNumber
{
    public interface IDecimalNumberDAL
    {
        Task<Number> GetNumberByValueDAL(UnitOfWork unitOfWork, string value);

        Task SavePalprimesDAL(UnitOfWork unitOfWork, List<Number> numbers);
    }
}
