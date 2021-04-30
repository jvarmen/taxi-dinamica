namespace CeroFilas.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Data.Common.Models;

    public class Service : BaseDeletableModel<int>
    {
        public Service()
        {
            this.Partners = new HashSet<PartnerService>();
            this.Appointments = new HashSet<Appointment>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<PartnerService> Partners { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
