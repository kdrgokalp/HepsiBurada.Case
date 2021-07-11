using Data;
using Data.Interface;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbSet<TEntity> _entities;

        public Repository(CampaignContext context)
        {
            _entities = context.Set<TEntity>();

        }


        public virtual TEntity Insert(TEntity entity)
        {
            
            var result = _entities.Add(entity);
            return result.Entity;
        }
        public virtual TEntity Get(int Id)
        {
            return _entities.FirstOrDefault(p => p.Id == Id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities;
        }

        public virtual IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Where(predicate);
        }

        public virtual void Update(TEntity entity)
        {
            _entities.Update(entity).State = EntityState.Modified;
            
        }

        public virtual void Delete(TEntity entity)
        {
            
            _entities.Remove(entity);
        }
    }
}
