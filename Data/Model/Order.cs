using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Model
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal OrderValue { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
