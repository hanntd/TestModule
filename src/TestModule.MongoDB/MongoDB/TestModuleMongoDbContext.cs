using TestModule.TestModuleTables;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace TestModule.MongoDB;

[ConnectionStringName(TestModuleDbProperties.ConnectionStringName)]
public class TestModuleMongoDbContext : AbpMongoDbContext, ITestModuleMongoDbContext
{
    public IMongoCollection<TestModuleTable> TestModuleTables => Collection<TestModuleTable>();
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        modelBuilder.ConfigureTestModule();

        modelBuilder.Entity<TestModuleTable>(b => { b.CollectionName = TestModuleDbProperties.DbTablePrefix + "TestModuleTables"; });
    }
}