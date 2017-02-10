using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Ornament.Identity.Web.Authorization;

namespace Ornament.Identity.Web
{
    public static class IdentityAdminOperatorExtentations
    {
        public static ServiceCollection AddUserManagerPolicy(this ServiceCollection services)
        {
            services
                .AddSingleton
                <IAuthorizationHandler, EnumOperatorRequirementHandler<UserManageRequirement, UserManageOperator>>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(UserManageRequirement.PolicyName,
                    policy =>
                    {
                        policy.Requirements.Add(UserManageRequirement.Create);
                        policy.Requirements.Add(UserManageRequirement.Delete);
                        policy.Requirements.Add(UserManageRequirement.Read);
                        policy.Requirements.Add(UserManageRequirement.Sensitive);
                        policy.Requirements.Add(UserManageRequirement.Update);
                    });
            });
            services
                .AddSingleton
                <IAuthorizationHandler, EnumOperatorRequirementHandler<RoleManageRequirement, RoleManageOperator>>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy(RoleManageRequirement.PolicyName,
                    policy =>
                    {
                        policy.Requirements.Add(RoleManageRequirement.Create);
                        policy.Requirements.Add(RoleManageRequirement.Delete);
                        policy.Requirements.Add(RoleManageRequirement.Read);
                        policy.Requirements.Add(RoleManageRequirement.Update);
                    });
            });
            return services;
        }
    }
}