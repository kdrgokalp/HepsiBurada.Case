using Common;
using Common.RequestDTO;
using Common.ResponseDTO;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IProductBusiness
    {
        CommonResult<bool> Create(CreateProductRequest request);
        CommonResult<GetProductByProductCodeResponse> GetProductByProductCode( GetProductByProductCodeRequest request);
    }
}
