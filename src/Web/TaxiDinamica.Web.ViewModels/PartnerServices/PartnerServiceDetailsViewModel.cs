namespace TaxiDinamica.Web.ViewModels.PartnerServices
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class PartnerServiceDetailsViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }
        public string PartnerPlaca { get; set; }
        public string PartnerDriverName { get; set; }
        public string PartnerDriverContact { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
    }
}
