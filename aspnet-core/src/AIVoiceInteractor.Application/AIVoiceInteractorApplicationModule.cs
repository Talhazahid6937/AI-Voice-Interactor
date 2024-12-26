using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using AIVoiceInteractor.Authorization;

namespace AIVoiceInteractor;

[DependsOn(
    typeof(AIVoiceInteractorCoreModule),
    typeof(AbpAutoMapperModule))]
public class AIVoiceInteractorApplicationModule : AbpModule
{
    public override void PreInitialize()
    {
        Configuration.Authorization.Providers.Add<AIVoiceInteractorAuthorizationProvider>();
    }

    public override void Initialize()
    {
        var thisAssembly = typeof(AIVoiceInteractorApplicationModule).GetAssembly();

        IocManager.RegisterAssemblyByConvention(thisAssembly);

        Configuration.Modules.AbpAutoMapper().Configurators.Add(
            // Scan the assembly for classes which inherit from AutoMapper.Profile
            cfg => cfg.AddMaps(thisAssembly)
        );
    }
}
