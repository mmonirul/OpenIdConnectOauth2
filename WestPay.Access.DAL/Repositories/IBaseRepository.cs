using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WestPay.Access.DAL.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        void Delete(object id);
        void Delete(TEntity entityToDelete);
        void Delete(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int? skip = null, int? take = null);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
            params Expression<Func<TEntity, object>>[] includes);
        TEntity GetByID(object id);
        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);

        void Update(TEntity entityToUpdate);
    }
}