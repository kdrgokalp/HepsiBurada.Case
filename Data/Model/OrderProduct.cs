using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class OrderProduct : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int? CampaignId { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountedPrice  { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }

        public virtual Order Order { get; set; }
    }
}
