namespace TaxiDinamica.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class PartnerServicesServiceTests : BaseServiceTests
    {
        private IPartnerServicesService Service => this.ServiceProvider.GetRequiredService<IPartnerServicesService>();

        /*
        TODO: Task<T> GetByIdAsync<T>(string PartnerId, int serviceId);
         */

        [Fact]
        public async Task AddAsyncShouldWorkCorrectlyWithOnePartnerAndManyServices()
        {
            var Partner = await this.CreatePartnerAsync();
            var service1 = await this.CreateServiceAsync();
            var service2 = await this.CreateServiceAsync();
            var service3 = await this.CreateServiceAsync();

            var PartnerId = Partner.Id;
            var servicesIds = new List<int> { service1.Id, service2.Id, service3.Id };

            await this.Service.AddAsync(PartnerId, servicesIds);

            var expected = 3;
            var actual = await this.DbContext.PartnerServices.CountAsync();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task AddAsyncShouldWorkCorrectlyWithManyPartnersAndOneService()
        {
            var Partner1 = await this.CreatePartnerAsync();
            var Partner2 = await this.CreatePartnerAsync();
            var Partner3 = await this.CreatePartnerAsync();
            var service = await this.CreateServiceAsync();

            var PartnersIds = new List<string> { Partner1.Id, Partner2.Id, Partner3.Id };
            var serviceId = service.Id;

            await this.Service.AddAsync(PartnersIds, serviceId);

            var expected = 3;
            var actual = await this.DbContext.PartnerServices.CountAsync();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task ChangeAvailableStatusAsyncShouldChangeStatusCorrectly()
        {
            var Partner = await this.CreatePartnerAsync();
            var service = await this.CreateServiceAsync();
            var PartnerService = await this.CreatePartnerServiceAsync(Partner.Id, service.Id);

            await this.Service.ChangeAvailableStatusAsync(Partner.Id, service.Id);

            Assert.True(PartnerService.Available);
        }

        private async Task<Partner> CreatePartnerAsync()
        {
            // Add Partner
            var Partner = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Placa = new NLipsum.Core.Sentence().ToString(),
                CategoryId = 1,
                DriverName = new NLipsum.Core.Sentence().ToString(),
                DriverContact = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
            };

            await this.DbContext.Partners.AddAsync(Partner);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Partner>(Partner).State = EntityState.Detached;

            return Partner;
        }

        private async Task<Service> CreateServiceAsync()
        {
            // Add Service
            var service = new Service
            {
                Name = new NLipsum.Core.Sentence().ToString(),
                Description = new NLipsum.Core.Paragraph().ToString(),
                CategoryId = 1,
            };

            await this.DbContext.Services.AddAsync(service);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Service>(service).State = EntityState.Detached;

            return service;
        }

        private async Task<PartnerService> CreatePartnerServiceAsync(string partnerId, int serviceId)
        {
            // Add PartnerService
            var PartnerService = new PartnerService
            {
                PartnerId = partnerId,
                ServiceId = serviceId,
                Available = true,
            };

            await this.DbContext.PartnerServices.AddAsync(PartnerService);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<PartnerService>(PartnerService).State = EntityState.Detached;

            return PartnerService;
        }
    }
}
