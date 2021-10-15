using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SecuredAPI.ApiGateway.Api.Configuration.Authorization;
using SecuredAPI.ApiGateway.Api.Features.Identity.Contracts;
using SecuredAPI.ApiGateway.Api.Features.Identity.Services;
using SecuredAPI.Identity;
using SecuredAPI.Identity.Configuration;
using SecuredAPI.SharedKernel.Contracts;

namespace SecuredAPI.ApiGateway.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostEnvironment HostEnvironment { get; }

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            Configuration = configuration;
            HostEnvironment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind(ClientSettings.CONFIG_NAME, ClientSettings.Instance);

            services.AddJwtAuthentication(Configuration);
            //services.AddB2CAuthentication(Configuration);
            services.AddPolicies();

            services.AddIdentityServices(Configuration, ClientSettings.Instance);

            //services.AddJwtAuthentication(Configuration);

            services.AddSingleton<IClientSettings>(services => ClientSettings.Instance);

            services.AddApiGatewayServices();

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddControllers(o =>
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    //.RequireScope(OAuthConfiguration.ScopeAccessAsUser)
                    .Build();
                o.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SecuredAPI Gateway API");
                c.RoutePrefix = "api/documentation";
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    public static class ApiGatewayConfiguration
    {
        public static void AddApiGatewayServices(this IServiceCollection services)
        {
            services.AddSingleton<IPermissionValidator>(services => PermissionValidator.Instance);

            // Identity feature
            services.AddScoped<IUserProxy, UserProxy>();
            services.AddScoped<IRoleProxy, RoleProxy>();
        }
    }
}
