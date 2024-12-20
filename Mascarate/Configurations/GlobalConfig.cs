using System;

namespace Mascarate.Configurations
{
    public static class GlobalConfig
    {
        public static bool ShouldThrowFailureExceptions { get; private set; }
        
        public static void Configure(Action<GlobalConfigOptions> configure)
        {
            var options = new GlobalConfigOptions
            {
                ShouldThrowFailureExceptions = ShouldThrowFailureExceptions
            };

            configure(options);

            ShouldThrowFailureExceptions = options.ShouldThrowFailureExceptions;
        }
    }
}