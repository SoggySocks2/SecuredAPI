using Microsoft.EntityFrameworkCore;
using SecuredAPI.Identity.Data.Seeds;
using System;
using System.Threading.Tasks;

namespace SecuredAPI.Identity.Data
{
    public class IdentityDbInitializer
    {
        private readonly IdentityDbContext _dbContext;

        public IdentityDbInitializer(IdentityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Seed the identity database
        /// </summary>
        /// <param name="retry">Number of attempts to seed the database.</param>
        public async Task Seed(int retry = 0)
        {
            try
            {
                await SeedRoles();
                await SeedUsers();
            }
            catch
            {
                if (retry > 0)
                {
                    await Seed(retry - 1);
                }
            }
        }

        private async Task SeedRoles()
        {
            if (await _dbContext.Roles.CountAsync() == 0)
            {
                _dbContext.Roles.AddRange(RoleSeed.GetRoles());
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                // Since at this stage while working on the API we'll be adding new permissions continously
                // then we'll just re-add all permissions automatically to the globaladmin role.

                var globalAdminRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.NormalizedName == RoleSeed.GlobalAdminRoleNameNormalized);
                var permissions = PermissionSeed.GeneratePermissionsForAdmin();
                globalAdminRole.ClearAndAddPermissions(permissions);

                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task SeedUsers()
        {
            if (await _dbContext.Users.CountAsync() == 0)
            {
                var globalAdminRole = await _dbContext.Roles.FirstOrDefaultAsync(x => x.NormalizedName == RoleSeed.GlobalAdminRoleNameNormalized);
                var users = UserSeed.GetGlobalAdminUsers();

                _dbContext.Users.AddRange(users);
                await _dbContext.SaveChangesAsync();

                users.ForEach(x => x.AssignToRole(globalAdminRole.Id));
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
