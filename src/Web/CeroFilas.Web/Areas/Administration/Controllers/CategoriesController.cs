namespace CeroFilas.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CeroFilas.Common;
    using CeroFilas.Services.Cloudinary;
    using CeroFilas.Services.Data.Categories;
    using CeroFilas.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : AdministrationController
    {
        private readonly ICategoriesService categoriesService;
        private readonly ICloudinaryService cloudinaryService;

        public CategoriesController(
            ICategoriesService categoriesService,
            ICloudinaryService cloudinaryService)
        {
            this.categoriesService = categoriesService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new CategoriesListViewModel
            {
                Categories = await this.categoriesService.GetAllAsync<CategoryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult AddCategory()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.categoriesService.AddAsync(input.Name, input.Description);
            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await this.categoriesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
