using MetroOffice.AuthServer.Domain.Shared;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;

namespace MetroOffice.AuthServer.Domain
{
    [DependsOn(
        typeof(AuthServerDomainSharedModule),
        typeof(AbpIdentityDomainModule),
        typeof(AbpIdentityServerDomainModule)
    )]
    public class AuthServerDomainModule : AbpModule
    {
    }
}
