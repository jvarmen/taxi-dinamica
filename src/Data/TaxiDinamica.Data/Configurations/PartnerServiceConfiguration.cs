namespace TaxiDinamica.Data.Configurations
{
    using TaxiDinamica.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class PartnerServiceConfiguration : IEntityTypeConfiguration<PartnerService>
    {
        public void Configure(EntityTypeBuilder<PartnerService> partnerService)
        {
            partnerService.HasKey(ss => new { ss.PartnerId, ss.ServiceId });
        }
    }
}
