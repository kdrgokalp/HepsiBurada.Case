using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class GetIncreaseTimeRequest : IRequest
    {
        public int Hour { get; set; }
    }
}
