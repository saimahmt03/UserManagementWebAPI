using System;
using System.Text.Json;
using UserManagementWebAPI.Service;

namespace UserManagementWebAPI.Middleware
{
    internal class JSONFormatValidatorMiddleware : IMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly IErrorLoggingService _ierrorloggingservice;

        public JSONFormatValidatorMiddleware(RequestDelegate next, IErrorLoggingService ierrorloggingservice)
        {   
            _next = next;
            _ierrorloggingservice = ierrorloggingservice;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var body = string.Empty;
            
            if (context.Request.ContentType != null && context.Request.ContentType.Contains("application/json"))
            {
                context.Request.EnableBuffering();

                using(var reader = new StreamReader(context.Request.Body, leaveOpen: true))
                {
                    body = await reader.ReadToEndAsync().ConfigureAwait(false);
                    if (string.IsNullOrWhiteSpace(body))
                    {
                        context.Response.StatusCode = 400;
                        await context.Response.WriteAsync("Invalid JSON: Empty body.").ConfigureAwait(false);

                        _ierrorloggingservice.LogRequest(body, 400);

                        return;
                    }

                    using (JsonDocument.Parse(body)) { }

                    context.Request.Body.Position = 0;

                    _ierrorloggingservice.LogRequest(body, 200);
                }
                await _next(context).ConfigureAwait(false);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid Request: Content-Type must be 'application/json'.").ConfigureAwait(false);

                _ierrorloggingservice.LogRequest(body, 400);
            }
        }
    }
}