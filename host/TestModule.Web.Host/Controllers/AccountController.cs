using Volo.Abp.Account.Public.Web.Impersonation;
using Volo.Abp.AspNetCore.Mvc.Authentication;

namespace TestModule.Controllers;

public class AccountController : AbpAccountImpersonationChallengeAccountController
{

}
