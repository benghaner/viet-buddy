using System;
using Microsoft.Extensions.Configuration;

namespace VietBuddy.Shared.Settings
{
    public class AppSettings
    {
        public IConfiguration Configuration { get; }
        public NavMenuOptions NavMenu { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
            NavMenu = Configuration.GetSection("NavMenu").Get<NavMenuOptions>();
        }
    }
}
