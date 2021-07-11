using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{
    public class GetCampaignByNameRequestValidator : AbstractValidator<GetCampaignByNameRequest>
    {
        public GetCampaignByNameRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
        }
    }
}
