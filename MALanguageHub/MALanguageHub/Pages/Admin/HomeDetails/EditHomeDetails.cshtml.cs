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
        public string UserName;
        public EditHomeDetailsModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult OnGet(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
                return RedirectToPage("/Admin/Login");
            }
            ViewData["title"] = "Edit Home Detail";
            Homedetail = db.tbl_home.Find(id);
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }
        public IActionResult OnPost(Home Homedetail)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
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
                    Home update = new();
                    update.Id = Homedetail.Id;
                    update.Title = Homedetail.Title;
                    update.Description = Homedetail.Description;
                    if (Homedetail.Image == null)
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
                    TempData["success"] = "Home Details Updated Successfully";
                    return RedirectToPage("index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Updating Home Details";
                    return RedirectToPage();

                }
            }
        }
    }
}
