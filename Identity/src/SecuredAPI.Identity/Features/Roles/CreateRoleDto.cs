using System.Collections.Generic;

namespace SecuredAPI.Identity.Features.Roles
{
    public class CreateRoleDto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> SelectedPermissionIds { get; set; }
    }
}
