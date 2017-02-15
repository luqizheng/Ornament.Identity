using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ornament.Identity.Dao.NhImple.Mapping;
using Ornament.Identity.Stores;

namespace Ornament.Identity.Dao.NhImple
{
    public static class NHibernateIdentityExtension
    {
        /// <summary>
        /// </summary>
        /// <typeparam name="TUserMap"></typeparam>
        /// <typeparam name="TRoleMap"></typeparam>
        /// <param name="builder"></param>
        /// <param name="nhbuilder"></param>
        /// <returns></returns>
        public static IdentityBuilder AddNhibernateStores<TUserMap, TRoleMap>(
            this IdentityBuilder builder,
            NhUowFactoryBase nhbuilder
        )
        {
            if (nhbuilder == null)
                throw new ArgumentNullException(nameof(nhbuilder));

            GetDefaultServices(builder, nhbuilder);
            nhbuilder.AddType(typeof(TUserMap));
            nhbuilder.AddType(typeof(TRoleMap));
      
            return builder;
        }

        /// <summary>
        ///     添加企业开发的支持，如Org授权
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="nhbuilder"></param>
        /// <returns></returns>
        public static IdentityBuilder AddEnterprise(this IdentityBuilder builder, NhUowFactoryBase nhbuilder)
        {
            builder.Services.AddScoped(typeof(IOrgStore), typeof(OrgStore));

            nhbuilder.AddType(typeof(OrgMapping));


            return builder;
        }


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
            var userIdType = identity.UserType.GetTypeInfo().BaseType;

            if (userIdType != null)
                return userIdType.GetGenericArguments()[0];
            throw new ArgumentOutOfRangeException(nameof(identity), "IdentityUserType should inherit from IdentityUser");
        }

        private static Type RoleIdType(this IdentityBuilder identity)
        {
            var baseType = identity.RoleType.GetTypeInfo().BaseType;

            if (baseType != null)
                return baseType.GetGenericArguments()[0];
            throw new ArgumentOutOfRangeException(nameof(identity), "IdentityUserType should inherit from IdentityRole");
        }
    }
}