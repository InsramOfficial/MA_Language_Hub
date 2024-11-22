using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MALanguageHub.Pages.Admin
{
    public class AddAboutUsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public Aboutus Aboutus { get; set; }

        public AddAboutUsModel( MALHdbcontext _db,IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public IActionResult OnPost(Aboutus Aboutus)
        {
 
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                string ImageName = Aboutus.Image.FileName.ToString();
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var ImageNamepath = Path.Combine(folderpath, ImageName);
                Aboutus.Image.CopyTo(new FileStream(ImageNamepath, FileMode.Create));

                //FileStream fs = new FileStream(ImageNamepath, FileMode.Create);
                //Aboutus.Image.CopyTo(fs);
                //fs.Dispose();

                Aboutus.ImageName = ImageName;
                db.tbl_aboutus.Add(Aboutus);
                db.SaveChanges();
                return RedirectToPage("UpdateAboutUs");
            }
          
        }


    }
}
