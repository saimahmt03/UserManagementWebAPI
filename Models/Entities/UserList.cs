using System;

namespace UserManagementWebAPI.Models.Entities
{
    public class UserList
    {
        public List<User> Users { get; } = new();
    }
}