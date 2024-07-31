using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace TestModule.Seed;

public class TestModuleUnifiedDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly TestModuleSampleIdentityDataSeeder _sampleIdentityDataSeeder;
    private readonly TestModuleSampleDataSeeder _testModuleSampleDataSeeder;
    private readonly IUnitOfWorkManager _unitOfWorkManager;
    private readonly ICurrentTenant _currentTenant;

    public TestModuleUnifiedDataSeedContributor(
        TestModuleSampleIdentityDataSeeder sampleIdentityDataSeeder,
        IUnitOfWorkManager unitOfWorkManager,
        TestModuleSampleDataSeeder testModuleSampleDataSeeder,
        ICurrentTenant currentTenant)
    {
        _sampleIdentityDataSeeder = sampleIdentityDataSeeder;
        _unitOfWorkManager = unitOfWorkManager;
        _testModuleSampleDataSeeder = testModuleSampleDataSeeder;
        _currentTenant = currentTenant;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        await _unitOfWorkManager.Current!.SaveChangesAsync();

        using (_currentTenant.Change(context.TenantId))
        {
            await _sampleIdentityDataSeeder.SeedAsync(context);
            await _unitOfWorkManager.Current.SaveChangesAsync();
            await _testModuleSampleDataSeeder.SeedAsync(context);
        }
    }
}
