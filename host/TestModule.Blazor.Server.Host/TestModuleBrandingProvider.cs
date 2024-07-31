using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TestModule.Blazor.Server.Host;

[Dependency(ReplaceServices = true)]
public class TestModuleBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TestModule";
}
