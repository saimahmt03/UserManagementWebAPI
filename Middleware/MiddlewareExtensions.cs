
namespace UserManagementWebAPI.Middleware
{
    internal static class MiddlewareExtensions
    {
        internal static void ConfigureSwagger(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.MapOpenApi();
            }
        }

        internal static void ConfigureSecurity(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
        }

        internal static void ConfigureEndpoints(this WebApplication app)
        {
            app.MapControllers();
        }
    }
}