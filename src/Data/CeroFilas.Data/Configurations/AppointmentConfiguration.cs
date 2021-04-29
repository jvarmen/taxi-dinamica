namespace CeroFilas.Data.Configurations
{
    using CeroFilas.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> appointment)
        {
            appointment
                .HasOne(a => a.User)
                .WithMany(u => u.Appointments)
                .HasForeignKey(a => a.UserId);

            appointment
                .HasOne(a => a.Partner)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.PartnerId);

            appointment
                .HasOne(a => a.Service)
                .WithMany(s => s.Appointments)
                .HasForeignKey(a => a.ServiceId);

            appointment
                .HasOne(a => a.PartnerService)
                .WithMany(ss => ss.Appointments)
                .HasForeignKey(a => new { a.PartnerId, a.ServiceId });
        }
    }
}
