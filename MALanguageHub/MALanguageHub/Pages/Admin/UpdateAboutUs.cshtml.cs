using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class UpdateAboutUsModel : PageModel
    {
        MALHdbcontext db;
        IWebHostEnvironment env;
        public Aboutus Aboutus { get; set; }

        public UpdateAboutUsModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;

        }
        public void OnGet()
        {
            Aboutus = db.tbl_aboutus.FirstOrDefault();
        }
        public IActionResult OnPost(Aboutus Aboutus)
        {
            try
            {
                var existingRecord = db.tbl_aboutus.FirstOrDefault(x => x.Id == Aboutus.Id);

                if (existingRecord != null)
                {
                    existingRecord.Title = Aboutus.Title;
                    existingRecord.Description = Aboutus.Description;

                    if (Aboutus.Image != null)
                    {
                        string imageName = Path.GetFileName(Aboutus.Image.FileName);
                        var folderPath = Path.Combine(env.WebRootPath, "images");

                        if (!Directory.Exists(folderPath))
                        {
                            Directory.CreateDirectory(folderPath);
                        }

                        var imagePath = Path.Combine(folderPath, imageName);

                        using (var fs = new FileStream(imagePath, FileMode.Create))
                        {
                            Aboutus.Image.CopyTo(fs);
                        }

                        existingRecord.ImageName = imageName;
                    }

                    db.Update(existingRecord);
                    db.SaveChanges();

                    TempData["SuccessMessage"] = "Record updated successfully.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Record not found.";
                }
            }
            catch
            {
                TempData["ErrorMessage"] = "An error occurred while updating the data.";
            }

            return RedirectToPage("UpdateAboutUs");
        }

    }
}
