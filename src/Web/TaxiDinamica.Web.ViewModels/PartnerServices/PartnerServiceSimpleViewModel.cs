namespace TaxiDinamica.Web.ViewModels.PartnerServices
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class PartnerServiceSimpleViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }

        public int ServiceId { get; set; }

        public bool Available { get; set; }
    }
}
