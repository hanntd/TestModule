using TestModule.TestModuleTables;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TestModule.EntityFrameworkCore;

[DependsOn(
    typeof(TestModuleDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class TestModuleEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<TestModuleDbContext>(options =>
        {
            /* Add custom repositories here. Example:
             * options.AddRepository<Question, EfCoreQuestionRepository>();
             */
            options.AddRepository<TestModuleTable, TestModuleTables.EfCoreTestModuleTableRepository>();

        });
    }
}