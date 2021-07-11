using Business.Interface;

using Common;
using Common.Helper;
using Common.RequestDTO;

using Data.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Classes
{
    public class SystemClockBusiness : ISystemClockBusiness
    {
        private readonly IUnitOfWork _uow;
        public SystemClockBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public CommonResult<DateTime> GetIncreaseTime(GetIncreaseTimeRequest request)
        {
            CommonResult<DateTime> result = new CommonResult<DateTime>();
            SystemClock.IncreaseTime(request.Hour);

            var campaign = _uow.CampaignRepository.GetExpiredCampaigns(SystemClock.Now);
            if (campaign != null)
            {
                foreach (var item in campaign.ToList())
                {
                    item.Passive();
                    _uow.CampaignRepository.Update(item);
                }

            }

            result.Data = SystemClock.Now;
            result.Succeeded = true;
            return result;
        }
    }
}
