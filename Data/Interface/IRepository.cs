using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interface
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int Id);
        TEntity Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
