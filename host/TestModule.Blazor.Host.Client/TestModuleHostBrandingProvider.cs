using Volo.Abp.Ui.Branding;

namespace TestModule.Blazor.Host.Client;

public class TestModuleHostBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "TestModule";
}
