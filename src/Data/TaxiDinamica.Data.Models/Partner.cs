namespace TaxiDinamica.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Partner : BaseDeletableModel<string>
    {
        public Partner()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Services = new HashSet<PartnerService>();
        }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Placa")]
        [StringLength(
            GlobalConstants.DataValidations.PlacaMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.Placa,
            MinimumLength = GlobalConstants.DataValidations.PlacaMinLength)]

        public string Placa { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Foto del Vehículo")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Pase para Transporte Publico")]
        public string DocPaseUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Cédula del Conductor")]
        public string DocCedulaUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Tarjetón")]
        public string DocTarjetonUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "SOAT")]
        public string DocSoatUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Licencia")]
        public string DocLicenciaUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Tarjeta de Operación")]
        public string DocOperacionUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Seguro Extra y Contractual")]
        public string DocSeguroUrl { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [Display(Name = "Revisión Tecnomecánica")]
        public string DocTecnoUrl { get; set; }

        public string Schedule { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [StringLength(
            GlobalConstants.DataValidations.NameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.DriverName,
            MinimumLength = GlobalConstants.DataValidations.NameMinLength)]
        [Display(Name = "Nombre del conductor")]
        public string DriverName { get; set; }

        [Display(Name = "Contacto del conductor")]
        public string DriverContact { get; set; }

        public bool Available { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<PartnerService> Services { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
