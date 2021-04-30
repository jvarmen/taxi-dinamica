namespace CeroFilas.Services.Data.Tests.UseInMemoryDatabase
{
    using System;

    using CeroFilas.Data;
    using CeroFilas.Data.Common.Repositories;
    using CeroFilas.Data.Repositories;
    using CeroFilas.Services.Data.Appointments;
    using CeroFilas.Services.Data.BlogPosts;
    using CeroFilas.Services.Data.Categories;
    using CeroFilas.Services.Data.Cities;
    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Services.Data.PartnerServicesServices;
    using CeroFilas.Services.Data.Services;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public abstract class BaseServiceTests : IDisposable
    {
        protected BaseServiceTests()
        {
            var services = this.SetServices();

            this.ServiceProvider = services.BuildServiceProvider();
            this.DbContext = this.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        }

        protected IServiceProvider ServiceProvider { get; set; }

        protected ApplicationDbContext DbContext { get; set; }

        public void Dispose()
        {
            this.DbContext.Database.EnsureDeleted();
            this.SetServices();
        }

        private ServiceCollection SetServices()
        {
            var services = new ServiceCollection();

            services.AddDbContext<ApplicationDbContext>(
                options => options.UseInMemoryDatabase(Guid.NewGuid().ToString()));

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

            // Application services
            services.AddTransient<IBlogPostsService, BlogPostsService>();
            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IServicesService, ServicesService>();
            services.AddTransient<ICitiesService, CitiesService>();
            services.AddTransient<IPartnersService, PartnersService>();
            services.AddTransient<IPartnerServicesService, PartnerServicesService>();
            services.AddTransient<IAppointmentsService, AppointmentsService>();

            return services;
        }
    }
}
