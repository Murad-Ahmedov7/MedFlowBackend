using Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace MedFlow.Api.Infrastructures.Middlewares;

internal class ExceptionHandlerMiddleware
{
    private static readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DatabaseException ex)
        {
            await WriteError(context, HttpStatusCode.BadRequest, new HttpErrorResponse(ex.Message, ex.Code));
        }

        catch (NotFoundException ex) 

        {
            var errors = ex.Errors.Any()
                ? ex.Errors.Select(e => new HttpErrorResponse(e))   
                : [new HttpErrorResponse("Məlumat tapılmadı")];

            await WriteError(context, HttpStatusCode.NotFound, errors);
        }


        catch (ClientException ex)
        {
            var errors = ex.Errors.Any()
                ? ex.Errors.Select(e => new HttpErrorResponse(e))
                : [new HttpErrorResponse("Client xətası")];
            await WriteError(context, HttpStatusCode.BadRequest, errors);
        }
        catch (UnauthorizedAccessException ex)
        {
            await WriteError(context, HttpStatusCode.Unauthorized, ex.Message);
        }
        catch (ServerException ex)
        {
            await WriteError(context, HttpStatusCode.InternalServerError, ex.Message);
        }
        catch (Exception ex)
        {
            await WriteError(context, HttpStatusCode.InternalServerError, ex.Message + Environment.NewLine + ex.StackTrace);
        }
    }

    internal static async Task WriteError(HttpContext context, HttpStatusCode statusCode, string message, int code = 0)
    {
        await WriteError(context, statusCode, new HttpErrorResponse(message, code));
    }

    private static async Task WriteError(HttpContext context, HttpStatusCode statusCode, HttpErrorResponse error)
    {
        await WriteError(context, statusCode, [error]);
    }

    private static async Task WriteError(HttpContext context, HttpStatusCode statusCode, IEnumerable<HttpErrorResponse> errors)
    {
        context.Response.Clear();
        context.Response.StatusCode = (int)statusCode;
        context.Response.ContentType = "application/json; charset=utf-8";

        var json = JsonSerializer.Serialize(errors, Options);
        await context.Response.WriteAsync(json);
    }
}
