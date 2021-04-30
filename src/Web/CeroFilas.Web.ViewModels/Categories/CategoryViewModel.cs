namespace CeroFilas.Web.ViewModels.Categories
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PartnersCount { get; set; }

        public int ServicesCount { get; set; }
    }
}
