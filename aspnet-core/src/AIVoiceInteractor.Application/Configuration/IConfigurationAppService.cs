using AIVoiceInteractor.Configuration.Dto;
using System.Threading.Tasks;

namespace AIVoiceInteractor.Configuration;

public interface IConfigurationAppService
{
    Task ChangeUiTheme(ChangeUiThemeInput input);
}
