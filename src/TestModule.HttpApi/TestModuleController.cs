using TestModule.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TestModule;

public abstract class TestModuleController : AbpControllerBase
{
    protected TestModuleController()
    {
        LocalizationResource = typeof(TestModuleResource);
    }
}
