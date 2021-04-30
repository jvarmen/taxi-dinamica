namespace CeroFilas.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Common;
    using CeroFilas.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Services = new HashSet<Service>();
            this.Partners = new HashSet<Partner>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
    }
}
