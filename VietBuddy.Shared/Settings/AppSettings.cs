using System;
using Microsoft.Extensions.Configuration;

namespace VietBuddy.Shared.Settings
{
    public class AppSettings
    {
        public IConfiguration Configuration { get; }
        public TitleOptions Titles { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
            Titles = Configuration.GetSection("Titles").Get<TitleOptions>();
        }
    }
}
