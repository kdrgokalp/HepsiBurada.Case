using Common.RequestDTO;

using FluentValidation;

using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Validation
{
    public class GetProductByProductCodeRequestValidator : AbstractValidator<GetProductByProductCodeRequest>
    {
        public GetProductByProductCodeRequestValidator()
        {
            RuleFor(v => v.ProductCode).NotEmpty();
        }
    }
}
