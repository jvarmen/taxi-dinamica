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
                        Name = "Reparación",
                        Description = "Servicio de reparación.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Consulta",
                        Description = "Servicio de Consulta.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Asesoría",
                        Description = "Servicio de Asesoría.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Compra",
                        Description = "Servicio de Compra.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Venta",
                        Description = "Servicio de Venta.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Cambio",
                        Description = "Servicio de Cambio.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Cotización",
                        Description = "Servicio de Cotización.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Solicitud",
                        Description = "Servicio de Solicitud.",
                        CategoryId = 1,
                    },
                    new Service
                    {
                        Name = "Reparación",
                        Description = "Servicio de reparación.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Consulta",
                        Description = "Servicio de Consulta.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Asesoría",
                        Description = "Servicio de Asesoría.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Compra",
                        Description = "Servicio de Compra.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Venta",
                        Description = "Servicio de Venta.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Cambio",
                        Description = "Servicio de Cambio.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Cotización",
                        Description = "Servicio de Cotización.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Solicitud",
                        Description = "Servicio de Solicitud.",
                        CategoryId = 2,
                    },
                    new Service
                    {
                        Name = "Reparación",
                        Description = "Servicio de reparación.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Consulta",
                        Description = "Servicio de Consulta.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Asesoría",
                        Description = "Servicio de Asesoría.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Compra",
                        Description = "Servicio de Compra.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Venta",
                        Description = "Servicio de Venta.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Cambio",
                        Description = "Servicio de Cambio.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Cotización",
                        Description = "Servicio de Cotización.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Solicitud",
                        Description = "Servicio de Solicitud.",
                        CategoryId = 3,
                    },
                    new Service
                    {
                        Name = "Reparación",
                        Description = "Servicio de reparación.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Consulta",
                        Description = "Servicio de Consulta.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Asesoría",
                        Description = "Servicio de Asesoría.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Compra",
                        Description = "Servicio de Compra.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Venta",
                        Description = "Servicio de Venta.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Cambio",
                        Description = "Servicio de Cambio.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Cotización",
                        Description = "Servicio de Cotización.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Solicitud",
                        Description = "Servicio de Solicitud.",
                        CategoryId = 4,
                    },
                    new Service
                    {
                        Name = "Reparación",
                        Description = "Servicio de reparación.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Consulta",
                        Description = "Servicio de Consulta.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Asesoría",
                        Description = "Servicio de Asesoría.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Compra",
                        Description = "Servicio de Compra.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Venta",
                        Description = "Servicio de Venta.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Cambio",
                        Description = "Servicio de Cambio.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Cotización",
                        Description = "Servicio de Cotización.",
                        CategoryId = 5,
                    },
                    new Service
                    {
                        Name = "Solicitud",
                        Description = "Servicio de Solicitud.",
                        CategoryId = 5,
                    },
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
