namespace CeroFilas.Web.ViewModels.Categories
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class CategorySimpleViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PartnersCount { get; set; }
    }
}
