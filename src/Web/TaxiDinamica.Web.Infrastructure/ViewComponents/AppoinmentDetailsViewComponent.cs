namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Web.ViewModels.Appointments;

    public class AppointmentDetailsViewComponent : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;

        public AppointmentDetailsViewComponent(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string appoinmentId)
        {
            var viewModel = await this.appointmentsService.GetByIdAsync<AppointmentViewModel>(appoinmentId);

            return this.View(viewModel);
        }
    }
}
