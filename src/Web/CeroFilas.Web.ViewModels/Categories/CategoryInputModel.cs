namespace CeroFilas.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Web.ViewModels.Common.CustomValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class CategoryInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.DescriptionMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Description,
            MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
