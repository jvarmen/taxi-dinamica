namespace CeroFilas.Web.ViewModels.Home
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
