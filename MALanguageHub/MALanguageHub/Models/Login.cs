using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [Display(Name = "User Name")]
        [MaxLength(100, ErrorMessage = "Username cannot exceed 100 characters.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        [StringLength(100, ErrorMessage = "Password cannot exceed 100 characters.")]
        public string Password { get; set; }

       
        [Display(Name = "Full Name")]
        [StringLength(200, ErrorMessage = "Full Name cannot exceed 200 characters.")]
        public string? FullName { get; set; }
        [Display(Name = "Image")]
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }


    }


}

