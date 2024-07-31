using Volo.Abp.Modularity;

namespace TestModule;

[DependsOn(
    typeof(TestModuleDomainModule),
    typeof(TestModuleTestBaseModule)
)]
public class TestModuleDomainTestModule : AbpModule
{

}
