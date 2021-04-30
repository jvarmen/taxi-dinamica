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
            // This is used as a Menu in Partner Manager Area
            // Now only the Admin can Add Partners and only the seeded Manager can manage all of them
            // When Registering a Partner becomes an option for every user, UserId (OwnerId for Partners) would be checked here
            var viewModel = new PartnersSimpleListViewModel
            {
                Partners = await this.PartnersService.GetAllAsync<PartnerSimpleViewModel>(),
            };

            return this.View(viewModel);
        }
    }
}
