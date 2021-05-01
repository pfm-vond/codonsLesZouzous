using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace LeanFeatureFlag.ConsoleApp
{
    public record Config();

    public class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration cfg = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddJsonFile("settings.json")
                .AddEnvironmentVariables()
                .Build();

            cfg.GetSection("Config").Get<Config>();

            await Task.CompletedTask;
        }
    }
}
