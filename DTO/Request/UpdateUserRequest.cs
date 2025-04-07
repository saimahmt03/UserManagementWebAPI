using System;

namespace UserManagementWebAPI.DTO.Request
{
    public class UpdateUserRequest
    {
        public int PersonID {get; set;}
        public string Firstname {get; set;} = string.Empty;
        public string Middlename {get; set;} = string.Empty;
        public string Lastname {get; set;} = string.Empty;
        public string Birthdate {get; set;} = string.Empty;
        public string Gender {get; set;} = string.Empty;
    }
}