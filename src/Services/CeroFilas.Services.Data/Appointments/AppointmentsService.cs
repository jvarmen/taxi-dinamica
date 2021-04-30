namespace CeroFilas.Services.Data.Appointments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CeroFilas.Data.Common.Repositories;
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;
    using Microsoft.EntityFrameworkCore;

    public class AppointmentsService : IAppointmentsService
    {
        private readonly IDeletableEntityRepository<Appointment> appointmentsRepository;

        public AppointmentsService(IDeletableEntityRepository<Appointment> appointmentsRepository)
        {
            this.appointmentsRepository = appointmentsRepository;
        }

        public async Task<T> GetByIdAsync<T>(string id)
        {
            var appointment =
                await this.appointmentsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefaultAsync();
            return appointment;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var appointments =
                await this.appointmentsRepository
                .All()
                .OrderByDescending(x => x.DateTime)
                .To<T>().ToListAsync();
            return appointments;
        }

        public async Task<IEnumerable<T>> GetAllByPartnerAsync<T>(string partnerId)
        {
            var appointments =
                await this.appointmentsRepository
                .All()
                .Where(x => x.PartnerId == partnerId)
                .OrderByDescending(x => x.DateTime)
                .To<T>().ToListAsync();
            return appointments;
        }

        public async Task<IEnumerable<T>> GetUpcomingByUserAsync<T>(string userId)
        {
            var appointments =
                await this.appointmentsRepository
                .All()
                .Where(x => x.UserId == userId
                        && x.DateTime.Date > DateTime.UtcNow.Date)
                .OrderBy(x => x.DateTime)
                .To<T>().ToListAsync();
            return appointments;
        }

        public async Task<IEnumerable<T>> GetPastByUserAsync<T>(string userId)
        {
            var appointments =
                await this.appointmentsRepository
                .All()
                .Where(x => x.UserId == userId
                        && x.DateTime.Date < DateTime.UtcNow.Date
                        && x.Confirmed == true)
                .OrderBy(x => x.DateTime)
                .To<T>().ToListAsync();
            return appointments;
        }

        public async Task AddAsync(string userId, string partnerId, int serviceId, DateTime dateTime)
        {
            await this.appointmentsRepository.AddAsync(new Appointment
            {
                Id = Guid.NewGuid().ToString(),
                DateTime = dateTime,
                UserId = userId,
                PartnerId = partnerId,
                ServiceId = serviceId,
            });
            await this.appointmentsRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(string id)
        {
            var appointment =
                await this.appointmentsRepository
                .AllAsNoTracking()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            this.appointmentsRepository.Delete(appointment);
            await this.appointmentsRepository.SaveChangesAsync();
        }

        public async Task ConfirmAsync(string id)
        {
            var appointment =
                await this.appointmentsRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            appointment.Confirmed = true;
            await this.appointmentsRepository.SaveChangesAsync();
        }

        public async Task DeclineAsync(string id)
        {
            var appointment =
                await this.appointmentsRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            appointment.Confirmed = false;
            await this.appointmentsRepository.SaveChangesAsync();
        }

        public async Task RateAppointmentAsync(string id)
        {
            var appointment =
                await this.appointmentsRepository
                .All()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
            appointment.IsPartnerRatedByTheUser = true;
            await this.appointmentsRepository.SaveChangesAsync();
        }
    }
}
