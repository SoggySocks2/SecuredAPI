using System.Collections.Generic;

namespace SecuredAPI.ApiGateway.Api.Features.Identity.Models
{
    public class CreateRoleModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<int> SelectedPermissionIds { get; set; }
    }
}
