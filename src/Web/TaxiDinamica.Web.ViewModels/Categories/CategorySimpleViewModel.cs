namespace TaxiDinamica.Web.ViewModels.Categories
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class CategorySimpleViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int PartnersCount { get; set; }
    }
}
