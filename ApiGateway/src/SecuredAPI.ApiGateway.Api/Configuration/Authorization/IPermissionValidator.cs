using SecuredAPI.ApiGateway.Api.Features.Identity.Models;
using System.Collections.Generic;

namespace SecuredAPI.ApiGateway.Api.Configuration.Authorization
{
    public interface IPermissionValidator
    {
        void UpdateRoles(List<RoleModel> roles);
        bool ValidateForRoles(int requiredPermissionKey, string[] roles);
    }
}
