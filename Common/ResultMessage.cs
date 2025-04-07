
namespace UserManagementWebAPI.Common
{
    public static class ResultMessage
    {
        internal const string validated = "Validated.";
        internal const string successeful = "Successful.";
        internal const string invalid = "Invalid.";
        internal const string unsuccesseful = "Unsuccessful.";
    }
    
    public static class ResultCode
    {
        internal const string validated = "CODE201";
        internal const string successeful = "CODE200";
        internal const string invalid = "CODE400";
        internal const string unsuccesseful = "CODE500";
    }
}