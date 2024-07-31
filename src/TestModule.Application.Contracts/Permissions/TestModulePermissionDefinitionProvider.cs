using TestModule.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TestModule.Permissions;

public class TestModulePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(TestModulePermissions.GroupName, L("Permission:TestModule"));

        var testModuleTablePermission = myGroup.AddPermission(TestModulePermissions.TestModuleTables.Default, L("Permission:TestModuleTables"));
        testModuleTablePermission.AddChild(TestModulePermissions.TestModuleTables.Create, L("Permission:Create"));
        testModuleTablePermission.AddChild(TestModulePermissions.TestModuleTables.Edit, L("Permission:Edit"));
        testModuleTablePermission.AddChild(TestModulePermissions.TestModuleTables.Delete, L("Permission:Delete"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<TestModuleResource>(name);
    }
}