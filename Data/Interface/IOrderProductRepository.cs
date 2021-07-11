using Data.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interface
{
    public interface IOrderProductRepository : IRepository<OrderProduct>
    {
        int GetOrderProductStockCount(int productId);
        int GetCampaignSalesCount(int campaignId);
    }
}
