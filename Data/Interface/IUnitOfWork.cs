using Data;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IProductStockRepository ProductStockRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderProductRepository OrderProductRepository { get; }
        public ICampaignRepository CampaignRepository { get; }
        //public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        public int SaveChanges();
    }
}
