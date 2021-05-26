namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Web.ViewModels.PartnerServices;

    public class PartnerServiceDetailsViewComponent : ViewComponent
    {
        private readonly IPartnerServicesService PartnerServicesService;

        public PartnerServiceDetailsViewComponent(IPartnerServicesService PartnerServicesService)
        {
            this.PartnerServicesService = PartnerServicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string partnerId, int serviceId)
        {
            var viewModel =
                await this.PartnerServicesService.GetByIdAsync<PartnerServiceDetailsViewModel>(partnerId, serviceId);

            return this.View(viewModel);
        }
    }
}
