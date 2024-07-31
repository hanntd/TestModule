using TestModule.Localization;
using Volo.Abp.Application.Services;

namespace TestModule;

public abstract class TestModuleAppService : ApplicationService
{
    protected TestModuleAppService()
    {
        LocalizationResource = typeof(TestModuleResource);
        ObjectMapperContext = typeof(TestModuleApplicationModule);
    }
}
