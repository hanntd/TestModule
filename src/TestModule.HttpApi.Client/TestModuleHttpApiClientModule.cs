using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace TestModule;

[DependsOn(
    typeof(TestModuleApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class TestModuleHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(TestModuleApplicationContractsModule).Assembly,
            TestModuleRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<TestModuleHttpApiClientModule>();
        });
    }
}
