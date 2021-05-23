namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using TaxiDinamica.Common;
    using TaxiDinamica.Services.Cloudinary;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Cities;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Services;
    using TaxiDinamica.Web.ViewModels.Common.SelectLists;
    using TaxiDinamica.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartnersController : AdministrationController
    {
        private readonly IPartnersService partnersService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IServicesService servicesService;
        private readonly IPartnerServicesService partnerServicesService;
        private readonly ICloudinaryService cloudinaryService;

        public PartnersController(
            IPartnersService partnersService,
            ICategoriesService categoriesService,
            ICitiesService citiesService,
            IServicesService servicesService,
            IPartnerServicesService partnerServicesService,
            ICloudinaryService cloudinaryService)
        {
            this.partnersService = partnersService;
            this.categoriesService = categoriesService;
            this.citiesService = citiesService;
            this.servicesService = servicesService;
            this.partnerServicesService = partnerServicesService;
            this.cloudinaryService = cloudinaryService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new PartnersListViewModel
            {
                Partners = await this.partnersService.GetAllAsync<PartnerViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> AddPartner()
        {
            var categories = await this.categoriesService.GetAllAsync<CategorySelectListViewModel>();
            var cities = await this.citiesService.GetAllAsync<CitySelectListViewModel>();

            this.ViewData["Categories"] = new SelectList(categories, "Id", "Name");
            this.ViewData["Cities"] = new SelectList(cities, "Id", "Name");

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPartner(PartnerInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            string imageUrl;
            try
            {
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Name);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.DemoImg;
            }

            // Add Partner
            var partnerId = await this.partnersService.AddAsync(input.Name, input.CategoryId, input.CityId, input.Address, input.Website, imageUrl, "admin");

            // Add to the Partner all Services from its Category
            var servicesIds = await this.servicesService.GetAllIdsByCategoryAsync(input.CategoryId);
            await this.partnerServicesService.AddAsync(partnerId, servicesIds);

            return this.RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePartner(string id)
        {
            await this.partnersService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
