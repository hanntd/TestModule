using Volo.Abp.Reflection;

namespace TestModule.Permissions;

public class TestModulePermissions
{
    public const string GroupName = "TestModule";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(TestModulePermissions));
    }

    public static class TestModuleTables
    {
        public const string Default = GroupName + ".TestModuleTables";
        public const string Edit = Default + ".Edit";
        public const string Create = Default + ".Create";
        public const string Delete = Default + ".Delete";
    }
}