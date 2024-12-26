using Abp.Authorization;
using Abp.Runtime.Session;
using AIVoiceInteractor.Configuration.Dto;
using System.Threading.Tasks;

namespace AIVoiceInteractor.Configuration;

[AbpAuthorize]
public class ConfigurationAppService : AIVoiceInteractorAppServiceBase, IConfigurationAppService
{
    public async Task ChangeUiTheme(ChangeUiThemeInput input)
    {
        await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
    }
}
