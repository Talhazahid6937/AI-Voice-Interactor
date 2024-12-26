using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AIVoiceInteractor.Configuration;
using AIVoiceInteractor.EntityFrameworkCore;
using AIVoiceInteractor.Migrator.DependencyInjection;
using Castle.MicroKernel.Registration;
using Microsoft.Extensions.Configuration;

namespace AIVoiceInteractor.Migrator;

[DependsOn(typeof(AIVoiceInteractorEntityFrameworkModule))]
public class AIVoiceInteractorMigratorModule : AbpModule
{
    private readonly IConfigurationRoot _appConfiguration;

    public AIVoiceInteractorMigratorModule(AIVoiceInteractorEntityFrameworkModule abpProjectNameEntityFrameworkModule)
    {
        abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

        _appConfiguration = AppConfigurations.Get(
            typeof(AIVoiceInteractorMigratorModule).GetAssembly().GetDirectoryPathOrNull()
        );
    }

    public override void PreInitialize()
    {
        Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
            AIVoiceInteractorConsts.ConnectionStringName
        );

        Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        Configuration.ReplaceService(
            typeof(IEventBus),
            () => IocManager.IocContainer.Register(
                Component.For<IEventBus>().Instance(NullEventBus.Instance)
            )
        );
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(AIVoiceInteractorMigratorModule).GetAssembly());
        ServiceCollectionRegistrar.Register(IocManager);
    }
}
