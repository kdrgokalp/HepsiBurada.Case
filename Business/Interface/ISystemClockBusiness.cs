using Common;
using Common.RequestDTO;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ISystemClockBusiness
    {
        CommonResult<DateTime> GetIncreaseTime(GetIncreaseTimeRequest request);
    }
}
