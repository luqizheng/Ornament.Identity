using System;
using Ornament.Identity.Resources;
using Ornament.Identity.Stores;

namespace Ornament.Identity
{
    public class PermissionManager<TUser, TKey, TRole, TPermission>
        where TUser : IdentityUser<TKey, TRole>
        where TKey : IEquatable<TKey>
        where TRole : IdentityRole<TKey>
        where TPermission : Permission<TRole>


    {
        private readonly PermissionResourceManager _manager;
        private readonly IUserPermissionStore<TUser, TKey, TRole> _store;


        public PermissionManager(PermissionResourceManager manager,
            IUserPermissionStore<TUser, TKey, TRole> store)
        {
            _manager = manager;
            _store = store;
        }

        public bool HasPermission<TRes>(TUser user, Enum enumOperator)
        {
            var resName = typeof(TRes).Name;
            var permissions = _store.GetPermissionsByUser(user, resName);
            foreach (var permission in permissions)
                if (permission.Verify(Convert.ToInt32(enumOperator)))
                    return true;
            return false;
        }

        public void SetPermission<TRes>(TRes res, Enum enumOperator, TPermission r)
        {
        }
    }
}