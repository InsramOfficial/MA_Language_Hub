using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin.ContactUsDetails
{
    public class EditContactUsModel : PageModel
    {
        private readonly MALHdbcontext db;
        public Contactus contact {  get; set; }
        public string UserName;
        public EditContactUsModel(MALHdbcontext db)
        {
            this.db = db;
        }
        public IActionResult OnGet()
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            UserName = HttpContext.Session.GetString("FullName");
            contact = db.tbl_contactus.FirstOrDefault();
            return Page();
        }
        public IActionResult OnPost(Contactus contact)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            if(!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                //db.tbl_contactus.Update(contact);
                //db.SaveChanges();
                // Attempt to update the contact
                db.tbl_contactus.Update(contact);
                int rowsAffected = db.SaveChanges(); // Capture the number of affected rows

                // Check if any rows were updated
                if (rowsAffected > 0)
                {
                    // Set success message in TempData
                    TempData["SuccessMessage"] = "Contact information updated successfully!";
                    return RedirectToPage("EditContactUs");
                }
                else
                {
                    // Optionally set an error message if no rows were updated
                    TempData["ErrorMessage"] = "No changes were made or the record was not found.";
                    return RedirectToPage("EditContactUs");
                }
                return RedirectToPage("EditContactUs");
            }

        }
    }
}
