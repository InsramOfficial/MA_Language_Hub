using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.OurProfessionalDetails
{
    public class EditProfessionalModel : PageModel
    {
        private readonly MALHdbcontext db;
        private readonly IWebHostEnvironment env;

        public OurProfessionals professional {  get; set; }
        public string UserName;
        public EditProfessionalModel(MALHdbcontext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }
        public IActionResult OnGet(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            professional = db.tbl_ourprofessionals.Where(x => x.Id == id).FirstOrDefault();
            UserName = HttpContext.Session.GetString("FullName");
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
                TempData["info"] = "Insert your data correctly";
                return Page();
            }
            else
            {
                try
                {
                    OurProfessionals update = new();
                    update.Id = professional.Id;
                    update.Title = professional.Title;
                    update.Description = professional.Description;
                    update.FacebookLink = professional.FacebookLink;
                    update.InstagramLink = professional.InstagramLink;
                    update.LinkedInLink = professional.LinkedInLink;
                    update.WhatsAppLink = professional.WhatsAppLink;

                    if (professional.Image == null)
                    {
                        update.ImageName = professional.ImageName;

                    }
                    else
                    {
                        update.ImageName = professional.Image.FileName;
                        var folderpath = Path.Combine(env.WebRootPath, "images");
                        var imagepath = Path.Combine(folderpath, professional.Image.FileName);
                        professional.Image.CopyTo(new FileStream(imagepath, FileMode.Create));
                    }
                    db.tbl_ourprofessionals.Update(update);
                    db.SaveChanges();
                    TempData["success"] = "Details Updated Successfully";
                    return RedirectToPage("index");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Updated Details";
                    return RedirectToPage();

                }
            }
            
        }
    }
}
