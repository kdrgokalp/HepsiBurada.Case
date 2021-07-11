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
    public class SystemClockController : Controller
    {
        private readonly ISystemClockBusiness _business;
        public SystemClockController(ISystemClockBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("[action]")]
        public CommonResult<DateTime> GetIncreaseTime(GetIncreaseTimeRequest request)
        {
            return _business.GetIncreaseTime(request);
        }
    }
}
