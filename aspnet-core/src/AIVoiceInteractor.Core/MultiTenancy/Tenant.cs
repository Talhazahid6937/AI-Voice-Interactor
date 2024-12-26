using Abp.MultiTenancy;
using AIVoiceInteractor.Authorization.Users;

namespace AIVoiceInteractor.MultiTenancy;

public class Tenant : AbpTenant<User>
{
    public Tenant()
    {
    }

    public Tenant(string tenancyName, string name)
        : base(tenancyName, name)
    {
    }
}
