namespace CeroFilas.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Data.Common.Models;

    public class Appointment : BaseDeletableModel<string>
    {
        public DateTime DateTime { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string PartnerId { get; set; }

        public virtual Partner Partner { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }

        public virtual PartnerService PartnerService { get; set; }

        // The Partner can Confirm or Decline an appointment
        public bool? Confirmed { get; set; }

        // For every past (and confirmed) appointment the User can Rate the Partner
        // But rating can be given only once for each appointment
        public bool? IsPartnerRatedByTheUser { get; set; }
    }
}
