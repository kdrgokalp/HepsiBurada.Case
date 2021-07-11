using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(CampaignContext context) : base(context)
        {
        }

        
    }
}
