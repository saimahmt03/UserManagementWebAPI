using UserManagementWebAPI.Common;
using UserManagementWebAPI.DTO.Result;
using UserManagementWebAPI.DTO.Request;
using UserManagementWebAPI.Repository;

namespace UserManagementWebAPI.Service
{
    internal class Service : IService
    {
        private readonly IRepository _repository;
        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public AddNewUserResult AddNewUserValidation(AddNewUserRequest addNewUserRequest)
        {
            AddNewUserResult result = new AddNewUserResult();
                        
            if (string.IsNullOrWhiteSpace(addNewUserRequest.Firstname) ||
                string.IsNullOrWhiteSpace(addNewUserRequest.Middlename) ||
                string.IsNullOrWhiteSpace(addNewUserRequest.Lastname) ||
                string.IsNullOrWhiteSpace(addNewUserRequest.Birthdate) ||
                string.IsNullOrWhiteSpace(addNewUserRequest.Gender))
            {
                result.Code = ResultCode.invalid;
                result.Message = ResultMessage.invalid;
            }
            else
            {
                result = _repository.addNewUser(addNewUserRequest);
            }

            return result;
        }

        public UpdateUserResult UpdateUserValidation(UpdateUserRequest updateUserRequest)
        {
            UpdateUserResult result = new UpdateUserResult();

            if (updateUserRequest.PersonID == 0 ||
                string.IsNullOrWhiteSpace(updateUserRequest.Firstname) ||
                string.IsNullOrWhiteSpace(updateUserRequest.Middlename) ||
                string.IsNullOrWhiteSpace(updateUserRequest.Lastname) ||
                string.IsNullOrWhiteSpace(updateUserRequest.Birthdate) ||
                string.IsNullOrWhiteSpace(updateUserRequest.Gender))
            {
                result.Code = ResultCode.invalid;
                result.Message = ResultMessage.invalid;
            }
            else
            {
                result = _repository.updateUser(updateUserRequest);
            }

            return result;
        }

        public DeleteUserResult DeleteUserValidation(DeleteUserRequest deleteUserRequest)
        {
            DeleteUserResult result = new DeleteUserResult();

            if (deleteUserRequest.PersonID == 0)
            {
                result.Code = ResultCode.invalid;
                result.Message = ResultMessage.invalid;   
            }
            else
            {
                result = _repository.deleteUser(deleteUserRequest);
            }

            return result;
        }

        public GetUserListResult GetUserListValidation()
        {
            GetUserListResult result = new GetUserListResult();
            
            //result = _repository.getUserList();

            return result;
        }
    }
}