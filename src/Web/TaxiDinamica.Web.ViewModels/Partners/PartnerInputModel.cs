namespace TaxiDinamica.Web.ViewModels.Partners
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Web.ViewModels.Common.CustomValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class PartnerInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Placa")]
        [StringLength(
            GlobalConstants.DataValidations.PlacaMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Placa,
            MinimumLength = GlobalConstants.DataValidations.PlacaMinLength)]

        public string Placa { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public int CityId { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.DriverName,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        [Display(Name = "Nombre del conductor")]
        public string DriverName { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Teléfono del conductor")]
        public string DriverContact { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Foto del Vehículo")]
        [ValidateImageFile(ErrorMessage = GlobalConstants.ErrorMessages.Image)]
        public IFormFile Image { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Pase para Transporte Publico")]
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.ReqFile)]
        public IFormFile PaseUrl { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Cédula del Conductor")]
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.ReqFile)]
        public IFormFile CedulaUrl { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Tarjetón")]
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.ReqFile)]
        public IFormFile TarjetonUrl { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "SOAT")]
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.ReqFile)]
        public IFormFile SoatUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Licencia")]
        public IFormFile LicenciaUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Tarjeta de Operación")]
        public IFormFile OperacionUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Seguro Extra y Contractual")]
        public IFormFile SeguroUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Revisión Tecnomecánica")]
        public IFormFile TecnoUrl { get; set; }

    }
}
