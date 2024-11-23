using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class AddHomeDetailsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public Home Homedetail {  get; set; }
        public string UserName;
        public AddHomeDetailsModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
                return RedirectToPage("/Admin/Login");
            }
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
                    if (Homedetail.Image != null)
                    {
                        Homedetail.ImageName = Homedetail.Image.FileName;
                        var folderpath = Path.Combine(env.WebRootPath, "images");
                        var imagepath = Path.Combine(folderpath, Homedetail.Image.FileName);
                        Homedetail.Image.CopyTo(new FileStream(imagepath, FileMode.Create));

                    }
                    db.tbl_home.Add(Homedetail);
                    db.SaveChanges();
                    TempData["success"] = "Home Detail Added Successfully";
                    return RedirectToPage("index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Adding Home Detail";
                    return Page();
                }
            }
        }
    }
}
