﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using TaxiDinamica.Common;
using TaxiDinamica.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace TaxiDinamica.Web.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<RegisterModel> logger;
        private readonly IEmailSender emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            public bool Role { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Nombres")]
            public string Names { get; set; }

            [Required]
            [DataType(DataType.Text)]
            [Display(Name = "Apellidos")]
            public string LastNames { get; set; }

            [Required]
            [Range(0, int.MaxValue, ErrorMessage = "Porfavor ingrese un número de cédula válida")]
            [Display(Name = "Cédula de Ciudadanía")]
            public int DocumentId { get; set; }

            [Phone]
            [Display(Name = "Número de Teléfono")]
            public string PhoneNumber { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} y {1} máximo de caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Repetir contraseña")]
            [Compare("Password", ErrorMessage = "La contraseña y su confirmación no coinciden.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/Appointments");
            ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser 
                { 
                    Names = Input.Names, 
                    LastNames = Input.LastNames, 
                    DocumentId = Input.DocumentId, 
                    PhoneNumber = Input.PhoneNumber,
                    UserName = Input.Email, 
                    Email = Input.Email,
                };
                var result = await this.userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if(Input.Role)
                    {
                        returnUrl = Url.Content("~/Manager/Partners/AddPartner");
                        await this.userManager.AddToRoleAsync(user, GlobalConstants.PartnerManagerRoleName);
                    }
                    this.logger.LogInformation("User created a new account with password.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await this.emailSender.SendEmailAsync(
                        Input.Email, 
                        "Confirmar tu correo",
                        $"Porfavor confirma tu cuenta dando <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>click aquí</a>.");

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
                    }
                    else
                    {
                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}