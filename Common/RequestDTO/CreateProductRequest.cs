using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class CreateProductRequest : IRequest
    {
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
