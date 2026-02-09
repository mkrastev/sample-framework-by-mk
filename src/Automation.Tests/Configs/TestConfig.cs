// This class is responsible for reading the configuration from the appsettings.json file and 
// providing it to the tests. 
// This allows us to easily change the configuration without having to modify the code, 
// and also allows us to keep sensitive information such as URLs and credentials out of the codebase.

// using Microsoft.Extensions.Configuration;
// public static class TestConfig
// {
//     public static string HomepageUrl { get; } =
//         new ConfigurationBuilder()
//             .AddJsonFile("appsettings.json")
//             .Build()["HomepageUrl"];
// }

using System.IO;
using Microsoft.Extensions.Configuration;

namespace Automation
{
    public static class TestConfig
    {
        public static IConfigurationRoot Configuration { get; private set; }

        public static void Init()
        {
            if (Configuration != null) return;

            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        // Returns Urls:{name} from appsettings (e.g. GetUrl("Base") or GetUrl("Another"))
        public static string GetUrl(string name) => Configuration[$"Urls:{name}"];

        // Generic getter for other keys
        public static string Get(string key) => Configuration[key];

        // Convenience default
        public static string DefaultHomepage => GetUrl("Base") ?? Get("HomepageUrl");
        public static string WaitlistUrl => GetUrl("Waitlist") ?? Get("WaitlistUrl");
    }
}