using System;
using System.Collections.Generic;

namespace SecuredAPI.Identity.Features.Users
{
    public class UpdateUserDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsStaff { get; set; }
        public string LanguageCode { get; set; }

        public List<Guid> RoleIds { get; set; }
    }
}
