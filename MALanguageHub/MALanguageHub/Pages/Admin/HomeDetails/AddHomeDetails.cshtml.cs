using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class AddHomeDetailsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public Home Homedetail {  get; set; }
        public AddHomeDetailsModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet()
        {

        }
        public IActionResult OnPost(Home Homedetail)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Homedetail.ImageName = Homedetail.Image.FileName;
                var folderpath = Path.Combine(env.WebRootPath, "images");
                var imagepath = Path.Combine(folderpath,Homedetail.Image.FileName);
                Homedetail.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                db.tbl_home.Add(Homedetail);
                db.SaveChanges();
            }
            return RedirectToPage("index");
        }
    }
}
