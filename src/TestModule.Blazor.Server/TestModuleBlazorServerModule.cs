using Volo.Abp.AspNetCore.Components.Server.Theming;
using Volo.Abp.Modularity;

namespace TestModule.Blazor.Server;

[DependsOn(
    typeof(TestModuleBlazorModule),
    typeof(AbpAspNetCoreComponentsServerThemingModule)
    )]
public class TestModuleBlazorServerModule : AbpModule
{

}
