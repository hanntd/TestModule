using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace TestModule.Seed;

public class TestModuleHttpApiHostDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly TestModuleSampleDataSeeder _testModuleSampleDataSeeder;
    private readonly ICurrentTenant _currentTenant;

    public TestModuleHttpApiHostDataSeedContributor(
        TestModuleSampleDataSeeder testModuleSampleDataSeeder,
        ICurrentTenant currentTenant)
    {
        _testModuleSampleDataSeeder = testModuleSampleDataSeeder;
        _currentTenant = currentTenant;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await _testModuleSampleDataSeeder.SeedAsync(context!);
        }
    }
}
