using Tutorial6.Models;

namespace Tutorial6.Configurations;

using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        HttpStatusCode status;
        var message = exception.Message;

        switch (exception)
        {
            case ArgumentException:
                status = HttpStatusCode.BadRequest;
                break;
            case KeyNotFoundException:
                status = HttpStatusCode.NotFound;
                break;
            default:
                status = HttpStatusCode.InternalServerError;
                message = "An unexpected error occurred.";
                break;
        }

        var response = new ErrorResponseDto()
        {
            Timestamp = DateTime.UtcNow,
            Status = (int)status,
            Error = status.ToString(),
            Message = message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)status;
        var json = JsonSerializer.Serialize(response);
        return context.Response.WriteAsync(json);
    }
}
