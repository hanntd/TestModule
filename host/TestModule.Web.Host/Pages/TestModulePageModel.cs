using TestModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TestModule.Pages;

public abstract class TestModulePageModel : AbpPageModel
{
    protected TestModulePageModel()
    {
        LocalizationResourceType = typeof(TestModuleResource);
    }
}
