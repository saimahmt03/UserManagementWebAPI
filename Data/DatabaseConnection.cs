using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace UserManagementWebAPI.Data
{
    internal class DatabaseConnection : IDatabaseConnection
    {
        private readonly string _connectionString;
        private readonly string _providerName;

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") 
                ?? throw new ArgumentNullException(nameof(configuration), "Database connection string is missing.");

            _providerName = configuration["DatabaseProvider"] 
                ?? throw new ArgumentNullException(nameof(configuration), "Database provider name is missing.");
        }

        public DbConnection CreateConnection()
        {
            DbProviderFactory? factory = DatabaseProviderFactory.GetDbProviderFactory(_providerName) 
                ?? throw new InvalidOperationException($"Unsupported database provider: {_providerName}");

            DbConnection connection = factory.CreateConnection() 
                ?? throw new InvalidOperationException("Failed to create a database connection.");

            connection.ConnectionString = _connectionString;
            return connection;
        }

        public string TryGetDbProviderFactory(out DbProviderFactory? factory)
        {
            factory = DatabaseProviderFactory.GetDbProviderFactory(_providerName);

            if (factory == null)
            {
                return "Database provider factory is missing."; // Return error message instead of throwing
            }

            return string.Empty;
        }
    }
}