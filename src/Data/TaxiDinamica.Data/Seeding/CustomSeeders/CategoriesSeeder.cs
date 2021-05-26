namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new Category[]
                {
                    new Category // Id = 1
                    {
                        Name = "Transporte",
                        Description = "Servicio de transporte público."
                    },
                    new Category // Id = 2
                    {
                        Name = "Transporte con maletera",
                        Description = "Transporte de pasajeros con equipamento."
                    },
                    new Category // Id = 3
                    {
                        Name = "Encomiendas locales",
                        Description = "Envía y recibe encargos locales."
                    },
                    new Category // Id = 4
                    {
                        Name = "Expreso",
                        Description = "Transporte Intermunicipal."
                    }
                };

            // Need them in particular order
            foreach (var category in categories)
            {
                await dbContext.AddAsync(category);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
