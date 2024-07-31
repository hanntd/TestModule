using Volo.Abp.Caching;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace TestModule;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(TestModuleDomainSharedModule)
)]
public class TestModuleDomainModule : AbpModule
{

}
