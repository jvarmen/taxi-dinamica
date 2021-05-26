namespace TaxiDinamica.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Web.ViewModels.Appointments;

    public class AppointmentsController : AdministrationController
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllAsync<AppointmentViewModel>(),
            };
            return this.View(viewModel);
        }
    }
}
