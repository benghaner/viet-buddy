using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using VietBuddy.Shared.Features.Translations;
using VietBuddy.Demo.Features.Translations;
using Blazored.Modal;
using System.Net.Http.Json;

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
            builder.Services.AddScoped<ITranslationRepository, TranslationRepository>();
            var host = builder.Build();

            await LoadSampleData(host);
            await host.RunAsync();
        }

        public static async Task LoadSampleData(WebAssemblyHost host)
        {
            var http = host.Services.GetRequiredService<HttpClient>();
            var repo = host.Services.GetRequiredService<ITranslationRepository>();

            var translations = await http.GetFromJsonAsync<List<Translation>>("sample-data/translations.json");
            foreach (var item in translations)
                await repo.AddAsync(item);
        }
    }
}
