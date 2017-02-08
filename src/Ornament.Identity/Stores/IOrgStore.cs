using System.Collections.Generic;
using Ornament.Stores;

namespace Ornament.Identity.Stores
{
    public interface IOrgStore : IStore<Org, int>
    {
        IEnumerable<Org> GetOrgs(Org parentOrg);


        void Save(Org org);

    }
}