using Common.Interface;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.RequestDTO
{
    public class GetCampaignByNameRequest : IRequest
    {
        public string Name { get; set; }
    }
}
