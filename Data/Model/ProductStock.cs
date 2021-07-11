using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class ProductStock: BaseEntity
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
        
    }
}
