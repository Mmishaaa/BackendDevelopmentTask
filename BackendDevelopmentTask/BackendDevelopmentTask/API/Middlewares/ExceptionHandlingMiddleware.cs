using System.Net;
using System.Text.Json;
using BackendDevelopmentTask.BLL.Exceptions;
using BackendDevelopmentTask.BLL.Models;
using BackendDevelopmentTask.BLL.Providers;
using BackendDevelopmentTask.BLL.Services;

namespace BackendDevelopmentTask.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IExceptionJournalService journalService, IDateTimeProvider dateTimeProvider)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, journalService, dateTimeProvider, ex);
        }
    }

    private async Task HandleExceptionAsync(
        HttpContext context, IExceptionJournalService journalService,
        IDateTimeProvider dateTimeProvider, Exception ex, CancellationToken cancellationToken = default)
    {
        var eventId = Guid.NewGuid();
        var timestamp = dateTimeProvider.UtcNow;

        var queryParams = JsonSerializer.Serialize(
            context.Request.Query.ToDictionary(k => k.Key, v => v.Value.ToString())
        );

        string? bodyParams = null;
        if (context.Request.ContentLength > 0 && context.Request.Body.CanSeek)
        {
            context.Request.Body.Position = 0;
            using var reader = new StreamReader(context.Request.Body);
            bodyParams = await reader.ReadToEndAsync(cancellationToken);
            context.Request.Body.Position = 0;
        }

        var exceptionId = Guid.NewGuid();
        
        var journalModel = new ExceptionJournalModel
        {
            Id = exceptionId,
            EventId = eventId,
            Timestamp = timestamp,
            QueryParametersJson = queryParams,
            BodyParametersJson = bodyParams,
            StackTrace = ex.ToString(),
            ExceptionType = ex.GetType().Name,
            ExceptionMessage = ex.Message
        };

        await journalService.CreateAsync(journalModel, cancellationToken);

        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        context.Response.ContentType = "application/json";

        var jsonResponse = ex is SecureException 
            ? HandleSecureExceptionResponse(ex, eventId, exceptionId) 
            : HandleGenericExceptionResponse(eventId, exceptionId);

        await context.Response.WriteAsync(jsonResponse, cancellationToken);
    }

    private string HandleSecureExceptionResponse(Exception ex, Guid eventId, Guid exceptionId)
    {
        return JsonSerializer.Serialize(new
        {
            type = "Secure",
            id = eventId.ToString(),
            data = new { message = string.Concat($"ExceptionId: {exceptionId} ", ex.Message) }
        });
    }

    private string HandleGenericExceptionResponse(Guid eventId, Guid exceptionId)
    {
        return JsonSerializer.Serialize(new
        {
            type = "Exception",
            id = eventId.ToString(),
            data = new { message = $"Internal server errorId = {exceptionId}, eventId = {eventId}" }
        });
    }
}