using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(CampaignContext context) : base(context)
        {
        }

        public int GetOrderProductStockCount(int productId)
        {
            return _entities.Where(p => p.ProductId == productId).Sum(p => p.Quantity);
        }

        public int GetCampaignSalesCount(int campaignId)
        {
            return _entities.Where(x => x.CampaignId.Equals(campaignId)).Sum(x => x.Quantity);
        }
    }
}
