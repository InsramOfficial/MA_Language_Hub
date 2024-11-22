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

        public ShowProfileModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }


        public void OnGet()
        {
            Login = db.tbl_login.FirstOrDefault();
        }



    }
}
