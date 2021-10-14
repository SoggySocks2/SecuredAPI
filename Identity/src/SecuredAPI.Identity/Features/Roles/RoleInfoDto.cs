using System;

namespace SecuredAPI.Identity.Features.Roles
{
    public class RoleInfoDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
