namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Web.ViewModels.Appointments;

    public class AllAppointmentsByPartnerViewComponent : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;

        public AllAppointmentsByPartnerViewComponent(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string partnerId)
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllByPartnerAsync<AppointmentViewModel>(partnerId),
            };

            return this.View(viewModel);
        }
    }
}
