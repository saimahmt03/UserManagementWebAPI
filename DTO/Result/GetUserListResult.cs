using UserManagementWebAPI.Common;
using UserManagementWebAPI.Models.Entities;

namespace UserManagementWebAPI.DTO.Result
{
    public class GetUserListResult : BaseResult
    {
        public UserList userList {get; set;} = new();
    }
}