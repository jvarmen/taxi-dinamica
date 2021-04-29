﻿namespace CeroFilas.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using CeroFilas.Common;
    using CeroFilas.Data.Models;

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
                        Name = "Accent-e-Technology",
                        CategoryId = 1,
                        Address = "Laidlaw Close 28",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Binary Infotech",
                        CategoryId = 1,
                        Address = "Francis Way 198",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Clara Technologies",
                        CategoryId = 1,
                        Address = "Rosehill Crescent 93",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 2. Escaner Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Denis Soft Technologies",
                        CategoryId = 2,
                        Address = "Pintail Close 5",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Dexter Matrix",
                        CategoryId = 2,
                        Address = "Ellesmere Gardens 143",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Digitech Solution",
                        CategoryId = 2,
                        Address = "Sykes Avenue 128",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 3. Dev Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Eicon Technologies",
                        CategoryId = 3,
                        Address = "Swinton Road 158",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "ERP Solutions",
                        CategoryId = 3,
                        Address = "Sunnydale 38",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Future Focus",
                        CategoryId = 3,
                        Address = "Penywern Road 43",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 4. TV Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Nyku Systems",
                        CategoryId = 4,
                        Address = "Greenview Drive 119",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Poineer IT",
                        CategoryId = 4,
                        Address = "Stratford Crescent 15",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Professional Softech",
                        CategoryId = 4,
                        Address = "Malet Close 28",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                    // 5. Tablets Partners
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Tech Wave",
                        CategoryId = 5,
                        Address = "Abbotsbury Way 81",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },
                    new Partner
                    {
                        Id = "seeded" + Guid.NewGuid().ToString(),
                        Name = "Zersa Technologies",
                        CategoryId = 5,
                        Address = "Abbotsbury Way 81",
                        Website = "www.example.cerofilas.com.co",
                        ImageUrl = GlobalConstants.Images.Hair1,
                        Rating = 0.0,
                        RatersCount = 0,
                    },

                };

            await dbContext.AddRangeAsync(partners);
        }
    }
}
