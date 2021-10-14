using System;
using System.Collections.Generic;

namespace SecuredAPI.Identity.Features.Users
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsStaff { get; set; }
        public string LanguageCode { get; set; }

        public List<RoleNameDto> Roles { get; set; }
    }
}
