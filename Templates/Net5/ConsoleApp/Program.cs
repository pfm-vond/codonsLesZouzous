using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public record Config();

    public class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration host = new ConfigurationBuilder()
                .AddCommandLine(args)
                .AddJsonFile("setting.json")
                .AddEnvironmentVariables()
                .Build();

            host.GetSection("Config").Get<Config>();

            await Task.CompletedTask;
        }
    }
}
