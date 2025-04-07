using UserManagementWebAPI.DTO.Request;
using UserManagementWebAPI.DTO.Result;

namespace UserManagementWebAPI.Service
{
    public interface IService
    {
        AddNewUserResult AddNewUserValidation(AddNewUserRequest addNewUserRequest);
        GetUserListResult GetUserListValidation();
        UpdateUserResult UpdateUserValidation(UpdateUserRequest updateUserRequest);   
        DeleteUserResult DeleteUserValidation(DeleteUserRequest deleteUserRequest);
    }
}