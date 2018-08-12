using Palprimes.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the unit of work with the default context.
        /// </summary>
        /// <returns></returns>
        public UnitOfWork CreateUnitOfWork(string contextToUse = "Palprimes")
        {

            var unitOfWork = new UnitOfWork();
            PalprimesDBEntities palprimesContext;

            try
            {
                switch (contextToUse)
                {
                    case "Palprimes":
                        palprimesContext = new PalprimesDBEntities();
                        unitOfWork.PalprimesContext = palprimesContext;
                        unitOfWork.DbContextTransaction = palprimesContext.Database.BeginTransaction();
                        break;
                    default:
                        palprimesContext = new PalprimesDBEntities();
                        unitOfWork.PalprimesContext = palprimesContext;
                        unitOfWork.DbContextTransaction = palprimesContext.Database.BeginTransaction();
                        break;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return unitOfWork;
        }
    }
}
