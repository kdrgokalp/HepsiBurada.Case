using Data.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IProductStockRepository : IRepository<ProductStock>
    {
        int GetProductStockCount(int productId);
    }
}
