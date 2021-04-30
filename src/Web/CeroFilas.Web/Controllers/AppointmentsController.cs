namespace CeroFilas.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using CeroFilas.Data.Models;
    using CeroFilas.Services.Data.Appointments;
    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Services.Data.PartnerServicesServices;
    using CeroFilas.Services.DateTimeParser;
    using CeroFilas.Web.ViewModels.Appointments;
    using CeroFilas.Web.ViewModels.PartnerServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AppointmentsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDateTimeParserService dateTimeParserService;
        private readonly IPartnersService PartnersService;
        private readonly IAppointmentsService appointmentsService;
        private readonly IPartnerServicesService PartnerServicesService;

        public AppointmentsController(
            UserManager<ApplicationUser> userManager,
            IAppointmentsService appointmentsService,
            IPartnerServicesService PartnerServicesService,
            IDateTimeParserService dateTimeParserService,
            IPartnersService PartnersService)
        {
            this.userManager = userManager;
            this.appointmentsService = appointmentsService;
            this.PartnerServicesService = PartnerServicesService;
            this.dateTimeParserService = dateTimeParserService;
            this.PartnersService = PartnersService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetUpcomingByUserAsync<AppointmentViewModel>(userId),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> MakeAnAppointment(string PartnerId, int serviceId)
        {
            var PartnerService = await this.PartnerServicesService.GetByIdAsync<PartnerServiceSimpleViewModel>(PartnerId, serviceId);
            if (PartnerService == null || !PartnerService.Available)
            {
                return this.View("UnavailableService");
            }

            var viewModel = new AppointmentInputModel
            {
                PartnerId = PartnerId,
                ServiceId = serviceId,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MakeAnAppointment(AppointmentInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("MakeAnAppointment", new { input.PartnerId, input.ServiceId });
            }

            DateTime dateTime;
            try
            {
                dateTime = this.dateTimeParserService.ConvertStrings(input.Date, input.Time);
            }
            catch (System.Exception)
            {
                return this.RedirectToAction("MakeAnAppointment", new { input.PartnerId, input.ServiceId });
            }

            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            await this.appointmentsService.AddAsync(userId, input.PartnerId, input.ServiceId, dateTime);

            return this.RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CancelAppointment(string id)
        {
            var viewModel = await this.appointmentsService.GetByIdAsync<AppointmentViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAppointment(string id)
        {
            await this.appointmentsService.DeleteAsync(id);

            return this.RedirectToAction("Index");
        }
    }
}
