﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SecuredAPI.SharedKernel.SharedObjects;

namespace SecuredAPI.ApiGateway.Api.Configuration.Authorization
{
    public static class OAuthConfiguration
    {
        public const string ScopeAccessAsUser = "access_as_user";


        public static void AddB2CAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                //.AddMicrosoftIdentityWebApi(options =>
                //{
                //    configuration.Bind("AzureAdB2C", options);

                //    //options.TokenValidationParameters.NameClaimType = "name";
                //},
                //options => { configuration.Bind("AzureAdB2C", options); })
                ;
        }

        public static void AddPolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireScope(ScopeAccessAsUser).Build();

                options.AddPolicy(ScopeAccessAsUser, policy => policy.RequireScope(ScopeAccessAsUser));

                foreach (var permissionKey in PermissionKey.List)
                {
                    options.AddPolicy(permissionKey.Name, policy => policy.RequirePermission(permissionKey.Value));
                }
            });
        }
    }
}
