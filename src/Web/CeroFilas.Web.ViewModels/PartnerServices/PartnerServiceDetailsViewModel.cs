namespace CeroFilas.Web.ViewModels.PartnerServices
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class PartnerServiceDetailsViewModel : IMapFrom<PartnerService>
    {
        public string PartnerId { get; set; }

        public string PartnerName { get; set; }

        public string PartnerCityName { get; set; }

        public string PartnerAddress { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }
    }
}
