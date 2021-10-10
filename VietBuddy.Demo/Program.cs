using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VietBuddy.Shared.Features.Translations;
using VietBuddy.Demo.Features.Translations;
using Blazored.Modal;
using VietBuddy.Shared.Settings;

namespace VietBuddy.Demo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredModal();
            builder.Services.Configure<ClientOptions>(builder.Configuration.GetSection("ClientOptions"));
            builder.Services.AddScoped<ITranslationRepository, TranslationRepository>();
            var host = builder.Build();

            await host.LoadSampleTranslations();
            await host.RunAsync();
        }
    }
}
