using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("flag") == "true")
            {
                HttpContext.Session.Clear();
                TempData["success"] = "Logout Successfully!";
                return RedirectToPage("/Admin/Login");
            }
            else
            {
                return RedirectToPage("/Admin/Login");
            }
        }
    }
}
