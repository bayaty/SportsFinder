using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(SportsFinder.Areas.Identity.IdentityHostingStartup))]

namespace SportsFinder.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}