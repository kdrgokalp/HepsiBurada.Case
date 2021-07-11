

using Business.Interface;
using Common;
using Common.RequestDTO;
using Common.ResponseDTO;

using Microsoft.AspNetCore.Mvc;


namespace HepsiBurada.Case.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : Controller
    {
        private readonly ICampaignBusiness _business;
        public CampaignController(ICampaignBusiness business)
        {
            _business = business;
        }

        [HttpPost]
        [Route("[action]")]
        public CommonResult<bool> Create(CreateCampaignRequest request)
        {
            return _business.Create(request);
        }

        [HttpPost]
        [Route("[action]")]
        public CommonResult<GetCampaignResponse> GetCampanignByName(GetCampaignByNameRequest request)
        {
            return _business.GetCampanignByName(request);
        }
    }
}
