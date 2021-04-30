namespace CeroFilas.Web.ViewModels.Partners
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class PartnerSimpleViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
