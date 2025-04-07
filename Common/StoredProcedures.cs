namespace UserManagementWebAPI.Common
{
    public static class StoredProcedures
    {
        internal const string InsertNewUser = "[dbo].[InsertPerson]";
        internal const string UpdateUser = "[dbo].[UpdatePerson]";
        internal const string DeleteUser = "[].[]";
        internal const string GetAllUsers = "[].[]";
    }
}