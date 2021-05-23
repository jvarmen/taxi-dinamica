namespace TaxiDinamica.Services.Data.Appointments
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IAppointmentsService
    {
        Task<T> GetByIdAsync<T>(string id);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId);

        Task<IEnumerable<T>> GetUpcomingByUserAsync<T>(string userId);

        Task<IEnumerable<T>> GetPastByUserAsync<T>(string userId);

        Task AddAsync(string userId, string partnerId, int serviceId, DateTime dateTime);

        Task DeleteAsync(string id);

        Task ConfirmAsync(string id);

        Task DeclineAsync(string id);

        Task RateAppointmentAsync(string id);
    }
}
