using DeVLearninG.MyReservation.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DeVLearninG.MyReservation.ServiceLayer
{
    public class GenericService<TEntity, TKey> : IGenericService<TEntity, TKey> where TEntity : class
    {
        private readonly MyReservationContext _context;

        protected MyReservationContext Context => _context;

        public GenericService(DbContextOptions options)
        {
            _context = new MyReservationContext(options);
        }

        public GenericService(MyReservationContext context)
        {
            _context = context;
        }

        public void Delete(TKey id)
        {
            if (id == null) throw new ArgumentNullException("id");

            var entityToDelete = GetById(id);

            if (entityToDelete == null) throw new Exception("Entity not found");

            _context.Set<TEntity>().Remove(entityToDelete);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            if (Context.Entry(entity).State == EntityState.Detached)
            {
                _context.Set<TEntity>().Attach(entity);
            }

            _context.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (!string.IsNullOrEmpty(includeProperties) && !string.IsNullOrWhiteSpace(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsEnumerable();
            }
            else
            {
                return query.AsEnumerable();
            }
        }

        public TEntity GetById(TKey id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);

            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
