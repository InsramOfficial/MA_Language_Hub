using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.OurProfessionalDetails
{
    public class IndexModel : PageModel
    {
		private readonly MALHdbcontext db;

		public List<OurProfessionals> professionals {  get; set; }
        public string UserName;
        public IndexModel(MALHdbcontext db)
		{
			this.db = db;
		}
		public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            professionals = db.tbl_ourprofessionals.ToList();
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }

		public IActionResult OnGetDelete(int id) 
		{
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            try
            {
                OurProfessionals deleteto = db.tbl_ourprofessionals.Where(x => x.Id == id).FirstOrDefault();
                db.tbl_ourprofessionals.Remove(deleteto);
                db.SaveChanges();
                TempData["success"] = "Record Deleted Successfully";
                return RedirectToPage("index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Error While Deleting Record";
                return RedirectToPage();

            }
        }
    }
}
