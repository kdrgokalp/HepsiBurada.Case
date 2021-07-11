using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class ProductStockRepository : Repository<ProductStock>, IProductStockRepository
    {
        public ProductStockRepository(CampaignContext context) : base(context)
        {
        }

        public int GetProductStockCount(int productId)
        {
            return _entities.Where(p => p.ProductId == productId).Sum(p => p.Quantity);
            
        }
    }
}
