using TestModule.TestModuleTables;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace TestModule.MongoDB;

[ConnectionStringName(TestModuleDbProperties.ConnectionStringName)]
public interface ITestModuleMongoDbContext : IAbpMongoDbContext
{
    IMongoCollection<TestModuleTable> TestModuleTables { get; }
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}