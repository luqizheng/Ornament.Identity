using FluentNHibernate.Mapping;

namespace Ornament.Identity.Dao.NhImple.Mapping
{
    public class PermissionMapping<TRole> : ClassMap<Permission<TRole>>
    {
        protected PermissionMapping()
        {
            Table("mbs_permission");
            Id(s => s.Id).GeneratedBy.SequenceIdentity();
            Map(s => s.Remarks);
            Map(s => s.Operator);
            References(s => s.Role).ForeignKey("permission_roleFK");
        }
    }
}