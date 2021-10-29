using MetroOffice.AuthServer.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace MetroOffice.AuthServer.EntityFrameworkCore
{
    [DependsOn(
        typeof(AuthServerDomainModule),
        typeof(AbpEntityFrameworkCoreSqlServerModule),
        typeof(AbpIdentityEntityFrameworkCoreModule),
        typeof(AbpIdentityServerEntityFrameworkCoreModule)
    )]
    public class AuthServerEntityFrameworkCoreModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            IdentityServiceEfCoreEntityExtensionMappings.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<IdentityServiceDbContext>(options =>
            {
                options.ReplaceDbContext<IIdentityDbContext>();
                options.ReplaceDbContext<IIdentityServerDbContext>();

                options.AddDefaultRepositories(includeAllEntities: true);
            });

            Configure<AbpDbContextOptions>(options =>
            {
                options.Configure<IdentityServiceDbContext>(c =>
                {
                    c.UseSqlServer();
                });
            });
        }
    }
}
