using TestModule.Permissions;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using TestModule.Localization;
using Volo.Abp.Authorization.Permissions;

namespace TestModule.Web.Menus;

public class TestModuleMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name != StandardMenus.Main)
        {
            return;
        }

        var moduleMenu = AddModuleMenuItem(context); //Do not delete `moduleMenu` variable as it will be used by ABP Suite!

        AddMenuItemTestModuleTables(context, moduleMenu);
    }

    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var l = context.GetLocalizer<TestModuleResource>();

        var moduleMenu = new ApplicationMenuItem(
            TestModuleMenus.Prefix,
            displayName: l["Menu:TestModule"],
            "~/TestModule",
            icon: "fa fa-globe");

        //Add main menu items.
        context.Menu.Items.AddIfNotContains(moduleMenu);
        return moduleMenu;
    }
    private static void AddMenuItemTestModuleTables(MenuConfigurationContext context, ApplicationMenuItem parentMenu)
    {
        parentMenu.AddItem(
            new ApplicationMenuItem(
                Menus.TestModuleMenus.TestModuleTables,
                context.GetLocalizer<TestModuleResource>()["Menu:TestModuleTables"],
                "/TestModule/TestModuleTables",
                icon: "fa fa-file-alt",
                requiredPermissionName: TestModulePermissions.TestModuleTables.Default
            )
        );
    }
}