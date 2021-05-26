namespace TaxiDinamica.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TaxiDinamica.Common;
    using TaxiDinamica.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [MaxLength(GlobalConstants.DataValidations.TitleMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [MaxLength(GlobalConstants.DataValidations.ContentMaxLength)]
        public string Content { get; set; }

        // BlogPost can be created only in the Admin Dashboard
        // so the Author is not a User, just a string for name
        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        [MaxLength(GlobalConstants.DataValidations.NameMaxLength)]
        public string Author { get; set; }

        [Required(ErrorMessage = GlobalConstants.ErrorMessages.Required)]
        public string ImageUrl { get; set; }
    }
}
