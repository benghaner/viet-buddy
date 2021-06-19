using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace VietBuddy.Sandbox
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Startup
                .CreateHostBuilder(args)
                .Build();

            await host.Services
                .GetService<Mongo>()
                .RunAsync();
        }
    }
}
