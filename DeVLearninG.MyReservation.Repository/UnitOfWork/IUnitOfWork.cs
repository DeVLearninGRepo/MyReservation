using DeVLearninG.MyReservation.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeVLearninG.MyReservation.Repository.UnitOfWork
{
    public interface IUnitOfWork<TDbContext> where TDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        IGenericRepository<Event, Guid> EventRepository { get; }
        int Save();
    }
}
