namespace CeroFilas.Web.ViewModels.Cities
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class CityViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PartnersCount { get; set; }
    }
}
