using System;
using System.Collections.Generic;

namespace SecuredAPI.Identity.Features.Roles
{
    public class UpdateRoleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> SelectedPermissionIds { get; set; }
    }
}
