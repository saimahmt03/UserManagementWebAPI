
namespace UserManagementWebAPI.Service
{
    public interface IErrorLoggingService
    {
        void LogError(Exception exception);
        void LogRequest(string log, int statuscode);
    }
}