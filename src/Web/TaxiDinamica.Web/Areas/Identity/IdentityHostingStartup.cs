using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TaxiDinamica.Web.Areas.Identity.IdentityHostingStartup))]
namespace TaxiDinamica.Web.Areas.Identity
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
