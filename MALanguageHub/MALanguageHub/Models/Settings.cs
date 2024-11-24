using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class Settings
    {
        [Key]
        public int Id { get; set; }
        [Display(Name  = "Website Name")]
        public string? Name { get; set; }
        [Display(Name = "Logo")]
        public string? LogoFavicon { get; set; }
        [NotMapped]
        public IFormFile LogoFav { get; set; }

    }
}
