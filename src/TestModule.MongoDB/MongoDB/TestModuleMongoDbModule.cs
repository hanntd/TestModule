using TestModule.TestModuleTables;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace TestModule.MongoDB;

[DependsOn(
    typeof(TestModuleDomainModule),
    typeof(AbpMongoDbModule)
    )]
public class TestModuleMongoDbModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddMongoDbContext<TestModuleMongoDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, MongoQuestionRepository>();
             */
            options.AddRepository<TestModuleTable, TestModuleTables.MongoTestModuleTableRepository>();

        });
    }
}