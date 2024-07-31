using Volo.Abp.Modularity;

namespace TestModule;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class TestModuleDomainTestBase<TStartupModule> : TestModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
