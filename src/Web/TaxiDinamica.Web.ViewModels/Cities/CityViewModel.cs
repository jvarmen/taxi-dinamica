namespace TaxiDinamica.Web.ViewModels.Cities
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PartnersCount { get; set; }
    }
}
