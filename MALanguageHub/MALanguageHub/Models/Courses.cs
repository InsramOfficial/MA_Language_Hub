using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace MALanguageHub.Models
{
    public class Courses
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


        [Required(ErrorMessage = "Starting date is required.")]
        [Display(Name = "Starting Date")]
        [DataType(DataType.Date)]
        public DateTime StartingDate { get; set; }

        [Required(ErrorMessage = "Duration is required.")]
        [Display(Name = "Duration")]
        public string? Duration { get; set; }

        [Required(ErrorMessage = "Allocated teacher is required.")]
        [Display(Name = "Allocated Teacher")]
        public int AllocatedTeacher { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        [Display(Name = "Status")]
        [RegularExpression("(Available|NotAvailable)", ErrorMessage = "Status must be either 'Available' or 'NotAvailable'.")]
        public string? Status { get; set; }

        [Display(Name = "Image")]
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
