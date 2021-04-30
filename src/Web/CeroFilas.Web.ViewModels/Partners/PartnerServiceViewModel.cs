namespace CeroFilas.Web.ViewModels.Partners
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class PartnerServiceViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public string ServiceDescription { get; set; }

        public bool Available { get; set; }
    }
}
