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
        private readonly IPartnersService partnersService;
        private readonly IAppointmentsService appointmentsService;
        private readonly IPartnerServicesService partnerServicesService;
        private readonly IEmailSender emailSender;

        public AppointmentsController(
            UserManager<ApplicationUser> userManager,
            IAppointmentsService appointmentsService,
            IPartnerServicesService partnerServicesService,
            IDateTimeParserService dateTimeParserService,
            IPartnersService partnersService,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.appointmentsService = appointmentsService;
            this.partnerServicesService = partnerServicesService;
            this.dateTimeParserService = dateTimeParserService;
            this.partnersService = partnersService;
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

        public async Task<IActionResult> MakeAnAppointment(string partnerId, int serviceId)
        {
            var partnerService = await this.partnerServicesService.GetByIdAsync<PartnerServiceSimpleViewModel>(partnerId, serviceId);
            if (partnerService == null || !partnerService.Available)
            {
                return this.View("UnavailableService");
            }

            var viewModel = new AppointmentInputModel
            {
                PartnerId = partnerId,
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

            var callbackUrl = this.Url.Page("/Appoinments");

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
