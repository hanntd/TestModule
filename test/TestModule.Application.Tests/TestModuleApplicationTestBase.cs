using Volo.Abp.Modularity;

namespace TestModule;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class TestModuleApplicationTestBase<TStartupModule> : TestModuleTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
