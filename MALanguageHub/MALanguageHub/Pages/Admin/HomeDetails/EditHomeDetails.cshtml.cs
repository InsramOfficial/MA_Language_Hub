using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.HomeDetails
{
    public class EditHomeDetailsModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public Home Homedetail { get; set; }
        public EditHomeDetailsModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public void OnGet()
        {
        }
    }
}
