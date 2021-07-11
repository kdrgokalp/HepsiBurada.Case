using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Product : BaseEntity
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<ProductStock> ProductStocks { get; set; }
    }
}
