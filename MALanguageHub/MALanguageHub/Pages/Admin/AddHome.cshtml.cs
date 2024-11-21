using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class AddHomeModel : PageModel
    {
        MALHdbcontext db;
        IWebHostEnvironment env;
        [BindProperty]
        public Home home { get; set; }
        public AddHomeModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        public IActionResult OnPost(Home home)
        {
            string ImageName = home.Image.FileName.ToString();
            var folderpath = Path.Combine(env.WebRootPath, "images");
            var ImageNamepath = Path.Combine(folderpath, ImageName);
            FileStream fs = new FileStream(ImageNamepath, FileMode.Create);
            home.Image.CopyTo(fs);
            fs.Dispose();
            home.ImageName = ImageName;
            db.tbl_home.Add(home);
            db.SaveChanges();
            return RedirectToPage("Showhome");

        }
    }
}
