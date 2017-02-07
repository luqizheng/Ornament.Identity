using System;
using System.Collections.Generic;
using Ornament.Stores;

namespace Ornament.Identity.Stores
{
    public interface IUserPermissionStore<in TUser, TKey, TRole>
        : IStore<Permission<TRole>, int>
        where TUser : IdentityUser<TKey, TRole>
        where TKey : IEquatable<TKey>


    {
        IList<Permission<TRole>> GetByUser(TUser user);

        IList<Permission<TRole>> GetPermissionsByUser(TUser user,string resourceName);
    }
}