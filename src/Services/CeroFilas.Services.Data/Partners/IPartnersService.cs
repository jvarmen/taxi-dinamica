namespace CeroFilas.Services.Data.Partners
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartnersService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync(string searchString, int? sortId);

        Task<IEnumerable<string>> GetAllIdsByCategoryAsync(int categoryId);

        Task<T> GetByIdAsync<T>(string id);

        Task<string> AddAsync(string name, int categoryId, int cityId, string address, string website, string imageUrl);

        Task DeleteAsync(string id);

        Task RatePartnerAsync(string id, int rateValue);
    }
}
