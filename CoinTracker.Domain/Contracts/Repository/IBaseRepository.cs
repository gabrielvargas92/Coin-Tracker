using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoinTracker.Domain.Contracts.Repository
{
    public interface IBaseRepository<T, G>
        where T : class
    {
        IQueryable<T> Query(Expression<Func<T, bool>> filterExpression);
        IList<T> GetAll(params Expression<Func<T, object>>[] properties);
        IList<T> GetAll(Expression<Func<T, bool>> filterExpression, params Expression<Func<T, object>>[] properties);
        T GetById(G id, params Expression<Func<T, object>>[] properties);
        Task<T> GetByIdAsync(G id, params Expression<Func<T, object>>[] properties);
        bool Contains(Expression<Func<T, bool>> filterExpression);

        T Find(Expression<Func<T, bool>> filterExpression, bool dbTracking = true);
        T Find(Expression<Func<T, bool>> filterExpression, bool dbTracking = true, params Expression<Func<T, object>>[] properties);

        void Add(IQueryable<T> t);
        void Add(T t);
        void AddRange(IEnumerable<T> entities);
        T AddReturn(T t);

        void Update(T t);
        void UpdateRange(IQueryable<T> t);
        void UpdateRange(IList<T> t);

        int Count();
        int Count(Expression<Func<T, bool>> filterExpression);

        void Delete(G id);
        void Delete(Expression<Func<T, bool>> filterExpression);
        void Delete(T t);

        int SaveChanges();
        Task<int> SaveChangesAsync();

        void SetState(object entity, EntityState state);

        void CleanChangeTracker();
    }
}
