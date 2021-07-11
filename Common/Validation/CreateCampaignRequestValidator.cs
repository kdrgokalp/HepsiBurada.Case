using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{
    public class CreateCampaignRequestValidator : AbstractValidator<CreateCampaignRequest>
    {
        public CreateCampaignRequestValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.ProductCode).NotEmpty();
            RuleFor(p => p.Duration).GreaterThan(0);
            RuleFor(p => p.PriceManipulationLimit).GreaterThan(0);
            RuleFor(p => p.TargetSalesCount).GreaterThan(0);
        }
    }
}
