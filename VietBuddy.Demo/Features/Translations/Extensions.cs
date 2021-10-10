using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using VietBuddy.Shared.Features.Translations;

namespace VietBuddy.Demo.Features.Translations
{
    public static class Extensions
    {
        public static async Task LoadSampleTranslations(this WebAssemblyHost host)
        {
            var http = host.Services.GetRequiredService<HttpClient>();
            var repo = host.Services.GetRequiredService<ITranslationRepository>();

            var translations = await http.GetFromJsonAsync<List<Translation>>("sample-data/translations.json");
            foreach (var item in translations)
                await repo.AddAsync(item);
        }
    }
}
