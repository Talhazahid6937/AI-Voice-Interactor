﻿using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using AIVoiceInteractor.EntityFrameworkCore.Seed;

namespace AIVoiceInteractor.EntityFrameworkCore;

[DependsOn(
    typeof(AIVoiceInteractorCoreModule),
    typeof(AbpZeroCoreEntityFrameworkCoreModule))]
public class AIVoiceInteractorEntityFrameworkModule : AbpModule
{
    /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
    public bool SkipDbContextRegistration { get; set; }

    public bool SkipDbSeed { get; set; }

    public override void PreInitialize()
    {
        if (!SkipDbContextRegistration)
        {
            Configuration.Modules.AbpEfCore().AddDbContext<AIVoiceInteractorDbContext>(options =>
            {
                if (options.ExistingConnection != null)
                {
                    AIVoiceInteractorDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                }
                else
                {
                    AIVoiceInteractorDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                }
            });
        }
    }

    public override void Initialize()
    {
        IocManager.RegisterAssemblyByConvention(typeof(AIVoiceInteractorEntityFrameworkModule).GetAssembly());
    }

    public override void PostInitialize()
    {
        if (!SkipDbSeed)
        {
            SeedHelper.SeedHostDb(IocManager);
        }
    }
}
