using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MALanguageHub.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Starting date is required.")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        public string Duration { get; set; }

        [Required(ErrorMessage = "Allocated teacher is required.")]
        [StringLength(200, ErrorMessage = "Teacher name cannot exceed 200 characters.")]
        public string AllocatedTeacher { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [RegularExpression("(Available|NotAvailable)", ErrorMessage = "Status must be either 'Available' or 'NotAvailable'.")]
        public string Status { get; set; }


        [Display(Name = "Image")]
        [Required(ErrorMessage = "Please upload image")]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
