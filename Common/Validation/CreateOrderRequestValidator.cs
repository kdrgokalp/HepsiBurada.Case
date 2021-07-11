using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(v => v.ProductCode).NotEmpty();
            RuleFor(v => v.Quentity).GreaterThan(0);
        }
    }
}
