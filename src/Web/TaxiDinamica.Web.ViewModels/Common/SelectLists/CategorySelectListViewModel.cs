namespace TaxiDinamica.Web.ViewModels.Common.SelectLists
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class CategorySelectListViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
