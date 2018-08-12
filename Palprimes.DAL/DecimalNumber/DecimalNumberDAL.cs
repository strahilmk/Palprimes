using log4net;
using Palprimes.Shared.Models.Numbers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL.DecimalNumber
{
    public class DecimalNumberDAL : IDecimalNumberDAL
    {
        private static readonly ILog _log =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Task<Number> GetNumberByValueDAL(UnitOfWork unitOfWork, string value)
        {
            var number = unitOfWork.PalprimesContext.DecimalNumbers
                .Where(x => x.Value == value)
                .Select(x => new Number
                {
                    UniqueId = x.UniqueId,
                    Value = x.Value,
                    IsPalindrom = x.IsPalindrom,
                    IsPrime = x.IsPrime
                }).FirstOrDefaultAsync();

            return number;
        }

        public async Task SavePalprimesDAL(UnitOfWork unitOfWork, List<Number> numbers)
        {
            Palprimes.DAL.EF.DecimalNumber trackedEntity = null;
            // look up existing decimal numbers
            foreach (var number in numbers)
            {
                trackedEntity = unitOfWork.PalprimesContext.DecimalNumbers.FirstOrDefault(x => x.Value == number.Value);
                if (trackedEntity == null)
                {
                    trackedEntity = unitOfWork.PalprimesContext.DecimalNumbers.Create();
                    trackedEntity.UniqueId = Guid.NewGuid();
                    trackedEntity.Value = number.Value;
                    trackedEntity.IsPalindrom = number.IsPalindrom;
                    trackedEntity.IsPrime = number.IsPrime;
                    trackedEntity.CreateDate = DateTime.Now;
                    unitOfWork.PalprimesContext.DecimalNumbers.Add(trackedEntity);

                }
                // for modify change name?
                trackedEntity.LastUpdate = DateTime.Now;
            }
            _log.Info("Saving Palprime Decimal Numbers in DB");

            unitOfWork.PalprimesContext.SaveChanges();
        }
    }
}
