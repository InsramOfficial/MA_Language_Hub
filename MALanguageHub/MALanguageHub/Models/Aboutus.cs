using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class Aboutus
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please Enter Description")]
        [Display(Name = "Description")]
        [MaxLength(120,ErrorMessage = "Description cannot be more than 120 characters")]
        public string Description { get; set; }
        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please upload image")]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
