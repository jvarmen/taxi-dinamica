namespace TaxiDinamica.Web.ViewModels.Common.SelectLists
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class CitySelectListViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
