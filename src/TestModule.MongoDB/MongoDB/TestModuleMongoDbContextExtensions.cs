using Volo.Abp;
using Volo.Abp.MongoDB;

namespace TestModule.MongoDB;

public static class TestModuleMongoDbContextExtensions
{
    public static void ConfigureTestModule(
        this IMongoModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));
    }
}
