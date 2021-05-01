namespace CeroFilas.Web.Infrastructure.ViewComponents
{
    using System.Threading.Tasks;

    using CeroFilas.Services.Data.Partners;
    using CeroFilas.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Mvc;

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
