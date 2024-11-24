using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class YourReviewModel : PageModel
    {
        private readonly MALHdbcontext db;
        public StudentReviews StudentReviews { get; set; }
        public YourReviewModel(MALHdbcontext _db)
        {
            db = _db;
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
                    return RedirectToPage();
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
