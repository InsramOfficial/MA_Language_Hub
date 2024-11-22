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
		public IndexModel(MALHdbcontext db)
		{
			this.db = db;
		}
		public void OnGet()
        {
			professionals = db.tbl_ourprofessionals.ToList();
        }

		public IActionResult OnGetDelete(int id) 
		{
			OurProfessionals deleteto = db.tbl_ourprofessionals.Where(x => x.Id == id).FirstOrDefault();
			db.tbl_ourprofessionals.Remove(deleteto);
			db.SaveChanges();
			return RedirectToPage("index");
		}
    }
}
