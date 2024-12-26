using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace AIVoiceInteractor.Controllers
{
    public abstract class AIVoiceInteractorControllerBase : AbpController
    {
        protected AIVoiceInteractorControllerBase()
        {
            LocalizationSourceName = AIVoiceInteractorConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
