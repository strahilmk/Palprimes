using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL
{
    public interface IUnitOfWorkFactory
    {
        UnitOfWork CreateUnitOfWork(string contextToUse = "Palprimes");
    }
}
