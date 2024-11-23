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
        public List<OurProfessionals> professionals { get; set; } = new List<OurProfessionals>();
        public string UserName;
        public AddCoursesModel(MALHdbcontext _db,IWebHostEnvironment _env)
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
            professionals = db.tbl_ourprofessionals.ToList();
            return Page();
        }

        public IActionResult OnPost(Courses courses)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if(courses.Image is not null)
                {
                    courses.ImageName = courses.Image.FileName;
                    var folderpath = Path.Combine(env.WebRootPath, "images");
                    var ImageNamepath = Path.Combine(folderpath, courses.Image.FileName);
                    courses.Image.CopyTo(new FileStream(ImageNamepath, FileMode.Create));
                }
                db.tbl_courses.Add(courses);
                db.SaveChanges();
                return RedirectToPage("ShowCourses");
            }
            //string ImageName = courses.Image.FileName.ToString();
            //var folderpath = Path.Combine(env.WebRootPath, "images");
            //var ImageNamepath = Path.Combine(folderpath, ImageName);
            //FileStream fs = new FileStream(ImageNamepath, FileMode.Create);
            //courses.Image.CopyTo(fs);
            //fs.Dispose();
            //courses.ImageName = ImageName;
            //db.tbl_courses.Add(courses);
            //db.SaveChanges();
            //return RedirectToPage("ShowCourses");

        }

    }
}
