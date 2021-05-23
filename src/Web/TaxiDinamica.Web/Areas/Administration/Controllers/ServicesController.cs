namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Services;
    using TaxiDinamica.Web.ViewModels.Common.SelectLists;
    using TaxiDinamica.Web.ViewModels.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class ServicesController : AdministrationController
    {
        private readonly IServicesService servicesService;
        private readonly ICategoriesService categoriesService;
        private readonly IPartnersService partnersService;
        private readonly IPartnerServicesService partnerServicesService;

        public ServicesController(
            IServicesService servicesService,
            ICategoriesService categoriesService,
            IPartnersService partnersService,
            IPartnerServicesService partnerServicesService)
        {
            this.servicesService = servicesService;
            this.categoriesService = categoriesService;
            this.partnersService = partnersService;
            this.partnerServicesService = partnerServicesService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new ServicesListViewModel
            {
                Services = await this.servicesService.GetAllAsync<ServiceViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddService()
        {
            var categories = await this.categoriesService.GetAllAsync<CategorySelectListViewModel>();
            this.ViewData["Categories"] = new SelectList(categories, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddService(ServiceInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            // Add Service
            var serviceId = await this.servicesService.AddAsync(input.Name, input.CategoryId, input.Description);

            // Add the Service to all Partners in the Category
            var partnersIds = await this.partnersService.GetAllIdsByCategoryAsync(input.CategoryId);
            await this.partnerServicesService.AddAsync(partnersIds, serviceId);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteService(int id)
        {
            await this.servicesService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
