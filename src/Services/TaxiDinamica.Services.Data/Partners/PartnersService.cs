namespace TaxiDinamica.Services.Data.Partners
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Common.Repositories;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class PartnersService : IPartnersService
    {
        private readonly IDeletableEntityRepository<Partner> partnersRepository;

        public PartnersService(IDeletableEntityRepository<Partner> partnersRepository)
        {
            this.partnersRepository = partnersRepository;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var partners =
                await this.partnersRepository
                .All()
                .OrderBy(x => x.Placa)
                .To<T>().ToListAsync();
            return partners;
        }

        public async Task<IEnumerable<T>> GetAllByOwnerAsync<T>(string ownerId)
        {
            var partners =
                await this.partnersRepository
                .All()
                .Where(x => x.OwnerId == ownerId)
                .OrderBy(x => x.Placa)
                .To<T>().ToListAsync();
            return partners;
        }


        public async Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex)
        {
            IQueryable<Partner> query =
                this.partnersRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Placa.ToLower()
                                .Contains(searchString.ToLower()));
            }

            if (sortId != null)
            {
                query = query
                    .Where(x => x.CategoryId == sortId);
            }

            return await query
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .To<T>().ToListAsync();
        }

        public async Task<int> GetCountForPaginationAsync(string searchString, int? sortId)
        {
            IQueryable<Partner> query =
                this.partnersRepository
                .AllAsNoTracking()
                .OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Placa.ToLower()
                                .Contains(searchString.ToLower()));
            }

            if (sortId != null)
            {
                query = query
                    .Where(x => x.CategoryId == sortId);
            }

            return await query.CountAsync();
        }

        public async Task<IEnumerable<string>> GetAllIdsByCategoryAsync(int categoryId)
        {
            var partnersIds =
                await this.partnersRepository
                .All()
                .Where(x => x.CategoryId == categoryId)
                .Select(x => x.Id)
                .ToListAsync();
            return partnersIds;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var partner =
                await this.partnersRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return partner;
        }

        public async Task<string> AddAsync(string placa, int categoryId, int cityId, string driverName, string driverContact, string imageUrl, string docPaseUrl, string docCedulaUrl, string docTarjetonUrl, string docSoatUrl, string docLicenciaUrl, string docOperacionUrl, string docSeguroUrl, string docTecnoUrl, string ownerId)
        {
            var partner = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Placa = placa.ToUpper(),
                ImageUrl = imageUrl,
                DocPaseUrl = docPaseUrl,
                DocCedulaUrl = docCedulaUrl,
                DocTarjetonUrl = docTarjetonUrl,
                DocSoatUrl = docSoatUrl,
                DocLicenciaUrl = docLicenciaUrl,
                DocOperacionUrl = docOperacionUrl,
                DocSeguroUrl = docSeguroUrl,
                DocTecnoUrl = docTecnoUrl,
                OwnerId = ownerId,
                CategoryId = categoryId,
                CityId = cityId,
                DriverName = driverName,
                DriverContact = driverContact,
                Schedule = "15",
                Available = false,
                Rating = 0,
                RatersCount = 0,
            };

            await this.partnersRepository.AddAsync(partner);
            await this.partnersRepository.SaveChangesAsync();
            return partner.Id;
        }

        public async Task DeleteAsync(string id)
        {
            var partner =
                await this.partnersRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.partnersRepository.Delete(partner);
            await this.partnersRepository.SaveChangesAsync();
        }

        public async Task RatePartnerAsync(string id, int rateValue)
        {
            var partner =
                await this.partnersRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            var oldRating = partner.Rating;
            var oldRatersCount = partner.RatersCount;

            var newRatersCount = oldRatersCount + 1;
            var newRating = (oldRating + rateValue) / newRatersCount;

            partner.Rating = newRating;
            partner.RatersCount = newRatersCount;

            await this.partnersRepository.SaveChangesAsync();
        }
    }
}
