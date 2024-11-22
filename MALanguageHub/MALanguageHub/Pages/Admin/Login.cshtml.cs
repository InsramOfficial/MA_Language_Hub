using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class LoginModel : PageModel
    {

        MALHdbcontext db;
        IWebHostEnvironment env;
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
                return Page();
            }

            else
            {
                var user = db.tbl_login.FirstOrDefault(u => u.Username == login.Username && u.Password == login.Password);

                if (user == null)
                {
                    TempData["ErrorMessage"] = "Invalid username or password.";
                    return Page();
                }

                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetString("flag", "true");

                TempData["SuccessMessage"] = "Login successful!";
                return RedirectToPage("index");
            }
        }

    }
}
