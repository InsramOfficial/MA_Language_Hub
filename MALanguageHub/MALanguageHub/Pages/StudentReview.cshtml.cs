using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class StudentReviewModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public StudentReviews StudentReviews { get; set; }

        public StudentReviewModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(StudentReviews StudentReviews)
        {
            if (!ModelState.IsValid)
            {
                TempData["info"] = "Insert your data correctly";
                return Page();
            }
            else
            {
                try
                {
                    db.tbl_studentreviews.Add(StudentReviews);
                    db.SaveChanges();
                    TempData["success"] = "Thank You For Your Review";
                    return RedirectToPage("StudentReview");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Submitting Review";
                    return Page();
                }
            }
            
        }
    }
}
