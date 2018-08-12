using Palprimes.DAL;
using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.BL.BinaryNumber
{
    public interface IBinaryNumberBL
    {
        Task<Number> GetNumberByValueBL(string value);

        Task SavePalprimesBL(List<Number> numbers);
    }
}
