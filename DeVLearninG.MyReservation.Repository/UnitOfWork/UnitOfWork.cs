using DeVLearninG.MyReservation.Domain;
using DeVLearninG.MyReservation.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
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
            return _context.SaveChanges();
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
