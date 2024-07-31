using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace TestModule.Pages;

public class IndexModel : TestModulePageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
