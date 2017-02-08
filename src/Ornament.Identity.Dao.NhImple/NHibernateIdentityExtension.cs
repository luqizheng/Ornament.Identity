using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ornament.Identity.Dao.NhImple.Mapping;
using Ornament.Identity.Stores;

namespace Ornament.Identity.Dao.NhImple
{
    public static class NHibernateIdentityExtension
    {
        public static IdentityBuilder AddNhibernateStores(
            this IdentityBuilder builder,
            NhUowFactoryBase nhbuilder
        )
        {
            if (nhbuilder == null)
                throw new ArgumentNullException(nameof(nhbuilder));

            GetDefaultServices(builder, nhbuilder);
            //AddDefualtMap(builder, nhbuilder);
            return builder;
        }

        public static IdentityBuilder AddEnterprise(this IdentityBuilder builder, NhUowFactoryBase nhbuilder)
        {
            builder.Services.AddScoped(typeof(IOrgStore), typeof(OrgStore));

            nhbuilder.AddType(typeof(OrgMapping));
            var permissionType = typeof(PermissionMapping<>).MakeGenericType(builder.RoleType);
            nhbuilder.AddType(permissionType);

            return builder;
        }

        //private static void AddDefualtMap(IdentityBuilder identityBuilder,
        //    NhUowFactoryBase nhbuilder)
        //{
        //    var roleMappingClass = typeof(IdentityRoleMapping<,>)
        //        .MakeGenericType(identityBuilder.RoleType, RoleIdType(identityBuilder));

        //    nhbuilder.AddType(roleMappingClass);

        //    var userMappingClass = typeof(IdentityUserMapping<,,>)
        //        .MakeGenericType(identityBuilder.UserType, UserIdType(identityBuilder), identityBuilder.RoleType);

        //    nhbuilder.AddType(userMappingClass);
        //}

        private static void GetDefaultServices(
            IdentityBuilder identity, NhUowFactoryBase nhibernateBuilder
        )
        {
            var userStoreType = typeof(UserStore<,,,>)
                .MakeGenericType(identity.UserType, UserIdType(identity), identity.RoleType, RoleIdType(identity));
            var roleStoreType = typeof(RoleStore<,>)
                .MakeGenericType(identity.RoleType, RoleIdType(identity));

            var service1 = typeof(IUserStore<>).MakeGenericType(identity.UserType);
            var service2 = typeof(IRoleStore<>).MakeGenericType(identity.RoleType);

            identity.Services.AddScoped(service1, userStoreType);
            identity.Services.AddScoped(service2, roleStoreType);

            //add nh hibernate
        }

        private static Type UserIdType(this IdentityBuilder identity)
        {
            var userIdType = identity.UserType.BaseType;

            if (userIdType != null)
                return userIdType.GetGenericArguments()[0];
            throw new ArgumentOutOfRangeException(nameof(identity), "IdentityUserType should inherit from IdentityUser");
        }

        private static Type RoleIdType(this IdentityBuilder identity)
        {
            var baseType = identity.RoleType.BaseType;

            if (baseType != null)
                return baseType.GetGenericArguments()[0];
            throw new ArgumentOutOfRangeException(nameof(identity), "IdentityUserType should inherit from IdentityRole");
        }
    }
}