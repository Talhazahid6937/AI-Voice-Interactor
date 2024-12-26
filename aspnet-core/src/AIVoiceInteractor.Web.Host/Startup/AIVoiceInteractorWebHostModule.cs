using Abp.Modules;
using Abp.Reflection.Extensions;
using AIVoiceInteractor.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AIVoiceInteractor.Web.Host.Startup
{
    [DependsOn(
       typeof(AIVoiceInteractorWebCoreModule))]
    public class AIVoiceInteractorWebHostModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public AIVoiceInteractorWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(AIVoiceInteractorWebHostModule).GetAssembly());
        }
    }
}
