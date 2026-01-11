using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Product.MicroService.API.Extensions.Error;

public class ErrorMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate next = next;

    public async Task InvokeAsync(HttpContext context,
        IWebHostEnvironment environment,
        ILogger<ErrorMiddleware> logger,
        ProblemDetailsFactory factory)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception ex)
        {
            

            ProblemDetails problemDetails;

            switch (ex)
            {
                case ValidationException exception:
                    problemDetails = factory.CreateFrom(context, exception);
                    logger.LogInformation(exception, "Invalid Request");

                    break;

                default:
                    problemDetails = factory.CreateProblemDetails(context, StatusCodes.Status500InternalServerError, "Unhandled Error, contact us");
                    logger.LogError(
                        ex,
                        "Error has happened with {RequestPath}, the message is {ErrorMessage}",
                        context.Request.Path.Value, ex.Message);

                    break;
            }

            context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problemDetails, problemDetails.GetType());
        }
    }
}


//Add Jaeger/Error everywhere
//path in jaeger