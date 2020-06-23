using DeVLearninG.MyReservation.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Text;

namespace DeVLearninG.MyReservation.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork<MyReservationContext>, IDisposable
    {
        private readonly MyReservationContext _context;
        private bool disposed = false;
        private IGenericRepository<Event, Guid> _eventRepository;

        public IGenericRepository<Event, Guid> EventRepository
        {
            get
            {
                return _eventRepository ?? (_eventRepository = new GenericRepository<Event, Guid>(_context));
            }
        }

        public UnitOfWork(MyReservationContext context)
        {
            _context = context;
        }

        public int Save()
        {
            try
            {
                return _context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                string errorMessage = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(errorMessage, dbEx);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
