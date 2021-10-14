using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecuredAPI.Identity.Data;
using SecuredAPI.Identity.Data.Contracts;
using SecuredAPI.Identity.Features.Roles;
using SecuredAPI.Identity.Features.Users;
using SecuredAPI.SharedKernel.Contracts;

namespace SecuredAPI.Identity
{
    public static class IdentityServicesConfiguration
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration, IClientSettings clientSettings)
        {
            /* Add the identity database context */
            services.AddDbContext<IdentityDbContext>(options => options.UseSqlServer(clientSettings.ConnectionString));

            /* Allow auto database migration and seeding */
            services.AddScoped<IdentityDbInitializer>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();

            /* Auto mapper used for mapping classes to DTO's, etc. */
            services.AddAutoMapper(typeof(IdentityServicesConfiguration).Assembly);
        }
    }
}
