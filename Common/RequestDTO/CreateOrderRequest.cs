using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class CreateOrderRequest : IRequest
    {
        public string ProductCode { get; set; }
        public int Quentity { get; set; }
    }
}
