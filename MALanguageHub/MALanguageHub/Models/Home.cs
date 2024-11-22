using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [Display(Name = "Title")]
        [MaxLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [Display(Name = "Description")]
        [MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }

        [Display(Name = "Image")]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
