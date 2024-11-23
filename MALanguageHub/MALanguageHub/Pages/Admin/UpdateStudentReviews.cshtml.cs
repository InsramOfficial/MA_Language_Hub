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
        public string UserName;

        public UpdateStudentReviewsModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }

        public IActionResult OnGet(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            StudentReviews = db.tbl_studentreviews.Find(id);
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
                TempData["info"] = "Insert your data correctly";
                return Page();
            }
            else
            {
                try
                {
                    db.tbl_studentreviews.Update(StudentReviews);
                    db.SaveChanges();
                    TempData["success"] = "Review Updated Successfully";
                    return RedirectToPage("ShowStudentReview");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Updating Review";
                    return Page();
                }
            }
            
        }
    }
}
