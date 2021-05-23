namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;

    public class PartnerServicesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.PartnerServices.Any())
            {
                return;
            }

            var partnerServices = new List<PartnerService>();

            // For each Partner add all Services from its Category
            foreach (var partner in dbContext.Partners.ToArray())
            {
                var partnerId = partner.Id;
                var categoryId = partner.CategoryId;

                foreach (var service in dbContext.Services.Where(x => x.CategoryId == categoryId).ToArray())
                {
                    var serviceId = service.Id;

                    partnerServices.Add(new PartnerService
                    {
                        PartnerId = partnerId,
                        ServiceId = serviceId,
                        Available = true,
                    });
                }
            }

            await dbContext.AddRangeAsync(partnerServices);
        }
    }
}
