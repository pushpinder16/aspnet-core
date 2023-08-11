using BoilerPlate.Debugging;

namespace BoilerPlate
{
    public class BoilerPlateConsts
    {
        public const string LocalizationSourceName = "BoilerPlate";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "54f6dbad4a9146d4a2946a322d81e307";
    }
}
