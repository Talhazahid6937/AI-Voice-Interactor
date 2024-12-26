using Abp.Application.Services;
using AIVoiceInteractor.Authorization.Accounts.Dto;
using System.Threading.Tasks;

namespace AIVoiceInteractor.Authorization.Accounts;

public interface IAccountAppService : IApplicationService
{
    Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

    Task<RegisterOutput> Register(RegisterInput input);
}
