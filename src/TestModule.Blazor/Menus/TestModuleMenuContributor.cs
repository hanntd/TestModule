using TestModule.Permissions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using TestModule.Localization;
using Volo.Abp.UI.Navigation;

namespace TestModule.Blazor.Menus;

public class TestModuleMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }

        var moduleMenu = AddModuleMenuItem(context);
        AddMenuItemTestModuleTables(context, moduleMenu);
    }

    private static async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        //Add main menu items.
        var l = context.GetLocalizer<TestModuleResource>();

        context.Menu.AddItem(new ApplicationMenuItem(
            TestModuleMenus.Prefix,
            displayName: l["Menu:TestModule"],
            "/TestModule",
            icon: "fa fa-globe"));

        await Task.CompletedTask;
    }
    private static ApplicationMenuItem AddModuleMenuItem(MenuConfigurationContext context)
    {
        var moduleMenu = new ApplicationMenuItem(
            TestModuleMenus.Prefix,
            context.GetLocalizer<TestModuleResource>()["Menu:TestModule"],
            icon: "fa fa-folder"
        );

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