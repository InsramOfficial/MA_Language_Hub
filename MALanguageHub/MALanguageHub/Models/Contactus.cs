using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MALanguageHub.Models
{
    public class Contactus
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter your Address")]
        [Display(Name = "Address")]
        [MaxLength(100,ErrorMessage = "Address not exceed to 100 characters")]
        public string Address1 { get; set; }
        [Display(Name = "Second Address")]
        [AllowNull]
        public string? Address2 { get; set; }
        [Required(ErrorMessage = "Please Enter your Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress1 { get; set; }
        [Display(Name = "Second Email Address")]
        [AllowNull]
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress2 { get; set; }
        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter your Whatsapp Number")]
        [Display(Name = "Whatsapp Number (Format: (923XXXXXXXXX)")]
        public string WhatsappNumber { get; set; }
        [Display(Name = "Facebook")]
        [AllowNull]
        [DataType(DataType.Url, ErrorMessage = "Incorrect URL Format")]
        public string? Facebook { get; set; }
        [Display(Name = "Instagram")]
        [AllowNull]
        [DataType(DataType.Url,ErrorMessage = "Incorrect URL Format")]
        public string? Instagram { get; set; }
        [Display(Name = "TikTok")]
        [AllowNull]
        [DataType(DataType.Url, ErrorMessage = "Incorrect URL Format")]
        public string? TikTok { get; set; }
    }
}
