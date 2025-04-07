using System.Data;
using System.Data.Common;
using UserManagementWebAPI.Common;
using UserManagementWebAPI.Data;


namespace UserManagementWebAPI.Repository
{
    internal class ErrorLoggingRepository : IErrorLoggingRepository
    {

        private readonly IDatabaseConnection _databaseConnection;
        private readonly ILogger<Repository> _logger;
        public ErrorLoggingRepository(IDatabaseConnection databaseConnection, ILogger<Repository> logger)
        {
            _databaseConnection = databaseConnection;
            _logger = logger;
        }

        public void StoreLog(string request, string log, string statusmessage, string statuscode)
        {
            try
            {
                using DbConnection connection = _databaseConnection.CreateConnection();
                connection.Open();

                using DbCommand command = connection.CreateCommand();
                command.CommandText = StoredProcedures.InsertNewUser;
                command.CommandType = CommandType.StoredProcedure;

                DbProviderFactory? factory;
                string errorMessage = _databaseConnection.TryGetDbProviderFactory(out factory);

                
            }
            catch
            {

            }
        }
    }
}