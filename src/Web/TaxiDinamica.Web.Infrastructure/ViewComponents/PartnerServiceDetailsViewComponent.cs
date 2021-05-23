namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using TaxiDinamica.Services.Data.PartnerServicesServices;
    using TaxiDinamica.Web.ViewModels.PartnerServices;
    using Microsoft.AspNetCore.Mvc;

    public class PartnerServiceDetailsViewComponent : ViewComponent
    {
        private readonly IPartnerServicesService PartnerServicesService;

        public PartnerServiceDetailsViewComponent(IPartnerServicesService PartnerServicesService)
        {
            this.PartnerServicesService = PartnerServicesService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string PartnerId, int serviceId)
        {
            var viewModel =
                await this.PartnerServicesService.GetByIdAsync<PartnerServiceDetailsViewModel>(PartnerId, serviceId);

            return this.View(viewModel);
        }
    }
}
