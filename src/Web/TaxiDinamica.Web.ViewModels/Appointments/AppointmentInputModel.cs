namespace TaxiDinamica.Web.ViewModels.Appointments
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Web.ViewModels.Common.CustomValidationAttributes;

    public class AppointmentInputModel
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string PartnerId { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public int ServiceId { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Date { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [ValidateTimeString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Time { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Dirección de Recogida")]
        [StringLength(GlobalConstants.DataValidations.AddressMaxLength,
                    ErrorMessage = GlobalConstants.ErrorMessages.DriverName,
                    MinimumLength = GlobalConstants.DataValidations.AddressMinLength)]
        public string AddressStart { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Dirección de Destino")]
        [StringLength(GlobalConstants.DataValidations.AddressMaxLength,
                    ErrorMessage = GlobalConstants.ErrorMessages.DriverName,
                    MinimumLength = GlobalConstants.DataValidations.AddressMinLength)]
        public string AddressEnd { get; set; }

        [Display(Name = "Comentario Adicional")]
        public string Comment { get; set; }
        
        [Display(Name = "Precio Ofrecido")]
        public int Price { get; set; }
    }
}
