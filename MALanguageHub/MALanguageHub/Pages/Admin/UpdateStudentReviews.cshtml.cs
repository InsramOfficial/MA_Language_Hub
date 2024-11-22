using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class UpdateStudentReviewsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public StudentReviews StudentReviews { get; set; }

        public UpdateStudentReviewsModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }

        public void OnGet(int id)
        {
            StudentReviews = db.tbl_studentreviews.Find(id);
        }
        public IActionResult OnPost(StudentReviews StudentReviews)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                db.tbl_studentreviews.Update(StudentReviews);
                db.SaveChanges();
                TempData["SuccessMessage"] = "Review Added Successfully";
            }
            return RedirectToPage("ShowStudentReview");
        }
    }
}
