namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;

    public class ServicesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Services.Any())
            {
                return;
            }

            var services = new Service[]
                {
                    new Service
                    {
                        Name = "Recoger pasajeros y Transportar",
                        Description = "",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Recoger caja y Transportar",
                        Description = "",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Transporte con carga pesada",
                        Description = "",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Pasajeros con maletas",
                        Description = "",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Recoger pasajeros y Transportar",
                        Description = "",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Recoger caja y Transportar",
                        Description = "",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Transporte con carga pesada",
                        Description = "",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Pasajeros con maletas",
                        Description = "",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Recoger pasajeros y Transportar",
                        Description = "",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Recoger caja y Transportar",
                        Description = "",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Transporte con carga pesada",
                        Description = "",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Pasajeros con maletas",
                        Description = "",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Recoger pasajeros y Transportar",
                        Description = "",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Recoger caja y Transportar",
                        Description = "",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Transporte con carga pesada",
                        Description = "",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Pasajeros con maletas",
                        Description = "",
                        CategoryId = 4,
                    }
                };

            // Need them in particular order
            foreach (var service in services)
            {
                await dbContext.AddAsync(service);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
