namespace TaxiDinamica.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Data.Common.Models;

    public class PartnerService : BaseDeletableModel<int>
    {
        public PartnerService()
        {
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        public string PartnerId { get; set; }

        public virtual Partner Partner { get; set; }

        public int ServiceId { get; set; }

        public virtual Service Service { get; set; }
        
        public bool Available { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
