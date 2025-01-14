using Rivella.Domain.SeedWork;

namespace Rivella.Api.Middlewares;

public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (BadRequestException exception)
        {
            await HandleExceptionAsync(context, exception, StatusCodes.Status400BadRequest);
        }
        catch (KeyNotFoundException exception)
        {
            await HandleExceptionAsync(context, exception, StatusCodes.Status404NotFound);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context, exception, StatusCodes.Status500InternalServerError);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception, int statusCode)
    {
        logger.LogError(exception, "Exceção gerada {Message}", exception.Message);

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(exception.Message);
    }
}