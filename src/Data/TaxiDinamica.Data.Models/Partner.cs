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

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public string DIANUrl { get; set; }

        public string Schedule { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.AddressMaxLength)]
        public string Address { get; set; }

        public string Website { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<PartnerService> Services { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
