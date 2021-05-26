namespace TaxiDinamica.Services.Data.Tests.UseInMemoryDatabase
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Partners;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Xunit;

    public class PartnersServiceTests : BaseServiceTests
    {
        private IPartnersService Service => this.ServiceProvider.GetRequiredService<IPartnersService>();

        /*
        TODO: Task<IEnumerable<T>> GetAllAsync<T>();

        TODO: Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        TODO: Task<T> GetByIdAsync<T>(string id);
         */

        [Fact]
        public async Task GetCountForPaginationAsyncShouldReturnCorrectCount()
        {
            await this.CreatePartnerAsync(Guid.NewGuid().ToString());
            await this.CreatePartnerAsync(Guid.NewGuid().ToString());
            await this.CreatePartnerAsync(Guid.NewGuid().ToString());

            var actual = await this.Service.GetCountForPaginationAsync(" ", 0);
            Assert.Equal(0, actual);
        }

        [Fact]
        public async Task GetAllIdsByCategoryAsyncShouldReturnCorrectCount()
        {
            var Partner1 = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Placa = new NLipsum.Core.Sentence().ToString(),
                CategoryId = 5,
                DriverName = new NLipsum.Core.Sentence().ToString(),
                DriverContact = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
            };
            var Partner2 = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Placa = new NLipsum.Core.Sentence().ToString(),
                CategoryId = 5,
                DriverName = new NLipsum.Core.Sentence().ToString(),
                DriverContact = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
            };
            var Partner3 = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Placa = new NLipsum.Core.Sentence().ToString(),
                CategoryId = 5,
                DriverName = new NLipsum.Core.Sentence().ToString(),
                DriverContact = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };

            await this.DbContext.Partners.AddRangeAsync(Partner1, Partner2, Partner3);
            await this.DbContext.SaveChangesAsync();

            var expected = this.DbContext.Partners.Where(x => x.CategoryId == 5).Count();
            var actual = await this.Service.GetAllIdsByCategoryAsync(5);
            var actualCount = 0;
            foreach (var result in actual)
            {
                actualCount++;
            }

            Assert.Equal(expected, actualCount);
        }

        [Fact]
        public async Task AddAsyncShouldAddCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();
            await this.CreatePartnerAsync(newGuidId);

            var name = new NLipsum.Core.Sentence().ToString();
            var categoryId = 1;
            var cityId = 1;
            var DriverName = new NLipsum.Core.Sentence().ToString();
            var DriverContact =  new NLipsum.Core.Word().ToString();
            var imageUrl = new NLipsum.Core.Word().ToString();
            var docPaseUrl = new NLipsum.Core.Word().ToString();
            var docCedulaUrl = new NLipsum.Core.Word().ToString();
            var docTarjetonUrl = new NLipsum.Core.Word().ToString();
            var docSoatUrl = new NLipsum.Core.Word().ToString();
            var docLicenciaUrl = new NLipsum.Core.Word().ToString();
            var docOperacionUrl = new NLipsum.Core.Word().ToString();
            var docSeguroUrl = new NLipsum.Core.Word().ToString();
            var docTecnoUrl = new NLipsum.Core.Word().ToString();
            var ownerId = Guid.NewGuid().ToString();

            await this.Service.AddAsync(name, categoryId, cityId, DriverName, DriverContact, imageUrl, docPaseUrl, docCedulaUrl, docTarjetonUrl, docSoatUrl, docLicenciaUrl, docOperacionUrl, docSeguroUrl, docTecnoUrl, ownerId);

            var PartnersCount = await this.DbContext.Partners.CountAsync();
            Assert.Equal(2, PartnersCount);
        }

        [Fact]
        public async Task DeleteAsyncShouldDeleteCorrectly()
        {
            var newGuidId = Guid.NewGuid().ToString();

            var Partner = await this.CreatePartnerAsync(newGuidId);

            await this.Service.DeleteAsync(Partner.Id);

            var PartnersCount = this.DbContext.Partners.Where(x => !x.IsDeleted).ToArray().Count();
            var deletedPartner = await this.DbContext.Partners.FirstOrDefaultAsync(x => x.Id == Partner.Id);
            Assert.Equal(0, PartnersCount);
            Assert.Null(deletedPartner);
        }

        [Fact]
        public async Task RatePartnerAsyncShouldGiveCorrectRating()
        {
            var newGuidId = Guid.NewGuid().ToString();
            var Partner = await this.CreatePartnerAsync(newGuidId);

            var rateValue = 4;
            await this.Service.RatePartnerAsync(newGuidId, rateValue);

            var expected = rateValue;
            var actual = Partner.Rating;

            Assert.Equal(expected, actual);
        }

        private async Task<Partner> CreatePartnerAsync(string newGuidId)
        {
            var Partner = new Partner
            {
                Id = newGuidId,
                Placa = new NLipsum.Core.Sentence().ToString(),
                CategoryId = 1,
                DriverName = new NLipsum.Core.Sentence().ToString(),
                DriverContact = new NLipsum.Core.Word().ToString(),
                ImageUrl = new NLipsum.Core.Word().ToString(),
                Rating = 4,
                RatersCount = 1,
            };

            await this.DbContext.Partners.AddAsync(Partner);
            await this.DbContext.SaveChangesAsync();
            this.DbContext.Entry<Partner>(Partner).State = EntityState.Detached;
            return Partner;
        }
    }
}
