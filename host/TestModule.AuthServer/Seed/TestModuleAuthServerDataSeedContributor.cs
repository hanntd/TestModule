using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace TestModule.Seed;

public class TestModuleAuthServerDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly TestModuleSampleIdentityDataSeeder _testModuleSampleIdentityDataSeeder;
    private readonly TestModuleAuthServerDataSeeder _testModuleAuthServerDataSeeder;
    private readonly ICurrentTenant _currentTenant;

    public TestModuleAuthServerDataSeedContributor(
        TestModuleAuthServerDataSeeder testModuleAuthServerDataSeeder,
        TestModuleSampleIdentityDataSeeder testModuleSampleIdentityDataSeeder,
        ICurrentTenant currentTenant)
    {
        _testModuleAuthServerDataSeeder = testModuleAuthServerDataSeeder;
        _testModuleSampleIdentityDataSeeder = testModuleSampleIdentityDataSeeder;
        _currentTenant = currentTenant;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        using (_currentTenant.Change(context?.TenantId))
        {
            await _testModuleSampleIdentityDataSeeder.SeedAsync(context!);
            await _testModuleAuthServerDataSeeder.SeedAsync(context!);
        }
    }
}
