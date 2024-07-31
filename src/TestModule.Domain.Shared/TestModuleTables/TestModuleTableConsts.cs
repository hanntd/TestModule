namespace TestModule.TestModuleTables
{
    public static class TestModuleTableConsts
    {
        private const string DefaultSorting = "{0}Code asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TestModuleTable." : string.Empty);
        }

    }
}