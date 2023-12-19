using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace QuirkyCarRepair.API.Interceptors
{
    public class CamelCaseValidatorInterceptor : IValidatorInterceptor
    {
        public ValidationResult AfterAspNetValidation(ActionContext actionContext, IValidationContext validationContext, ValidationResult result)
        {
            if (!result.IsValid)
            {
                foreach (var error in result.Errors)
                {
                    var newPropertyName = char.ToLower(error.PropertyName[0]) + error.PropertyName.Substring(1);
                    error.PropertyName = newPropertyName;
                }
            }

            return result;
        }

        public IValidationContext BeforeAspNetValidation(ActionContext actionContext, IValidationContext commonContext)
        {
            return null;
        }
    }
}