using System.Collections.Generic;

namespace Ornament.Identity.Resources
{
    public class PermissionResourceManager
    {
        private IDictionary<string, IPermissionResourceProvider> _resources;

        public PermissionResourceManager()
        {
            _resources = new Dictionary<string, IPermissionResourceProvider>();

        }

        public void Add(IPermissionResourceProvider provider)
        {
            _resources.Add(provider.Name, provider);
        }

        public IPermissionResourceProvider Get(string name)
        {
            return _resources[name];
        }


    }
}