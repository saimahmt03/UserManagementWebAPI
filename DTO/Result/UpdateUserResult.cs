using UserManagementWebAPI.Common;

namespace UserManagementWebAPI.DTO.Result
{
    public class UpdateUserResult 
    {
        public string Message {get; set;} = string.Empty;
        public string Code { get; set;} = string.Empty;
    }
}