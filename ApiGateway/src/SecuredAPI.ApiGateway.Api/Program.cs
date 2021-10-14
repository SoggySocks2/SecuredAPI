using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecuredAPI.ApiGateway.Api.Configuration.Authorization;
using SecuredAPI.ApiGateway.Api.Features.Identity.Contracts;
using SecuredAPI.Identity.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SecuredAPI.ApiGateway.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var environment = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();

                var identityDbInitializer = scope.ServiceProvider.GetRequiredService<IdentityDbInitializer>();
                await identityDbInitializer.Seed();

                //var configurationDbInitializer = scope.ServiceProvider.GetRequiredService<ConfigurationDbInitializer>();
                //await configurationDbInitializer.Seed(environment.IsDevelopment());

                //var coreDbInitializer = scope.ServiceProvider.GetRequiredService<CoreDbInitializer>();
                //await coreDbInitializer.Seed(environment.IsDevelopment());

                try
                {
                    var permissionValidator = scope.ServiceProvider.GetRequiredService<IPermissionValidator>();
                    var roleProxy = scope.ServiceProvider.GetRequiredService<IRoleProxy>();
                    var roles = await roleProxy.GetWithPermissionsAsync(CancellationToken.None);
                    permissionValidator.UpdateRoles(roles);
                }
                catch
                {
                    throw;
                }
            }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
