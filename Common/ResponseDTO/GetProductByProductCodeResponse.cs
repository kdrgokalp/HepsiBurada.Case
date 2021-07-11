using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.ResponseDTO
{
    public class GetProductByProductCodeResponse : IResponse
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public long Stock { get; set; }
    }
}
