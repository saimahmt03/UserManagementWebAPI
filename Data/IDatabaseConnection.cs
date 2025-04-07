using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace UserManagementWebAPI.Data
{
    internal interface IDatabaseConnection
    {
        DbConnection CreateConnection(); // support multiple databases
        string TryGetDbProviderFactory(out DbProviderFactory? factory);
    }
}