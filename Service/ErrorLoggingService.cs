using UserManagementWebAPI.Repository;
using UserManagementWebAPI.Common;

namespace UserManagementWebAPI.Service
{
    internal class ErrorLoggingService : IErrorLoggingService
    {
        private string ErrorMessage = string.Empty;
        private string RequestBody = string.Empty;
        private int StatusCode;

        private readonly IErrorLoggingRepository _errorLoggingRepository;

        public ErrorLoggingService(IErrorLoggingRepository errorLoggingRepository)
        {
            _errorLoggingRepository = errorLoggingRepository;
        }


        public void LogError(Exception exception)
        {
            ErrorMessage = string.Concat("ErrorMessage: ", exception.Message, " StackTrace: ", exception.StackTrace);
            
            Console.WriteLine(ErrorMessage);
        }

        public void LogRequest(string log, int statuscode)
        {
            StatusCode = statuscode;
            RequestBody = log;   
        }

        internal void StoreLog()
        {
            if(!string.IsNullOrWhiteSpace(ErrorMessage))
            {   
                _errorLoggingRepository.StoreLog(RequestBody, ErrorMessage, ResultCode.unsuccesseful, ResultMessage.unsuccesseful);
            }
            else
            {
                _errorLoggingRepository.StoreLog(RequestBody, ErrorMessage, ResultCode.successeful, ResultMessage.successeful);
            }
        }
    }
}