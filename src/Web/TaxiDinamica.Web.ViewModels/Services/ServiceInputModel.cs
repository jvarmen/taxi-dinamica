namespace TaxiDinamica.Web.ViewModels.Services
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;

    public class ServiceInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.DescriptionMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Description,
            MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
