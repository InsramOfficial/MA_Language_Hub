using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.OurProfessionalDetails
{
    public class AddProfessionalModel : PageModel
    {
		private readonly MALHdbcontext db;
		private readonly IWebHostEnvironment env;

		public OurProfessionals professional { get; set; }
		public AddProfessionalModel(MALHdbcontext db, IWebHostEnvironment env)
		{
			this.db = db;
			this.env = env;
		}
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            return Page();
        }
        public IActionResult OnPost(OurProfessionals professional)
		{
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            if (!ModelState.IsValid)
			{
				return Page();
			}
			else
			{
				if(professional.Image == null)
				{
					professional.ImageName = null;
				}
				else
				{
					professional.ImageName = professional.Image.FileName;
					var folderpath = Path.Combine(env.WebRootPath, "images");
					var imagepath = Path.Combine(folderpath, professional.Image.FileName);
					professional.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
				}
				db.tbl_ourprofessionals.Add(professional);
				db.SaveChanges();
			}
			return RedirectToPage("index");
		}
    }
}
