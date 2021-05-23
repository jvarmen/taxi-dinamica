namespace TaxiDinamica.Web.ViewModels.Partners
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class PartnerSimpleViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
