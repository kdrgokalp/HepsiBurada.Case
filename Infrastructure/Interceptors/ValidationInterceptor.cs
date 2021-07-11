
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Interceptors
{
    public class ValidationInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (result.Errors.Count > 0)
            {
                throw new Common.Exceptions.ValidationException(result.Errors);
            }
            return result;

        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return commonContext;
        }


    }


}
