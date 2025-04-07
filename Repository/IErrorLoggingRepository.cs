using System;

namespace UserManagementWebAPI.Repository
{
    public interface IErrorLoggingRepository
    {
        void StoreLog(string request, string log, string statusmessage, string statuscode);
    }
}