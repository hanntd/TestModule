using Volo.Abp.Modularity;

namespace TestModule;

[DependsOn(
    typeof(TestModuleApplicationModule),
    typeof(TestModuleDomainTestModule)
    )]
public class TestModuleApplicationTestModule : AbpModule
{

}
