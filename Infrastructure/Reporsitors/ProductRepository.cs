using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(CampaignContext context) : base(context)
        {
        }

        public Product GetProductByProductCode(string code)
        {
            return _entities.FirstOrDefault(p => p.ProductCode.ToLower() == code.ToLower());
        }
    }
}
