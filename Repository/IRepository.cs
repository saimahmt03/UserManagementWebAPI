using UserManagementWebAPI.DTO.Request;
using UserManagementWebAPI.DTO.Result;
using UserManagementWebAPI.Models.Entities;

namespace UserManagementWebAPI.Repository
{
    public interface IRepository
    {
        AddNewUserResult addNewUser(AddNewUserRequest addNewUserRequest);
        GetUserListResult getUserList();
        UpdateUserResult updateUser(UpdateUserRequest updateUserRequest);
        DeleteUserResult deleteUser(DeleteUserRequest deleteUserRequest);
    }
}