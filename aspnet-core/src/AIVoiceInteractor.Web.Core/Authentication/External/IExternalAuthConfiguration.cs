using System.Collections.Generic;

namespace AIVoiceInteractor.Authentication.External
{
    public interface IExternalAuthConfiguration
    {
        List<ExternalLoginProviderInfo> Providers { get; }
    }
}
