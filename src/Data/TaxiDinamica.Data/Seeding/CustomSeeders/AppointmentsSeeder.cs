namespace TaxiDinamica.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class AppointmentsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Appointments.Any())
            {
                return;
            }

            var appointments = new List<Appointment>();

            // Get User Id
            var userId = dbContext.Users.Where(x => x.Email == GlobalConstants.AccountsSeeding.UserEmail).FirstOrDefault().Id;

            // Get Partners Ids
            var partnersIds = await dbContext.Partners.Select(x => x.Id).Take(GlobalConstants.SeededDataCounts.Partners).ToListAsync();

            foreach (var partnerId in partnersIds)
            {
                // Get a Service from each Partner
                var serviceId = dbContext.PartnerServices.Where(x => x.PartnerId == partnerId).FirstOrDefault().ServiceId;

                // Add Upcoming Appointments
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow.AddDays(5),
                    UserId = userId,
                    PartnerId = partnerId,
                    ServiceId = serviceId,
                });

                // Add Past Appointments
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow.AddDays(-5),
                    UserId = userId,
                    PartnerId = partnerId,
                    ServiceId = serviceId,
                    Confirmed = true,
                });

                // More Past Appointments for testing the RatePastAppointment option
                appointments.Add(new Appointment
                {
                    Id = Guid.NewGuid().ToString(),
                    DateTime = DateTime.UtcNow.AddDays(-10),
                    UserId = userId,
                    PartnerId = partnerId,
                    ServiceId = serviceId,
                    Confirmed = true,
                });
            }

            await dbContext.AddRangeAsync(appointments);
        }
    }
}
