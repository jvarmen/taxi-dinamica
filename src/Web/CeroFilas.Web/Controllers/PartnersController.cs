namespace CeroFilas.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CeroFilas.Services.Data.Categories;
    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Web.ViewModels.Categories;
    using CeroFilas.Web.ViewModels.Common.Pagination;
    using CeroFilas.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Mvc;

    public class PartnersController : BaseController
    {
        private readonly IPartnersService partnersService;
        private readonly ICategoriesService categoriesService;

        public PartnersController(
            IPartnersService partnersService,
            ICategoriesService categoriesService)
        {
            this.partnersService = partnersService;
            this.categoriesService = categoriesService;
        }

        public async Task<IActionResult> Index(
            int? sortId, // categoryId
            string currentFilter,
            string searchString,
            int? pageNumber)
        {
            if (sortId != null)
            {
                var category = await this.categoriesService
                    .GetByIdAsync<CategorySimpleViewModel>(sortId.Value);
                if (category == null)
                {
                    return new StatusCodeResult(404);
                }

                this.ViewData["CategoryName"] = category.Name;
            }

            this.ViewData["CurrentSort"] = sortId;

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            this.ViewData["CurrentFilter"] = searchString;

            int pageSize = PageSizesConstants.Partners;
            var pageIndex = pageNumber ?? 1;

            var partners = await this.partnersService
                .GetAllWithSortingFilteringAndPagingAsync<PartnerViewModel>(
                    searchString, sortId, pageSize, pageIndex);
            var partnersList = partners.ToList();

            var count = await this.partnersService
                .GetCountForPaginationAsync(searchString, sortId);

            var viewModel = new PartnersPaginatedListViewModel
            {
                Partners = new PaginatedList<PartnerViewModel>(partnersList, count, pageIndex, pageSize),
            };

            return this.View(viewModel);
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }
    }
}
