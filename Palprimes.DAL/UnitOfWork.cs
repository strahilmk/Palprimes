using log4net;
using Palprimes.DAL.EF;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palprimes.DAL
{
    /// <summary>
    /// Acts as a database transaction manager.
    /// </summary>
    public class UnitOfWork : IDisposable
    {
        readonly ILog _logger 
            = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        internal PalprimesDBEntities PalprimesContext;

        internal System.Data.Entity.DbContextTransaction DbContextTransaction;

        private bool _disposed = false;
        private bool _completed = false;

        public UnitOfWork()
        {

        }

       
        public virtual async Task Complete()
        {
            try
            {
                //_logger.Info("Trying to commit");
                if (PalprimesContext != null) await PalprimesContext.SaveChangesAsync();

                DbContextTransaction.Commit();
                //_logger.Info("Commited db change");

            }
            catch (Exception ex)
            {
                if (ex is DbEntityValidationException)
                {
                    DbEntityValidationException dbEx = (DbEntityValidationException)ex;
                    DbContextTransaction.Rollback();

                    _logger.Error("Error saving to database.");
                    foreach (
                        var validationError in
                            dbEx.EntityValidationErrors.SelectMany(validationErrors => validationErrors.ValidationErrors)
                        )
                    {
                        _logger.Error(string.Format("Property: {0} Error: {1}", validationError.PropertyName,
                            validationError.ErrorMessage));
                    }
                    throw;
                }
                else
                {
                    _logger.Error("Error saving to database. " + ex.ToString());
                    throw;
                }
            }
            _completed = true;
        }

        /// <summary>
        /// Cancels the unit of work transaction and forces all changed data to be rolled back.
        /// </summary>
        public virtual void Cancel()
        {
            _logger.Info("Rolling back transaction");
            DbContextTransaction.Rollback();
            _completed = true;
        }

       
        protected virtual void Dispose(bool disposing)
        {
            //_logger.Info("Disposing ...");
            if (!_disposed)
            {
                if (disposing)
                {
                    if (DbContextTransaction != null)
                    {
                        DbContextTransaction.Dispose();
                    }
                    if (PalprimesContext != null) PalprimesContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            _logger.Info("Dispose");
            Dispose(true);
            GC.SuppressFinalize(this);
        }


    }
}
