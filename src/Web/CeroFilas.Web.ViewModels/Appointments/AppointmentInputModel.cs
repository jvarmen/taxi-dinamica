namespace CeroFilas.Web.ViewModels.Appointments
{
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Web.ViewModels.Common.CustomValidationAttributes;

    public class AppointmentInputModel
    {
        [Required]
        public string PartnerId { get; set; }

        [Required]
        public int ServiceId { get; set; }

        [Required]
        [ValidateDateString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Date { get; set; }

        [Required]
        [ValidateTimeString(ErrorMessage = GlobalConstants.ErrorMessages.DateTime)]
        public string Time { get; set; }
    }
}
