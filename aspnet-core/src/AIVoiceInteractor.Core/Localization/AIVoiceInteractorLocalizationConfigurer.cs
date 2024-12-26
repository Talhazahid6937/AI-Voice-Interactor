using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace AIVoiceInteractor.Localization;

public static class AIVoiceInteractorLocalizationConfigurer
{
    public static void Configure(ILocalizationConfiguration localizationConfiguration)
    {
        localizationConfiguration.Sources.Add(
            new DictionaryBasedLocalizationSource(AIVoiceInteractorConsts.LocalizationSourceName,
                new XmlEmbeddedFileLocalizationDictionaryProvider(
                    typeof(AIVoiceInteractorLocalizationConfigurer).GetAssembly(),
                    "AIVoiceInteractor.Localization.SourceFiles"
                )
            )
        );
    }
}
