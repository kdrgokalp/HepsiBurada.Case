using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{
    public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
    {
        public CreateProductRequestValidator()
        {
            RuleFor(v => v.ProductCode).NotEmpty();
            RuleFor(v => v.Price).GreaterThan(0);
            RuleFor(v => v.Stock).GreaterThan(0);
        }
    }
}
