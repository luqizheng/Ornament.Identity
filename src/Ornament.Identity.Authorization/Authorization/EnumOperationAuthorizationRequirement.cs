using System;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Ornament.Identity.Authorization
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">T should be enum </typeparam>
    public class EnumOperationAuthorizationRequirement<T> : IAuthorizationRequirement
    {
        public T Operator { get; set; }

        protected UserManageOperator ConvertTo(Claim cliam)

        {
            var value = cliam.Value;
            return (UserManageOperator)Enum.Parse(typeof(UserManageOperator), value);
        }

        public virtual bool Verify(Claim cliam)
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new ArgumentOutOfRangeException("beCheckedOp should be enum type.");
            var operatorBelongUser = ConvertTo(cliam);
            var opVal = Convert.ToInt32(Operator);
            var userOpVAl = Convert.ToInt32(operatorBelongUser);
            if (opVal < userOpVAl)
                return false;
            return (opVal & userOpVAl) == userOpVAl;
        }
    }
}