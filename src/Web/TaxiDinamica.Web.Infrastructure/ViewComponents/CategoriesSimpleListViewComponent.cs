namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Web.ViewModels.Categories;

    public class CategoriesSimpleListViewComponent : ViewComponent
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesSimpleListViewComponent(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new CategoriesSimpleListViewModel
            {
                Categories = await this.categoriesService.GetAllAsync<CategorySimpleViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
