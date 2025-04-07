using Microsoft.AspNetCore.Mvc;
using UserManagementWebAPI.Common;
using UserManagementWebAPI.DTO.Request;
using UserManagementWebAPI.DTO.Result;
using UserManagementWebAPI.Service;

namespace UserManagementWebAPI.Controller
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("usermanagement")]
    public class UserManagementController : ControllerBase
    {
        private readonly IService _service;   

        public UserManagementController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("addnewuser")] 
        public IActionResult AddNewUser([FromBody] AddNewUserRequest addNewUserRequest)
        {
            AddNewUserResult result = new AddNewUserResult();
            result = _service.AddNewUserValidation(addNewUserRequest);
            
            if(result.Code == ResultCode.successeful && result.Message == ResultMessage.successeful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        [Route("updateuser")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            UpdateUserResult result = new UpdateUserResult();
            result = _service.UpdateUserValidation(updateUserRequest);
            
            if(result.Code == ResultCode.successeful && result.Message == ResultMessage.successeful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpDelete]
        [Route("deleteuser")]
        public IActionResult DeleteUser([FromBody] DeleteUserRequest deleteUserRequest)
        {
            DeleteUserResult result = new DeleteUserResult();
            result = _service.DeleteUserValidation(deleteUserRequest);
            
            if(result.Code == ResultCode.successeful && result.Message == ResultMessage.successeful)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}