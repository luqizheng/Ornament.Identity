using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using Ornament.Uow;

namespace Ornament.Identity.Dao.NhImple
{
    public class IdentityNhUow:NhUow
    {
        public IdentityNhUow(ISessionFactory sessionFactory, bool useTransaction = false) : base(sessionFactory, useTransaction)
        {
        }
    }
}
