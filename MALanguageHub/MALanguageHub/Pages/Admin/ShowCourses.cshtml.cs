using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MALanguageHub.Pages.Admin
{
    public class ShowCoursesModel : PageModel
    {
        MALHdbcontext db;
        IWebHostEnvironment env;
        public List<Courses> courses { get; set; }
        
        public string UserName;
        public ShowCoursesModel(MALHdbcontext _db, IWebHostEnvironment _env)
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
            ViewData["title"] = "Courses Detail";
            courses =db.tbl_courses.ToList();
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }

        public IActionResult OnGetDelete(int Id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            try
            {
                var ItemToDel = db.tbl_courses.Where(x => x.Id == Id).FirstOrDefault();
                if (ItemToDel != null)
                {
                    db.tbl_courses.Remove(ItemToDel);
                    db.SaveChanges();
                    TempData["success"] = "Course Deleted Successfully";
                    return RedirectToPage("ShowCourses");
                }
                else
                {
                    TempData["error"] = "Course not found.";  
                    return Page();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while deleting the course.";
                return RedirectToPage();

            }
        }

    }
}
