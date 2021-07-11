using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{
    public class GetIncreaseTimeRequestValidator : AbstractValidator<GetIncreaseTimeRequest>
    {
        public GetIncreaseTimeRequestValidator()
        {
            RuleFor(p => p.Hour).GreaterThan(0);
        }
    }
}
