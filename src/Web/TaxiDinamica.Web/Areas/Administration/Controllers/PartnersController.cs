namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Cloudinary;
    using TaxiDinamica.Services.Data.Categories;
    using TaxiDinamica.Services.Data.Cities;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.Data.Services;
    using TaxiDinamica.Web.ViewModels.Common.SelectLists;
    using TaxiDinamica.Web.ViewModels.Partners;

    public class PartnersController : AdministrationController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService partnersService;
        private readonly ICategoriesService categoriesService;
        private readonly ICitiesService citiesService;
        private readonly IServicesService servicesService;
        private readonly IPartnerServicesService partnerServicesService;
        private readonly ICloudinaryService cloudinaryService;

        public PartnersController(
            UserManager<ApplicationUser> userManager,
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

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.partnersService.GetByIdAsync<PartnerViewModel>(id);

            string[] docs = { "DocPaseUrl", "DocCedulaUrl", "DocTarjetonUrl", "DocSoatUrl", "DocLicenciaUrl", "DocOperacionUrl", "DocSeguroUrl", "DocTecnoUrl" };
            ViewData["documents"] = docs;

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
                string tempname = "Pase -" + input.Placa;
                docPaseUrl = await this.cloudinaryService.UploadPictureAsync(input.PaseUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docPaseUrl = GlobalConstants.Images.DemoImg;
            }

            string docCedulaUrl;
            try
            {
                string tempname = "Cedula -" + input.Placa;
                docCedulaUrl = await this.cloudinaryService.UploadPictureAsync(input.CedulaUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docCedulaUrl = GlobalConstants.Images.DemoImg;
            }

            string docTarjetonUrl;
            try
            {
                string tempname = "Tarjeton -" + input.Placa;
                docTarjetonUrl = await this.cloudinaryService.UploadPictureAsync(input.TarjetonUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docTarjetonUrl = GlobalConstants.Images.DemoImg;
            }

            string docSoatUrl;
            try
            {
                string tempname = "Soat -" + input.Placa;
                docSoatUrl = await this.cloudinaryService.UploadPictureAsync(input.SoatUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docSoatUrl = GlobalConstants.Images.DemoImg;
            }

            string docLicenciaUrl;
            try
            {
                string tempname = "Licencia -" + input.Placa;
                docLicenciaUrl = await this.cloudinaryService.UploadPictureAsync(input.LicenciaUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docLicenciaUrl = GlobalConstants.Images.DemoImg;
            }

            string docOperacionUrl;
            try
            {
                string tempname = "Operacion -" + input.Placa;
                docOperacionUrl = await this.cloudinaryService.UploadPictureAsync(input.OperacionUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docOperacionUrl = GlobalConstants.Images.DemoImg;
            }

            string docSeguroUrl;
            try
            {
                string tempname = "Seguro -" + input.Placa;
                docSeguroUrl = await this.cloudinaryService.UploadPictureAsync(input.SeguroUrl, tempname);
            }
            catch (System.Exception)
            {
                // In case of missing Cloudinary configuration from appsettings.json
                docSeguroUrl = GlobalConstants.Images.DemoImg;
            }

            string docTecnoUrl;
            try
            {
                string tempname = "Tecno -" + input.Placa;
                docTecnoUrl = await this.cloudinaryService.UploadPictureAsync(input.TecnoUrl, tempname);
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
