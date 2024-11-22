using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class IndexModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;
        public List<Home> Homedetails {  get; set; }

        public IndexModel(MALHdbcontext db,IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet()
        {
            Homedetails = db.tbl_home.Take(3).ToList();
        }
	}
}
