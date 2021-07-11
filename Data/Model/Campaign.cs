using Data.Enums;

using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public int ProductId { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public DateTime CampaignStartDate { get; set; }
       
    }
}
