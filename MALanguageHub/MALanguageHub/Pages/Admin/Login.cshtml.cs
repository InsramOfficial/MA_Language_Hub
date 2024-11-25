using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class LoginModel : PageModel
    {

        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        [BindProperty]
        public Login Login { get; set; }
        public LoginModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }
        public IActionResult OnPost(Login login)
        {
            if (!ModelState.IsValid)
            {
                TempData["info"] = "Insert your data correctly";
                return Page();
            }

            else
            {
                var user = db.tbl_login.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

                var settings = db.tbl_settings.FirstOrDefault();
                if (user == null)
                {
                    TempData["error"] = "Invalid username or password.";
                    return RedirectToPage("/Admin/Login");
                }
                else
                {
                    HttpContext.Session.SetString("FullName", user.FullName);
                    HttpContext.Session.SetString("LogoFavicon", settings.LogoFavicon);
                    HttpContext.Session.SetString("flag", "true");
                    TempData["success"] = "Login successful!";
                    return RedirectToPage("/Admin/index");
                }
            }
        }

    }
}
