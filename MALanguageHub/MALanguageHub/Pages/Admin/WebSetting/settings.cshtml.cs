using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.WebSetting
{
    public class settingsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public Settings settings {  get; set; }
        public string UserName;
        public settingsModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        public IActionResult OnGet()
        {
            if(!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            settings = db.tbl_settings.FirstOrDefault();
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }
        public IActionResult OnPost(Settings settings)
        {
            try
            {
                Settings update = new();
                update.Id = settings.Id;
                update.Name = settings.Name;
                if (settings.LogoFav == null)
                {
                    update.LogoFavicon = settings.LogoFavicon;
                }
                else
                {
                    update.LogoFavicon = settings.LogoFav.FileName;
                    var folderpath = Path.Combine(env.WebRootPath, "images");
                    var ImageNamepath = Path.Combine(folderpath, settings.LogoFav.FileName);
                    settings.LogoFav.CopyTo(new FileStream(ImageNamepath, FileMode.Create));
                }
                db.tbl_settings.Update(update);
                db.SaveChanges();
                TempData["success"] = "Setting Updated Successfully";
                return RedirectToPage();
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error While Updating Settings";
                return RedirectToPage();

            }
        }
    }
}
