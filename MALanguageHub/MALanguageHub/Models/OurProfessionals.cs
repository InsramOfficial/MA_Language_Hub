using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class OurProfessionals
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }


        [Url(ErrorMessage = "Invalid URL format.")]
        public string FacebookLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string WhatsAppLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string InstagramLink { get; set; }

        [Url(ErrorMessage = "Invalid URL format.")]
        public string LinkedInLink { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please upload image")]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }

}
