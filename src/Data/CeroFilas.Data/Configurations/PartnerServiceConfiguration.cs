namespace CeroFilas.Data.Configurations
{
    using CeroFilas.Data.Models;
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
