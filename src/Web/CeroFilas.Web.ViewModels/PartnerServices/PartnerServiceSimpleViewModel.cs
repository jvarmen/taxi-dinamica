namespace CeroFilas.Web.ViewModels.PartnerServices
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class PartnerServiceSimpleViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }

        public int ServiceId { get; set; }

        public bool Available { get; set; }
    }
}
