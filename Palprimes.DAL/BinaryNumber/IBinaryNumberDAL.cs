using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL.BinaryNumber
{
    public interface IBinaryNumberDAL
    {
        Task<Number> GetNumberByValueDAL(UnitOfWork unitOfWork, string value);

        Task SavePalprimesDAL(UnitOfWork unitOfWork, List<Number> numbers);
    }
}
