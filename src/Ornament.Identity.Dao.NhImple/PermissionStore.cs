using System;
using System.Collections.Generic;

using Ornament.Identity.Stores;
using Ornament.Stores;
using Ornament.Uow;


namespace Ornament.Identity.Dao.NhImple
{
    public class PermissionStore<TUser, TKey, TRole>
        : NhStore<Permission<TRole>, int, NhUow>
            , IUserPermissionStore<TUser, TKey, TRole>

        where TUser : IdentityUser<TKey, TRole>
        where TKey : IEquatable<TKey>
        where TRole : IdentityRole<TKey>


    {
        public PermissionStore(NhUow context) : base(context)
        {
        }


        public IList<Permission<TRole>> GetByUser(TUser user)
        {
            throw new NotImplementedException();
        }



        public IList<Permission<TRole>> GetPermissionsByUser(TUser user, string resourceName)
        {
            throw new NotImplementedException();
        }

      
    }
}