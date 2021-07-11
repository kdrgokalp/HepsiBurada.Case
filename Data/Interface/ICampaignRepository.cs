using Data.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Interface
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        Campaign GetAvailableCampaign(int productId);
        IQueryable<Campaign> GetExpiredCampaigns(DateTime dateTime);
        int GetCampaignTargetSales(int campaignId);
    }
}
