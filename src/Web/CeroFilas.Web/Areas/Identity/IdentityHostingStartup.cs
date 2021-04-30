using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CeroFilas.Web.Areas.Identity.IdentityHostingStartup))]
namespace CeroFilas.Web.Areas.Identity
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
