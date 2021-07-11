using Common;
using Common.RequestDTO;
using Common.ResponseDTO;

using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface ICampaignBusiness 
    {
        CommonResult<bool> Create(CreateCampaignRequest request);
        CommonResult<GetCampaignResponse> GetCampanignByName(GetCampaignByNameRequest request);
    }
}
