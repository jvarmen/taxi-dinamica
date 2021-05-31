namespace TaxiDinamica.Web.ViewModels.Appointments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class AppointmentViewModel : IMapFrom<Appointment>
    {
        public string Id { get; set; }
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public virtual Partner Partner { get; set; }
        public string PartnerId { get; set; }

        [Display(Name = "Placa del Taxi")]
        public string PartnerPlaca { get; set; }
        public string PartnerDriverName { get; set; }
        public int ServiceId { get; set; }
        public string ServiceName { get; set; }
        public bool? Confirmed { get; set; }
        public bool? IsPartnerRatedByTheUser { get; set; }

        [Display(Name = "Dirección de Recogida")]
        public string AddressStart { get; set; }

        [Display(Name = "Dirección de Destino")]
        public string AddressEnd { get; set; }

        [Display(Name = "Comentario Adicional")]
        public string Comment { get; set; }

        [Display(Name = "Mensaje de Respuesta")]
        [StringLength(
    GlobalConstants.DataValidations.DescriptionMaxLength,
    ErrorMessage = GlobalConstants.ErrorMessages.Description,
    MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string DriverMessage { get; set; }

        [Display(Name = "Precio Ofrecido")]
        public int Price { get; set; }
    }
}
