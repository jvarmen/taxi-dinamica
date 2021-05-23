namespace TaxiDinamica.Web.ViewModels.Home
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
