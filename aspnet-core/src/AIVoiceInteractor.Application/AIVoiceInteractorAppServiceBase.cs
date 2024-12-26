using Abp.Application.Services;
using Abp.IdentityFramework;
using Abp.Runtime.Session;
using AIVoiceInteractor.Authorization.Users;
using AIVoiceInteractor.MultiTenancy;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace AIVoiceInteractor;

/// <summary>
/// Derive your application services from this class.
/// </summary>
public abstract class AIVoiceInteractorAppServiceBase : ApplicationService
{
    public TenantManager TenantManager { get; set; }

    public UserManager UserManager { get; set; }

    protected AIVoiceInteractorAppServiceBase()
    {
        LocalizationSourceName = AIVoiceInteractorConsts.LocalizationSourceName;
    }

    protected virtual async Task<User> GetCurrentUserAsync()
    {
        var user = await UserManager.FindByIdAsync(AbpSession.GetUserId().ToString());
        if (user == null)
        {
            throw new Exception("There is no current user!");
        }

        return user;
    }

    protected virtual Task<Tenant> GetCurrentTenantAsync()
    {
        return TenantManager.GetByIdAsync(AbpSession.GetTenantId());
    }

    protected virtual void CheckErrors(IdentityResult identityResult)
    {
        identityResult.CheckErrors(LocalizationManager);
    }
}
