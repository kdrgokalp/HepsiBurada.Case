using Common;
using Common.RequestDTO;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IOrderBusiness
    {
        CommonResult<bool> Create(CreateOrderRequest request);
    }
}
