using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class AddCoursesModel : PageModel
    {
        MALHdbcontext db;
        IWebHostEnvironment env;
        [BindProperty]
        public Courses courses { get; set; }
        public AddCoursesModel(MALHdbcontext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }


     
        public IActionResult OnPost(Courses courses)
        {
            string ImageName = courses.Image.FileName.ToString();
            var folderpath = Path.Combine(env.WebRootPath, "images");
            var ImageNamepath = Path.Combine(folderpath, ImageName);
            FileStream fs = new FileStream(ImageNamepath, FileMode.Create);
            courses.Image.CopyTo(fs);
            fs.Dispose();
            courses.ImageName = ImageName;
            db.tbl_courses.Add(courses);
            db.SaveChanges();
            return RedirectToPage("ShowCourses");
           
        }

    }
}
