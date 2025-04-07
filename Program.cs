using Microsoft.AspNetCore.Diagnostics;
using UserManagementWebAPI.Repository;
using UserManagementWebAPI.Service;
using UserManagementWebAPI.Data;
using UserManagementWebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IService, Service>();
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<IDatabaseConnection, DatabaseConnection>();
builder.Services.AddScoped<IErrorLoggingService, ErrorLoggingService>();
builder.Services.AddScoped<IErrorLoggingRepository, ErrorLoggingRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionHandlerFeature != null)
        {
            var exception = exceptionHandlerFeature.Error;

            // Get the error logging service
            var errorLoggingService = context.RequestServices.GetRequiredService<IErrorLoggingService>();


            // Return a clean error response
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var errorResponse = new
            {
                status = 500,
                message = "An unexpected error occurred. Please try again later."
            };

            await context.Response.WriteAsJsonAsync(errorResponse);
        }
    });
});

app.ConfigureSwagger();
app.ConfigureSecurity();
app.ConfigureEndpoints();
app.Run();

