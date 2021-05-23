namespace TaxiDinamica.Web.ViewModels.Partners
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class PartnerServiceViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public bool Available { get; set; }
    }
}
