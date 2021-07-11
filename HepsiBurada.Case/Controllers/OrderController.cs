using Business.Interface;

using Common;
using Common.RequestDTO;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBurada.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IOrderBusiness _business;
        public OrderController(IOrderBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("[action]")]
        public CommonResult<bool> Create(CreateOrderRequest request)
        {
            return _business.Create(request);
        }
    }
}
