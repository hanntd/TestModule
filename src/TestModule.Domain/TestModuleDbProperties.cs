namespace TestModule;

public static class TestModuleDbProperties
{
    public static string DbTablePrefix { get; set; } = "TestModule";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "TestModule";
}
