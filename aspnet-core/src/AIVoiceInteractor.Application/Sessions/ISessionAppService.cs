using Abp.Application.Services;
using AIVoiceInteractor.Sessions.Dto;
using System.Threading.Tasks;

namespace AIVoiceInteractor.Sessions;

public interface ISessionAppService : IApplicationService
{
    Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
}
