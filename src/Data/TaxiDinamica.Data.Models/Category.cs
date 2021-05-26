namespace TaxiDinamica.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class Category : BaseDeletableModel<int>
    {
        public Category()
        {
            this.Services = new HashSet<Service>();
            this.Partners = new HashSet<Partner>();
        }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public virtual ICollection<Partner> Partners { get; set; }
    }
}
