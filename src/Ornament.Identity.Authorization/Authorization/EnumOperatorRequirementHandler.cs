using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Ornament.Identity.Web.Authorization
{
    public class EnumOperatorRequirementHandler<TRequirement, TOperator> :
        AuthorizationHandler<TRequirement>
        where TRequirement : EnumOperationAuthorizationRequirement<TOperator>

    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            TRequirement requirement)
        {
            var cliam = context.User.FindFirst(s => s.Type == UserManageRequirement.PolicyName
                                                    && s.Issuer == "Permission");
            if (cliam == null)
                context.Fail();
            if (requirement.Verify(cliam))
                context.Succeed(requirement);
            else
                context.Fail();

            return Task.CompletedTask;
        }
    }
}