namespace TaxiDinamica.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Web.ViewModels.Partners;

    public class PartnersSimpleListViewComponent : ViewComponent
    {
        private readonly IPartnersService PartnersService;

        public PartnersSimpleListViewComponent(IPartnersService PartnersService)
        {
            this.PartnersService = PartnersService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = new PartnersSimpleListViewModel
            {
                Partners = await this.PartnersService.GetAllAsync<PartnerSimpleViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
