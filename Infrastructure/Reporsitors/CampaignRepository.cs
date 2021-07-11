using Common.Helper;

using Data.Interface;
using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Reporsitors
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(CampaignContext context) : base(context)
        {
        }

        public Campaign GetAvailableCampaign(int productId)
        {
            return _entities.FirstOrDefault(p => p.ProductId == productId && SystemClock.Now <= p.CampaignStartDate.AddHours(p.Duration));
        }

        public IQueryable<Campaign> GetExpiredCampaigns(DateTime dateTime)
        {
            return _entities.Where(p => p.CampaignStartDate.AddHours(p.Duration) < SystemClock.Now);
        }

        public int GetCampaignTargetSales(int campaignId)
        {
            return _entities.FirstOrDefault(x => x.Id.Equals(campaignId)).TargetSalesCount;
        }
    }
}
