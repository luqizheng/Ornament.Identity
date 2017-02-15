# Ornament Identity #
安装package
`install-package Ornament.Identity'

在ConfigureServices(IServiceCollection services)添加

`var identityBuilder = services.AddIdentity<AppUser, AppRole>();`

请参考下面选择nh 作为持久层
## nhibernate identity ##

`install-package Ornament.Uow.NHibernate'
```
  //创建nh的uowFactory
  var uowFactory = services
                .MsSql2008(option =>
                {
                    option.ConnectionString(Configuration.GetConnectionString("default"));
                });
   //add fluent-mapping clas for user and role.
   identityBuilder.AddNhibernateStores<AppUserMapping, AppRoleMapping>(uowFactory);
```
```
 //fluent-mapping
 public class AppUserMapping :
        IdentityUserMapping<AppUser, int, AppRole>
    {
        public AppUserMapping()
        {
            Id(s => s.Id).GeneratedBy.Identity();
        }
    }

    public class AppRoleMapping : IdentityRoleMapping<ApplicationRole, int>
    {
        public AppRoleMapping()
        {
            Id(s => s.Id).GeneratedBy.Identity();
        }
    }
```