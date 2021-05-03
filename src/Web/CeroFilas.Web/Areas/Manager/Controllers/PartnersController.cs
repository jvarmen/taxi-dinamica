namespace CeroFilas.Web.Areas.Manager.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using System.Text.Encodings.Web;

    using CeroFilas.Common;
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Cloudinary;
    using CeroFilas.Services.Data.Categories;
    using CeroFilas.Services.Data.Cities;
    using CeroFilas.Services.Data.Appointments;
    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Services.Data.PartnerServicesServices;
    using CeroFilas.Services.Data.Services;
    using CeroFilas.Web.ViewModels.Common.SelectLists;
    using CeroFilas.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Logging;

    [Authorize]
    public class PartnersController : ManagerBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService PartnersService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IServicesService servicesService;
        private readonly IPartnerServicesService PartnerServicesService;
        private readonly IAppointmentsService appointmentsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ILogger<PartnersController> logger;

        public PartnersController(
            ILogger<PartnersController> logger,
            UserManager<ApplicationUser> userManager,
            IPartnersService PartnersService,
            ICategoriesService categoriesService,
            ICitiesService citiesService,
            IServicesService servicesService,
            IPartnerServicesService PartnerServicesService,
            ICloudinaryService cloudinaryService,
            IAppointmentsService appointmentsService)
        {
            this.userManager = userManager;
            this.PartnersService = PartnersService;
            this.categoriesService = categoriesService;
            this.PartnerServicesService = PartnerServicesService;
            this.appointmentsService = appointmentsService;
            this.citiesService = citiesService;
            this.servicesService = servicesService;
            this.cloudinaryService = cloudinaryService;
            this.logger = logger;
        }

        public async Task<IActionResult> Details(string id)
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = await this.PartnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);
            
            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

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

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);
            
            // Add Partner
            var partnerId = await this.PartnersService.AddAsync(input.Name, input.CategoryId, input.CityId, input.Address, input.Website, imageUrl, userId);

            // Add to the Partner all Services from its Category
            var servicesIds = await this.servicesService.GetAllIdsByCategoryAsync(input.CategoryId);
            await this.PartnerServicesService.AddAsync(partnerId, servicesIds);

            return this.RedirectToAction("Details", new { id = partnerId });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeServiceAvailableStatus(string PartnerId, int serviceId)
        {
            await this.PartnerServicesService.ChangeAvailableStatusAsync(PartnerId, serviceId);

            return this.RedirectToAction("Details", new { id = PartnerId });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(string id, string PartnerId)
        {
            await this.appointmentsService.ConfirmAsync(id);
            return this.RedirectToAction("Details", new { id = PartnerId });
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment(string id, string PartnerId)
        {
            await this.appointmentsService.DeclineAsync(id);
            return this.RedirectToAction("Details", new { id = PartnerId });
        }
    }
}
