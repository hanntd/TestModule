using Localization.Resources.AbpUi;
using TestModule.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace TestModule;

[DependsOn(
    typeof(TestModuleApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class TestModuleHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(TestModuleHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<TestModuleResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
