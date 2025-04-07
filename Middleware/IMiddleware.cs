

namespace UserManagementWebAPI.Middleware
{
    public interface IMiddleware
    {
       Task InvokeAsync(HttpContext context);
    }
}