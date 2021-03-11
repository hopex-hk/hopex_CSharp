using Hopex.SDK.Core.Invoker.Models;
using Microsoft.Extensions.Configuration;


namespace Hopex.SDK.Example
{
    public class Config
    {
        public static void LoadConfig()
        {
            // Read configs from 'appsettings.json'
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            InvokerOption.SetConfig(config["Host"], config["ApiKey"], config["ApiSecret"], config["UserAgent"]);
        }
    }
}
