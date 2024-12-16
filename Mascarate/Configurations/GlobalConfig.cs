using System;

namespace Mascarate.Configurations
{
    public static class GlobalConfig
    {
        public static bool ShouldIgnore { get; private set; }
        
        public static void Configure(Action<GlobalConfigOptions> configure)
        {
            var options = new GlobalConfigOptions
            {
                ShouldIgnore = ShouldIgnore
            };

            configure(options);

            ShouldIgnore = options.ShouldIgnore;
        }
    }
}