using Abp.Application.Services;
using AIVoiceInteractor.MultiTenancy.Dto;

namespace AIVoiceInteractor.MultiTenancy;

public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
{
}

