using AIVoiceInteractor.Debugging;

namespace AIVoiceInteractor;

public class AIVoiceInteractorConsts
{
    public const string LocalizationSourceName = "AIVoiceInteractor";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = false;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ae9b875b0fff4c60a9b50c7a7f6a18b2";
}
