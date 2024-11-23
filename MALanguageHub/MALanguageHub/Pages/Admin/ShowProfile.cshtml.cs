using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class ShowProfileModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public Login Login { get; set; }
        public string ImageName { get; set; }
        public string UserName;

        public ShowProfileModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }


        public IActionResult OnGet()
        {
            Login = db.tbl_login.FirstOrDefault();
            ImageName = Login.ImageName;
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }

        public IActionResult OnPost(Login Login)
        {
            if(!ModelState.IsValid)
            {
                TempData["info"] = "Insert your data correctly";
                return Page();
            }
            else
            {
                try
                {
                    Login update = new();
                    update.Id = Login.Id;
                    update.Username = Login.Username;
                    update.Password = Login.Password;
                    update.FullName = Login.FullName;

                    if (Login.Image is null)
                    {
                        update.ImageName = Login.ImageName;
                    }
                    else
                    {
                        update.ImageName = Login.Image.FileName;
                        var folderpath = Path.Combine(env.WebRootPath, "images");
                        var imagepath = Path.Combine(folderpath, Login.Image.FileName);
                        Login.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                    }
                    db.tbl_login.Update(update);
                    db.SaveChanges();
                    TempData["success"] = "Your Profile Save and Updated Successfully";
                    return RedirectToPage("ShowProfile");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Updating Your Profile";
                    return Page();
                }
            }   
        }
    }
}
