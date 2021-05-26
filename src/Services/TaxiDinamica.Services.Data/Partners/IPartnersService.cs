namespace TaxiDinamica.Services.Data.Partners
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPartnersService
    {
        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByOwnerAsync<T>(string ownerId);

        Task<IEnumerable<T>> GetAllWithSortingFilteringAndPagingAsync<T>(
            string searchString,
            int? sortId,
            int pageSize,
            int pageIndex);

        Task<int> GetCountForPaginationAsync(string searchString, int? sortId);

        Task<IEnumerable<string>> GetAllIdsByCategoryAsync(int categoryId);

        Task<T> GetByIdAsync<T>(string id);
// string docTarjetonUrl, string docSoatUrl, string docLicenciaUrl, string docOperacionUrl, string docSeguroUrl, string docTecnoUrl,
        Task<string> AddAsync(string placa, int categoryId, int cityId, string driverName, string driverContact, string imageUrl, string docPaseUrl, string docCedulaUrl, string docTarjetonUrl, string docSoatUrl, string docLicenciaUrl, string docOperacionUrl, string docSeguroUrl, string docTecnoUrl, string ownerId);

        Task DeleteAsync(string id);

        Task RatePartnerAsync(string id, int rateValue);
    }
}
