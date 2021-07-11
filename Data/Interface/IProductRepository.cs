using Data.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IProductRepository : IRepository<Product>
    {
        public Product GetProductByProductCode(string code);
    }
}
