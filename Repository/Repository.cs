using UserManagementWebAPI.Common;
using UserManagementWebAPI.DTO.Request;
using UserManagementWebAPI.DTO.Result;
using UserManagementWebAPI.Data;
using System.Data.Common;
using System.Data;
using UserManagementWebAPI.Models.Entities;

namespace UserManagementWebAPI.Repository
{
    internal class Repository : IRepository
    {
        private readonly IDatabaseConnection _databaseConnection;
        private readonly ILogger<Repository> _logger;
        public Repository(IDatabaseConnection databaseConnection, ILogger<Repository> logger)
        {
            _databaseConnection = databaseConnection;
            _logger = logger;
        }

        // Add new user.
        public AddNewUserResult addNewUser(AddNewUserRequest addNewUserRequest)
        {
            AddNewUserResult result = new AddNewUserResult();
            
            try
            {
                // Creating and opening database connection.
                using DbConnection connection = _databaseConnection.CreateConnection();
                connection.Open();
                
                // Creating command and telling the system what type of command we're using which is stored procedure.
                using DbCommand command = connection.CreateCommand();
                command.CommandText = StoredProcedures.InsertNewUser;
                command.CommandType = CommandType.StoredProcedure;

                // This will check if the database provider is valid. 
                // If valid then happy path, if not then throw an error.
                DbProviderFactory? factory;
                string errorMessage = _databaseConnection.TryGetDbProviderFactory(out factory);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    result.Message = string.Concat(ResultMessage.unsuccesseful, " ", errorMessage);
                    result.Message = ResultMessage.unsuccesseful;
                    return result;
                }
                else
                {
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Firstname", addNewUserRequest.Firstname, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Middlename", addNewUserRequest.Middlename, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Lastname", addNewUserRequest.Lastname, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Birthdate", addNewUserRequest.Birthdate, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Gender", addNewUserRequest.Gender, DbType.String, factory!));

                    command.ExecuteNonQuery();
                    result.Code = ResultCode.successeful;
                    result.Message = ResultMessage.successeful;
                    return result;
                }
            }
            catch(DbException ex)
            {
                string logMessage = string.Concat("Database error in AddUser:", " ", ex.Message);
                _logger.LogError(ex, logMessage);
                result.Message = string.Concat(ResultMessage.unsuccesseful, " ", logMessage);

                return result;
            }
        }

        // Update user.
        public UpdateUserResult updateUser(UpdateUserRequest updateUserRequest)
        {
            UpdateUserResult result = new UpdateUserResult();

            try
            {
                using DbConnection connection = _databaseConnection.CreateConnection();
                connection.Open();  

                using DbCommand command = connection.CreateCommand();
                command.CommandText = StoredProcedures.UpdateUser;
                command.CommandType = CommandType.StoredProcedure; 

                DbProviderFactory? factory;
                string errorMessage = _databaseConnection.TryGetDbProviderFactory(out factory);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    result.Message = string.Concat(ResultMessage.unsuccesseful, " ", errorMessage);
                }
                else
                {
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@PersonId", updateUserRequest.PersonID, DbType.Int32, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Firstname", updateUserRequest.Firstname, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Middlename", updateUserRequest.Middlename, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Lastname", updateUserRequest.Lastname, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Birthdate", updateUserRequest.Birthdate, DbType.String, factory!));
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@Gender", updateUserRequest.Gender, DbType.String, factory!));

                    command.ExecuteNonQuery();
                    result.Code = ResultCode.successeful;
                    result.Message = ResultMessage.successeful;
                }
            }
            catch (DbException ex)
            {
                string logMessage = string.Concat("Database error in update user:", " ", ex.Message);
                _logger.LogError(ex, logMessage);
                result.Message = string.Concat(ResultMessage.unsuccesseful, " ", logMessage);
            }

            return result;
        }

        // Remove User.
        public DeleteUserResult deleteUser(DeleteUserRequest deleteUserRequest)
        {
            DeleteUserResult result = new DeleteUserResult();

            try
            {
                using DbConnection connection = _databaseConnection.CreateConnection();
                connection.Open();  

                using DbCommand command = connection.CreateCommand();
                command.CommandText = StoredProcedures.UpdateUser;
                command.CommandType = CommandType.StoredProcedure; 

                DbProviderFactory? factory;
                string errorMessage = _databaseConnection.TryGetDbProviderFactory(out factory);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    result.Message = string.Concat(ResultMessage.unsuccesseful, " ", errorMessage);
                    result.Message = ResultMessage.unsuccesseful;
                    return result;
                }
                else
                {
                    command.Parameters.Add(DatabaseParameterHelper.CreateParameter("@PersonId", deleteUserRequest.PersonID, DbType.Int32, factory!));

                    command.ExecuteNonQuery();
                    result.Code = ResultCode.successeful;
                    result.Message = ResultMessage.successeful;
                }
            }
            catch(DbException ex)
            {
                string logMessage = string.Concat("Database error in delete user:", " ", ex.Message);
                _logger.LogError(ex, logMessage);
                result.Message = string.Concat(ResultMessage.unsuccesseful, " ", logMessage);
            }

            return result;
        }

        // Get user list.
        public GetUserListResult getUserList()
        {
            GetUserListResult result = new GetUserListResult();

            try
            {
                using DbConnection connection = _databaseConnection.CreateConnection();
                connection.Open();  

                using DbCommand command = connection.CreateCommand();
                command.CommandText = StoredProcedures.UpdateUser;
                command.CommandType = CommandType.StoredProcedure; 

                DbProviderFactory? factory;
                string errorMessage = _databaseConnection.TryGetDbProviderFactory(out factory);

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    result.Message = string.Concat(ResultMessage.unsuccesseful, " ", errorMessage);
                    result.Message = ResultMessage.unsuccesseful;
                    return result;
                }
                else
                {
                    using DbDataReader reader = command.ExecuteReader();
                    User user = new User
                    {
                        Firstname = reader["Firstname"]?.ToString() ?? string.Empty,
                        Middlename = reader["Middlename"]?.ToString() ?? string.Empty,
                        Lastname = reader["Lastname"]?.ToString() ?? string.Empty,
                        Birthdate = reader["Birthdate"]?.ToString() ?? string.Empty,
                        Gender = reader["Gender"]?.ToString() ?? string.Empty
                    };
                    result.userList.Users.Add(user);

                    if(result.userList.Users.Count > 0)
                    {
                        result.Code = ResultCode.successeful;
                        result.Message = ResultMessage.successeful;
                    }
                    else
                    {
                        result.Code = ResultCode.unsuccesseful;
                        result.Message = ResultMessage.unsuccesseful;
                    }
                }
            }
            catch(DbException ex)
            {
                string logMessage = string.Concat("Database error in delete user:", " ", ex.Message);
                _logger.LogError(ex, logMessage);
                result.Message = string.Concat(ResultMessage.unsuccesseful, " ", logMessage);
            }

            return result;
        }
    }
}