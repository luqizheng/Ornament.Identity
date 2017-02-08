using System.Collections.Generic;
using NHibernate.Criterion;
using Ornament.Identity.Stores;
using Ornament.Stores;

namespace Ornament.Identity.Dao.NhImple
{
    public class OrgStore : NhStore<Org, int, IdentityNhUow>, IOrgStore
    {
        public OrgStore(IdentityNhUow context) : base(context)
        {
        }

        protected IProjection NameProperty
        {
            get { return Projections.Property<Org>(s => s.Name); }
        }

        protected IProjection RemarkProperty
        {
            get { return Projections.Property<Org>(s => s.Remark); }
        }

        protected IProjection ParentProperty
        {
            get { return Projections.Property<Org>(s => s.Parent); }
        }

        /// <summary>
        /// </summary>
        /// <param name="parentOrg"></param>
        /// <returns></returns>
        public IEnumerable<Org> GetOrgs(Org parentOrg)
        {
            var criteria = DetachedCriteria.For<Org>()
                .Add(parentOrg == null
                    ? Restrictions.IsNull(ParentProperty)
                    : Restrictions.Eq(ParentProperty, parentOrg));
            return criteria.GetExecutableCriteria(Context).List<Org>();
        }
    }
}