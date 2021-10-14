﻿using SecuredAPI.Identity.Data.Entities;
using System.Collections.Generic;

namespace SecuredAPI.Identity.Data.Seeds
{
    public static class RoleSeed
    {
        public static string GlobalAdminRoleNameNormalized = "GlobalAdmin".Normalize().ToUpperInvariant();

        public static List<Role> GetRoles()
        {
            var permissions = PermissionSeed.GeneratePermissionsForAdmin();
            var globalAdminRole = new Role("GlobalAdmin", "Global admin role");
            globalAdminRole.ClearAndAddPermissions(permissions);

            return new List<Role>
            {
                globalAdminRole,
                new Role("Admin", "Admin role"),
                new Role("RetailerAdmin", "Retailer admin role"),
                new Role("Retailer", "Retailer role"),
            };
        }
    }
}
