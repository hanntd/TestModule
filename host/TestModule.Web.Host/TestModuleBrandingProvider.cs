using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace TestModule;

[Dependency(ReplaceServices = true)]
public class TestModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TestModule";
}
