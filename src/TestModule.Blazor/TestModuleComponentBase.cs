using TestModule.Localization;
using Volo.Abp.AspNetCore.Components;

namespace TestModule.Blazor;

public abstract class TestModuleComponentBase : AbpComponentBase
{
    protected TestModuleComponentBase()
    {
        LocalizationResource = typeof(TestModuleResource);
    }
}
