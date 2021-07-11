using Business.Interface;

using Common;
using Common.RequestDTO;
using Common.ResponseDTO;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBurada.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductBusiness _business;
        public ProductController(IProductBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("[action]")]
        public CommonResult<bool> Create(CreateProductRequest request)
        {
            return _business.Create(request);
        }


        [HttpPost]
        [Route("[action]")]
        public CommonResult<GetProductByProductCodeResponse> GetProductByProductCode(GetProductByProductCodeRequest request)
        {
            return _business.GetProductByProductCode(request);
        }
    }
}
