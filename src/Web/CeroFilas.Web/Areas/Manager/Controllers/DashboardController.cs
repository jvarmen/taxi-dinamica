namespace CeroFilas.Web.Areas.Manager.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Text;
    using System.Text.Encodings.Web;

    using CeroFilas.Data.Models;
    using CeroFilas.Services.Data.Partners;
    using Microsoft.AspNetCore.Mvc;
    using CeroFilas.Web.ViewModels.Partners;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class DashboardController : ManagerBaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IPartnersService PartnersService;

        public DashboardController(
            UserManager<ApplicationUser> userManager,
            IPartnersService PartnersService)
        {
            this.userManager = userManager;
            this.PartnersService = PartnersService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await this.userManager.GetUserAsync(this.HttpContext.User);
            var userId = await this.userManager.GetUserIdAsync(user);

            var viewModel = new PartnersListViewModel
            {
                Partners = await this.PartnersService.GetAllByOwnerAsync<PartnerViewModel>(userId),
            };
            return this.View(viewModel);
        }
    }
}
