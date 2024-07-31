using Volo.Abp.AspNetCore.Components.WebAssembly.Theming;
using Volo.Abp.Modularity;

namespace TestModule.Blazor.WebAssembly;

[DependsOn(
    typeof(TestModuleBlazorModule),
    typeof(TestModuleHttpApiClientModule),
    typeof(AbpAspNetCoreComponentsWebAssemblyThemingModule)
)]
public class TestModuleBlazorWebAssemblyModule : AbpModule
{

}
