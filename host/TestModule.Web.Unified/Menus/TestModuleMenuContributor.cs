using System.Threading.Tasks;
using TestModule.Web.Menus;
using Volo.Abp.AuditLogging.Web.Navigation;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;
using Volo.Saas.Host.Navigation;

namespace TestModule.Menus;

public class TestModuleMenuContributor : IMenuContributor
{
    public Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.User)
        {
            return Task.CompletedTask;
        }

        context.Menu.SetSubItemOrder(TestModuleMenus.Prefix, 1);

        //Administration
        var administration = context.Menu.GetAdministration();
        administration.Order = 2;

        //Administration -> Identity
        administration.SetSubItemOrder(IdentityMenuNames.GroupName, 1);

        //Administration -> Saas
        administration.SetSubItemOrder(SaasHostMenuNames.GroupName, 2);

        //Administration -> Audit Logs
        administration.SetSubItemOrder(AbpAuditLoggingMainMenuNames.GroupName, 3);

        //Administration -> Settings
        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 4);

        return Task.CompletedTask;
    }
}
