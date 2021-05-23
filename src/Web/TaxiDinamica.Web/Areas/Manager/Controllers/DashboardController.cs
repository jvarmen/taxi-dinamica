namespace TaxiDinamica.Web.Areas.Manager.Controllers
{
    using System;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Data.Partners;
    using TaxiDinamica.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DashboardController : ManagerBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService partnersService;

        public DashboardController(
            UserManager<ApplicationUser> userManager,
            IPartnersService partnersService)
        {
            this.userManager = userManager;
            this.partnersService = partnersService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new PartnersListViewModel
            {
                Partners = await this.partnersService.GetAllByOwnerAsync<PartnerViewModel>(userId),
            };
            
            return this.View(viewModel);
        }
    }
}
