namespace CeroFilas.Web.ViewModels.Common.SelectLists
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class CitySelectListViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
