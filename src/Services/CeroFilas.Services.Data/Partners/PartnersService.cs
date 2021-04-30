namespace CeroFilas.Services.Data.Partners
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CeroFilas.Data.Common.Repositories;
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;
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
                .OrderBy(x => x.Name)
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
                .OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
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
                .OrderBy(x => x.Name);

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query
                    .Where(x => x.Name.ToLower()
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

        public async Task<string> AddAsync(string name, int categoryId, int cityId, string address, string website, string imageUrl)
        {
            var partner = new Partner
            {
                Id = Guid.NewGuid().ToString(),
                Name = name,
                CategoryId = categoryId,
                CityId = cityId,
                Address = address,
                Website = website,
                ImageUrl = imageUrl,
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
