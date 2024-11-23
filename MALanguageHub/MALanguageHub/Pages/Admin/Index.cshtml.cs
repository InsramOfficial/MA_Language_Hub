using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly MALHdbcontext db;
       


        public IndexModel(MALHdbcontext _db)
        {
            db = _db;
        }
        
        public string UserName;
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            
            int homeCount = db.tbl_home.Count();
            int coursesCount = db.tbl_courses.Count();
            int professionalsCount = db.tbl_ourprofessionals.Count();
            int studentReviewsCount = db.tbl_studentreviews.Count();
            
           
            ViewData["HomeCount"] = homeCount;
            ViewData["CoursesCount"] = coursesCount;
            ViewData["ProfessionalsCount"] = professionalsCount;
            ViewData["StudentReviewsCount"] = studentReviewsCount;


            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Admin/Login");
        }
    }
}
