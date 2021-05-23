namespace TaxiDinamica.Services.Data.Tests.UseInMemoryDatabase
{
    using System;

    using TaxiDinamica.Data;
    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Repositories;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Cities;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Services;
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
