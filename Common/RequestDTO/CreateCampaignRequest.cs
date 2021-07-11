using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class CreateCampaignRequest : IRequest
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal PriceManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
