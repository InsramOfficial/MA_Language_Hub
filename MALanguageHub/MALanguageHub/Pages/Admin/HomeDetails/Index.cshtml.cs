using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class IndexModel : PageModel
    {
        public string UserName;
        private readonly MALHdbcontext db;
        public List<Home> Homedetails {  get; set; }

        public IndexModel(MALHdbcontext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            if(!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
                return RedirectToPage("/Admin/Login");
            }
            UserName = HttpContext.Session.GetString("FullName");
            Homedetails = db.tbl_home.Take(3).ToList();
            return Page();

        }

        public IActionResult OnGetDelete(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This";
                return RedirectToPage("/Admin/Login");
            }
            try
            {
                Home deleteto = db.tbl_home.Find(id);
                db.tbl_home.Remove(deleteto);
                db.SaveChanges();
                TempData["success"] = "Home Detail Deleted Successfully";
                return RedirectToPage("index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error While Deleting Record";
                return Page();
            }
        }

    }
}
