using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AIVoiceInteractor.EntityFrameworkCore;
using AIVoiceInteractor.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace AIVoiceInteractor.Web.Tests;

[DependsOn(
    typeof(AIVoiceInteractorWebMvcModule),
    typeof(AbpAspNetCoreTestBaseModule)
)]
public class AIVoiceInteractorWebTestModule : AbpModule
{
    public AIVoiceInteractorWebTestModule(AIVoiceInteractorEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
    }

    public override void PreInitialize()
    {
        Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(AIVoiceInteractorWebTestModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        IocManager.Resolve<ApplicationPartManager>()
            .AddApplicationPartsIfNotAddedBefore(typeof(AIVoiceInteractorWebMvcModule).Assembly);
    }
}