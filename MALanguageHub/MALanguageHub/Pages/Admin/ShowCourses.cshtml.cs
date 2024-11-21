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
        public ShowCoursesModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        public void OnGet()
        {
           courses=db.tbl_courses.ToList();
        }

        public IActionResult OnGetDelete(int Id)
        {
            try
            {
                var ItemToDel = db.tbl_courses.Find(Id);
                if (ItemToDel != null)
                {
                    db.tbl_courses.Remove(ItemToDel);
                    db.SaveChanges();
                    TempData["DeleteMessage"] = "The course has been successfully deleted.";  
                }
                else
                {
                    TempData["ErrorMessage"] = "Course not found.";  
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the course.";  
            }

            return RedirectToPage("ShowCourses");
        }

    }
}
