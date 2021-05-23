namespace TaxiDinamica.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using System.Text.Encodings.Web;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Services.DateTimeParser;
    using TaxiDinamica.Web.ViewModels.Appointments;
    using TaxiDinamica.Web.ViewModels.PartnerServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AppointmentsController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDateTimeParserService dateTimeParserService;
        private readonly IPartnersService PartnersService;
        private readonly IAppointmentsService appointmentsService;
        private readonly IPartnerServicesService PartnerServicesService;
        private readonly IEmailSender emailSender;

        public AppointmentsController(
            UserManager<ApplicationUser> userManager,
            IAppointmentsService appointmentsService,
            IPartnerServicesService PartnerServicesService,
            IDateTimeParserService dateTimeParserService,
            IPartnersService PartnersService,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.appointmentsService = appointmentsService;
            this.PartnerServicesService = PartnerServicesService;
            this.dateTimeParserService = dateTimeParserService;
            this.PartnersService = PartnersService;
            this.emailSender = emailSender;
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

            var callbackUrl = Url.Page("/Appoinments");

            // Send Email 
            var uemail = user?.Email;
            await this.emailSender.SendEmailAsync(
                uemail,
                "Cita Agendada",
                $"Haz agendado una cita exitosamente para el día {dateTime}, puedes ver los demás detalles haciendo <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click aquí</a>.");

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
