using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.ContactUsDetails
{
    public class AddContactUsModel : PageModel
    {
        private readonly MALHdbcontext db;
        public Contactus contact {  get; set; }
        public string UserName;
        public AddContactUsModel(MALHdbcontext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
                return RedirectToPage("/Admin/Login");
            }
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }

        public IActionResult OnPost(Contactus contact)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                TempData["warning"] = "Please Login Before Access This Page";
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
                    db.tbl_contactus.Add(contact);
                    db.SaveChanges();
                    TempData["success"] = "Record Save Successfully";
                    return RedirectToPage("EditContactUs");
                }
                catch (Exception ex)
                {
                    TempData["error"] = "Error While Inserting Data";
                    return RedirectToPage();

                }
            }
            
        }
    }
}
