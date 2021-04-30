namespace CeroFilas.Web.ViewModels.Partners
{
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Web.ViewModels.Common.CustomValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class PartnerInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Name,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.AddressMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Address,
            MinimumLength = GlobalConstants.DataValidations.AddressMinLength)]
        public string Address { get; set; }
        
        public string Website { get; set; }

        [DataType(DataType.Upload)]
        [ValidateImageFile(ErrorMessage = GlobalConstants.ErrorMessages.Image)]
        public IFormFile Image { get; set; }
    }
}
