

using Data;
using Data.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infrastructure.Reporsitors;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CampaignContext _context;
        private readonly IProductRepository _productRepository;
        private readonly IProductStockRepository _productStockRepository;
        private readonly IOrderProductRepository _orderProductRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ICampaignRepository _campaignRepository;

        public UnitOfWork(CampaignContext campaignContext, 
                          IProductRepository productRepository, 
                          IProductStockRepository productStockRepository,
                          IOrderProductRepository orderProductRepository,
                          IOrderRepository orderRepository,
                          ICampaignRepository campaignRepository
                          )
        {
            if (campaignContext == null)
                throw new ArgumentNullException("dbContext can not be null.");
            _context = campaignContext;

            _productRepository = productRepository;
            _productStockRepository = productStockRepository;
            _orderProductRepository = orderProductRepository;
            _orderRepository = orderRepository;
            _campaignRepository = campaignRepository;
        }

        public IProductRepository ProductRepository => _productRepository;
        public IProductStockRepository ProductStockRepository => _productStockRepository;
        public IOrderProductRepository OrderProductRepository => _orderProductRepository;
        public IOrderRepository OrderRepository => _orderRepository;
        public ICampaignRepository CampaignRepository => _campaignRepository;
        public int SaveChanges()
        {
            var result = _context.SaveChanges();
            return result;
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
