namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;

    public class PartnersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Partners.Any())
            {
                return;
            }

            var partners = new Partner[]
            {
                    // 1. Phone Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "AFR231",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Laidlaw Close",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "EWO123",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Francis Wayne",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "SDF231",
                        CategoryId = 1,
                        CityId = 1,
                        DriverName = "Rosehill Crescent",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 2. Escaner Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "WFG232",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Pintail Moreno",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "ASD231",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Ellesmere Gardens",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "ASD234",
                        CategoryId = 2,
                        CityId = 1,
                        DriverName = "Sykes Avenue",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 3. Dev Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "ADF534",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Swinton Road",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "ASD231",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Sunnydale Benito",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "SWF687",
                        CategoryId = 3,
                        CityId = 1,
                        DriverName = "Penny Roadhes",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 4. TV Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "YUI098",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Greenview Driver",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "CBN456",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Stratford Crescent",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "YUO487",
                        CategoryId = 4,
                        CityId = 1,
                        DriverName = "Malet Cloban",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 5. Tablets Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "JKL756",
                        CategoryId = 5,
                        CityId = 1,
                        DriverName = "Abbotsbury Warner",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "UIP453",
                        CategoryId = 5,
                        CityId = 1,
                        DriverName = "Abbotsbury Lulu",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Placa = "BNM564",
                        CategoryId = 5,
                        CityId = 1,
                        DriverName = "Anibal Cortes",
                        DriverContact = "3188401247",
                        ImageUrl = GlobalConstants.Images.DemoImg,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                };

            await dbContext.AddRangeAsync(partners);
        }
    }
}
