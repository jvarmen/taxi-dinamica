namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using TaxiDinamica.Services.Data.Appointments;
    using TaxiDinamica.Web.ViewModels.Appointments;
    using Microsoft.AspNetCore.Mvc;

    public class AllAppointmentsByPartnerViewComponent : ViewComponent
    {
        private readonly IAppointmentsService appointmentsService;

        public AllAppointmentsByPartnerViewComponent(IAppointmentsService appointmentsService)
        {
            this.appointmentsService = appointmentsService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string PartnerId)
        {
            var viewModel = new AppointmentsListViewModel
            {
                Appointments =
                    await this.appointmentsService.GetAllByPartnerAsync<AppointmentViewModel>(PartnerId),
            };

            return this.View(viewModel);
        }
    }
}
