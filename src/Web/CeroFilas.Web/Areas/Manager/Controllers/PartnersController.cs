namespace CeroFilas.Web.Areas.Manager.Controllers
{
    using System.Threading.Tasks;

    using CeroFilas.Services.Data.Appointments;
    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Services.Data.PartnerServicesServices;
    using CeroFilas.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Mvc;

    public class PartnersController : ManagerBaseController
    {
        private readonly IPartnersService PartnersService;
        private readonly IPartnerServicesService PartnerServicesService;
        private readonly IAppointmentsService appointmentsService;

        public PartnersController(
            IPartnersService PartnersService,
            IPartnerServicesService PartnerServicesService,
            IAppointmentsService appointmentsService)
        {
            this.PartnersService = PartnersService;
            this.PartnerServicesService = PartnerServicesService;
            this.appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.PartnersService.GetByIdAsync<PartnerWithServicesViewModel>(id);

            if (viewModel == null)
            {
                return new StatusCodeResult(404);
            }

            return this.View(viewModel);
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
