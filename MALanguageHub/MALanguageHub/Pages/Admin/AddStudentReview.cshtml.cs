using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class AddStudentReviewModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public StudentReviews StudentReviews { get; set; }
        public string UserName;

        public AddStudentReviewModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }
        public IActionResult OnPost(StudentReviews StudentReviews)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                db.tbl_studentreviews.Add(StudentReviews);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Review Added Successfully";
            }
            return RedirectToPage("ShowStudentReview");
        }
    }
}
