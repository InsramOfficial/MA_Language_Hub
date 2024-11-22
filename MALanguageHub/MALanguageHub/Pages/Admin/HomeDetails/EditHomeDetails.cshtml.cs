using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class EditHomeDetailsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public Home Homedetail { get; set; }
        public EditHomeDetailsModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet(int id)
        {
            Homedetail = db.tbl_home.Find(id);
        }
        public IActionResult OnPost(Home Homedetail)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Home update = new();
                update.Id = Homedetail.Id;
                update.Title = Homedetail.Title;
                update.Description = Homedetail.Description;
                if(Homedetail.Image == null)
                {
                    update.ImageName = Homedetail.ImageName;
                }
                else
                {
                    update.ImageName = Homedetail.Image.FileName;
                    var folderpath = Path.Combine(env.WebRootPath, "images");
                    var imagepath = Path.Combine(folderpath, Homedetail.Image.FileName);
                    Homedetail.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                    
                }
                db.tbl_home.Update(update);
                db.SaveChanges();
            }
            return RedirectToPage("index");
        }
    }
}
