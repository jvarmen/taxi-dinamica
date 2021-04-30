namespace CeroFilas.Web.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;

    public class CityInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }
    }
}
