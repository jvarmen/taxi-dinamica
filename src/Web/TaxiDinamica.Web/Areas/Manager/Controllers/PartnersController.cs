namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.Extensions.Logging;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Cloudinary;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Cities;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Services;
    using TaxiDinamica.Web.ViewModels.Common.SelectLists;
    using TaxiDinamica.Web.ViewModels.Partners;

    public class PartnersController : ManagerBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService partnersService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IServicesService servicesService;
        private readonly IPartnerServicesService partnerServicesService;
        private readonly IAppointmentsService appointmentsService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly ILogger<PartnersController> logger;

        public PartnersController(
            ILogger<PartnersController> logger,
            UserManager<ApplicationUser> userManager,
            IPartnersService partnersService,
            ICategoriesService categoriesService,
            ICitiesService citiesService,
            IServicesService servicesService,
            IPartnerServicesService partnerServicesService,
            ICloudinaryService cloudinaryService,
            IAppointmentsService appointmentsService)
        {
            this.userManager = userManager;
            this.partnersService = partnersService;
            this.categoriesService = categoriesService;
            this.partnerServicesService = partnerServicesService;
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

            var viewModel = await this.partnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

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
                imageUrl = await this.cloudinaryService.UploadPictureAsync(input.Image, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                imageUrl = GlobalConstants.Images.DemoImg;
            }

            string docPaseUrl;
            try
            {
                docPaseUrl = await this.cloudinaryService.UploadRawAsync(input.PaseUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docPaseUrl = GlobalConstants.Images.DemoImg;
            }

            string docCedulaUrl;
            try
            {
                docCedulaUrl = await this.cloudinaryService.UploadRawAsync(input.CedulaUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docCedulaUrl = GlobalConstants.Images.DemoImg;
            }

            string docTarjetonUrl;
            try
            {
                docTarjetonUrl = await this.cloudinaryService.UploadRawAsync(input.TarjetonUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docTarjetonUrl = GlobalConstants.Images.DemoImg;
            }

            string docSoatUrl;
            try
            {
                docSoatUrl = await this.cloudinaryService.UploadRawAsync(input.SoatUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docSoatUrl = GlobalConstants.Images.DemoImg;
            }

            string docLicenciaUrl;
            try
            {
                docLicenciaUrl = await this.cloudinaryService.UploadRawAsync(input.LicenciaUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docLicenciaUrl = GlobalConstants.Images.DemoImg;
            }

            string docOperacionUrl;
            try
            {
                docOperacionUrl = await this.cloudinaryService.UploadRawAsync(input.OperacionUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docOperacionUrl = GlobalConstants.Images.DemoImg;
            }

            string docSeguroUrl;
            try
            {
                docSeguroUrl = await this.cloudinaryService.UploadRawAsync(input.SeguroUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docSeguroUrl = GlobalConstants.Images.DemoImg;
            }

            string docTecnoUrl;
            try
            {
                docTecnoUrl = await this.cloudinaryService.UploadRawAsync(input.TecnoUrl, input.Placa);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docTecnoUrl = GlobalConstants.Images.DemoImg;
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            // Add Partner
            var partnerId = await this.partnersService.AddAsync(input.Placa, input.CategoryId, input.CityId, input.DriverName, input.DriverContact, imageUrl, docPaseUrl, docCedulaUrl, docTarjetonUrl, docSoatUrl, docLicenciaUrl, docOperacionUrl, docSeguroUrl, docTecnoUrl, userId);

            // Add to the Partner all Services from its Category
            var servicesIds = await this.servicesService.GetAllIdsByCategoryAsync(input.CategoryId);
            await this.partnerServicesService.AddAsync(partnerId, servicesIds);

            return this.RedirectToAction("Details", new { id = partnerId });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeServiceAvailableStatus(string partnerId, int serviceId)
        {
            await this.partnerServicesService.ChangeAvailableStatusAsync(partnerId, serviceId);

            return this.RedirectToAction("Details", new { id = partnerId });
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmAppointment(string id, string partnerId)
        {
            await this.appointmentsService.ConfirmAsync(id);
            return this.RedirectToAction("Details", new { id = partnerId });
        }

        [HttpPost]
        public async Task<IActionResult> DeclineAppointment(string id, string partnerId)
        {
            await this.appointmentsService.DeclineAsync(id);
            return this.RedirectToAction("Details", new { id = partnerId });
        }
    }
}
