using NHibernate;
using Ornament.Uow;

namespace Ornament.Identity.Dao.NhImple
{
    public class IdentityNhUow : NhUow
    {
        public IdentityNhUow(ISessionFactory sessionFactory, bool useTransaction = false)
            : base(sessionFactory, useTransaction)
        {
        }
    }
}