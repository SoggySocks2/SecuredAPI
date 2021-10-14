using SecuredAPI.Identity.Data.Entities;
using SecuredAPI.SharedKernel.SharedObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecuredAPI.Identity.Data.Seeds
{
    public static class PermissionSeed
    {
        public static List<Permission> GeneratePermissionsForAdmin()
        {
            var permissions = new List<Permission>();

            foreach (var permissionKey in PermissionKey.List.OrderBy(x => x.Value))
            {
                permissions.Add(new Permission(permissionKey, true));
            }

            return permissions;
        }

        public static List<Permission> GeneratePermissions(IEnumerable<int> selectedPermissionIds)
        {
            var permissions = new List<Permission>();

            foreach (var permissionKey in PermissionKey.List.OrderBy(x => x.Value))
            {
                permissions.Add(new Permission(permissionKey, selectedPermissionIds.Contains(permissionKey.Value)));
            }

            return permissions;
        }
    }
}
