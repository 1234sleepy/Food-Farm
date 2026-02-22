using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gateway.API.Extensions;

public static class ProblemDetailsExtension
{
    public static ProblemDetails CreateFrom(this ProblemDetailsFactory factory, HttpContext context, ValidationException exception)
    {
        var model = new ModelStateDictionary();

        foreach (var error in exception.Errors)
        {
            model.AddModelError(error.PropertyName, error.ErrorCode);
        }

        return factory.CreateValidationProblemDetails(context, model, StatusCodes.Status400BadRequest);
    }
}
