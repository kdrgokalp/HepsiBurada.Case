using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResponseDTO
{
    public class GetCampaignResponse : IResponse
    {
        public string Name { get; set; }
        public int TargetSales { get; set; }
        public int TotalSales { get; set; }
        public decimal TurnOver { get; set; }
        public decimal AverageItemPrice { get; set; }
        public string Status { get; set; }
    }
}
