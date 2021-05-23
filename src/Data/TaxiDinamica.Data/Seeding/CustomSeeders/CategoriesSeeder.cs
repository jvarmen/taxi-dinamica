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
                        Name = "Celulares",
                        Description = "De todas las marcas"
                    },
                    new Category // Id = 2
                    {
                        Name = "Impresoras 3D",
                        Description = "Diseño e impresión de modelos tridimensionales"
                    },
                    new Category // Id = 3
                    {
                        Name = "Asesoría",
                        Description = "Consultas sobre la industria"
                    },
                    new Category // Id = 4
                    {
                        Name = "Televisores",
                        Description = "Reparación y venta de pantallas"
                    },
                    new Category // Id = 5
                    {
                        Name = "Tablets",
                        Description = "Reparación y venta de tablets"
                    },
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
