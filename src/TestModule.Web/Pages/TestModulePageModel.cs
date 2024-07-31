using TestModule.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace TestModule.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class TestModulePageModel : AbpPageModel
{
    protected TestModulePageModel()
    {
        LocalizationResourceType = typeof(TestModuleResource);
        ObjectMapperContext = typeof(TestModuleWebModule);
    }
}
