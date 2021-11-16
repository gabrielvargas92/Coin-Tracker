using Hahn.ApplicatonProcess.July2021.Domain.Contracts;
using Hahn.ApplicatonProcess.July2021.Domain.Contracts.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Data
{
    public abstract class BaseRepository<TObject, TKey, TContext> : IBaseRepository<TObject, TKey>
           where TObject : class, IEntity<TKey>
           where TKey : IEquatable<TKey>
           where TContext : DbContext
    {
        protected TContext Context;

        protected BaseRepository(TContext context)
        {
            this.Context = context;
        }

        protected DbSet<TObject> DbSet
        {
            get
            {
                return Context.Set<TObject>();
            }
        }

        # region Methods

        public virtual IQueryable<TObject> Query(Expression<Func<TObject, bool>> filterExpression)
        {
            var query = DbSet.Where(filterExpression).AsNoTracking().AsQueryable();
            return query;
        }

        public virtual IList<TObject> GetAll(params Expression<Func<TObject, object>>[] properties)
        {
            var query = DbSet.AsNoTracking().AsQueryable();
            IncludeProperties(ref query, properties);
            return query.ToList();
        }

        public virtual IList<TObject> GetAll(Expression<Func<TObject, bool>> filterExpression, params Expression<Func<TObject, object>>[] properties)
        {
            var query = DbSet.Where(filterExpression).AsNoTracking().AsQueryable();
            IncludeProperties(ref query, properties);
            return query.ToList();
        }

        public virtual bool Contains(Expression<Func<TObject, bool>> filterExpression)
        {
            return DbSet.Count(filterExpression) > 0;
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> filterExpression, bool dbTracking = true)
        {
            var query = DbSet.Where(filterExpression);
            query = dbTracking ? query.AsNoTracking() : query.AsTracking();
            return query.SingleOrDefault(filterExpression);
        }

        public virtual TObject Find(Expression<Func<TObject, bool>> filterExpression, bool dbTracking = true, params Expression<Func<TObject, object>>[] properties)
        {
            var query = DbSet.Where(filterExpression);
            query = dbTracking ? query.AsNoTracking() : query.AsTracking();
            query = query.AsQueryable();
            IncludeProperties(ref query, properties);
            return query.SingleOrDefault();
        }

        public virtual void Add(IQueryable<TObject> TObjects)
        {
            foreach (var TObject in TObjects)
                this.Add(TObject);
        }

        public virtual void Add(TObject TObject)
        {
            // TObject.Validate();
            Context.Add(TObject);
        }

        public virtual void AddRange(IEnumerable<TObject> entities)
        {
            Context.AddRange(entities);
        }

        public virtual TObject AddReturn(TObject TObject)
        {
            // TObject.Validate();
            return Context.Add(TObject).Entity;
        }

        public virtual void Delete(TObject TObject)
        {
            var entry = Context.Entry(TObject);
            entry.State = EntityState.Deleted;
        }

        public virtual void Delete(Expression<Func<TObject, bool>> filterExpression)
        {
            var objects = GetAll(filterExpression);

            foreach (var obj in objects)
            {
                Delete(obj);
            }
        }

        public virtual void Delete(TKey id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
                throw new DbUpdateException();

            Delete(entity);
        }

        public virtual void Update(TObject TObject)
        {
            var old = DbSet.Find(TObject.Id);
            if (old == null)
                throw new DbUpdateException();

            var entry = Context.Entry(old);

            entry.CurrentValues.SetValues(TObject);
            entry.State = EntityState.Modified;

            if (entry.Entity is IAuditable)
                (entry.Entity as IAuditable).UpdatedAt = DateTime.UtcNow;
        }

        public virtual void UpdateRange(IQueryable<TObject> TObjects)
        {
            UpdateRange(TObjects.ToList());
        }

        public virtual void UpdateRange(IList<TObject> TObjects)
        {
            foreach (var TObject in TObjects)
                Update(TObject);
        }

        public virtual int Count()
        {
            return DbSet.Count();
        }

        public virtual int Count(Expression<Func<TObject, bool>> filterExpression)
        {
            return DbSet.Count(filterExpression);
        }

        public TObject GetById(TKey id, params Expression<Func<TObject, object>>[] properties)
        {
            var query = DbSet.AsQueryable();

            return query.FirstOrDefault(x => x.Id.ToString() == id.ToString());
        }

        public Task<TObject> GetByIdAsync(TKey id, params Expression<Func<TObject, object>>[] properties)
        {
            var query = DbSet.AsQueryable();

            return query.FirstOrDefaultAsync(x => x.Id.ToString() == id.ToString());
        }

        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await this.Context.SaveChangesAsync();
        }

        protected void IncludeProperties(ref IQueryable<TObject> query, params Expression<Func<TObject, object>>[] properties)
        {
            foreach (var includeProperty in properties)
            {
                query = query.Include(includeProperty);
            }
        }

        public virtual void DetachLocal(TObject entity)
        {
            var local = DbSet.Local.FirstOrDefault(o => o.Id.Equals(entity.Id));
            if (local == null)
                return;
            Context.Entry(local).State = EntityState.Detached;
        }

        public void SetState(object entity, EntityState state)
        {
            Context.Entry(entity).State = state;
        }
        #endregion

        public void CleanChangeTracker()
        {
            Context.ChangeTracker.Clear();
        }

        Task<TObject> IBaseRepository<TObject, TKey>.GetByIdAsync(TKey id, params Expression<Func<TObject, object>>[] properties)
        {
            throw new NotImplementedException();
        }

        Task<int> IBaseRepository<TObject, TKey>.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }


    }
}
