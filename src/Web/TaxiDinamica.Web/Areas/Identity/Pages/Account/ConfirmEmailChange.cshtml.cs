namespace TaxiDinamica.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using TaxiDinamica.Data.Models;

    [AllowAnonymous]
    public class ConfirmEmailChangeModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public ConfirmEmailChangeModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(string userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                return this.RedirectToPage("/Index");
            }

            var user = await this.userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return this.NotFound($"No se puede cargar el usuario con ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await this.userManager.ChangeEmailAsync(user, email, code);
            if (!result.Succeeded)
            {
                this.StatusMessage = "Error al cambiar el correo electrónico.";
                return this.Page();
            }

            // In our UI email and user name are one and the same, so when we update the email
            // we need to update the user name.
            var setUserNameResult = await this.userManager.SetUserNameAsync(user, email);
            if (!setUserNameResult.Succeeded)
            {
                this.StatusMessage = "Error cambio el nombre de usuario.";
                return this.Page();
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Gracias por confirmar tu cambio de correo.";
            return this.Page();
        }
    }
}
