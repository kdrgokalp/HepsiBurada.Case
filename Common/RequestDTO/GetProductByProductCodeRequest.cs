﻿using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class GetProductByProductCodeRequest : IRequest
    {
        public string ProductCode { get; set; }
    }
}
