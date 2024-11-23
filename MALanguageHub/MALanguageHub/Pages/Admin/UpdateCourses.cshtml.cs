using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;

namespace MALanguageHub.Pages.Admin
{
    public class UpdateCoursesModel : PageModel
    {
        MALHdbcontext db;
        IWebHostEnvironment env;
        [BindProperty]
        public Courses courses { get; set; }
		public List<OurProfessionals> professionals { get; set; } = new List<OurProfessionals>();
        public string UserName;
        public UpdateCoursesModel(MALHdbcontext _db, IWebHostEnvironment _env)
        {
            db = _db;
            env = _env;
        }

        public IActionResult OnGet(int id)
        {
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            courses = db.tbl_courses.Find(id);
			professionals = db.tbl_ourprofessionals.ToList();
            UserName = HttpContext.Session.GetString("FullName");
            return Page();
        }

		public IActionResult OnPost(Courses courses)
		{
			if(!ModelState.IsValid)
			{
                TempData["info"] = "Insert your data correctly";
                return Page();
			}
			else
			{
				try
				{
					Courses update = new();
					update.Id = courses.Id;
					update.Title = courses.Title;
					update.Description = courses.Description;
					update.Duration = courses.Duration;
					update.Status = courses.Status;
					update.AllocatedTeacher = courses.AllocatedTeacher;
					update.StartingDate = courses.StartingDate;
					if(courses.Image == null)
					{
						update.ImageName = courses.ImageName;
					}
					else
					{
						update.ImageName = courses.Image.FileName;
                        var folderPath = Path.Combine(env.WebRootPath, "images");
                        var imagePath = Path.Combine(folderPath, courses.Image.FileName);
						courses.Image.CopyTo(new FileStream(imagePath, FileMode.Create));
                    }
					db.tbl_courses.Update(update);
					db.SaveChanges();
					TempData["success"] = "Course Details Updated Successfully";
					return RedirectToPage("ShowCourses");

				}
				catch(Exception ex)
				{
					TempData["error"] = "Error While Updating Details";
					return Page();
				}
			}
			//try
			//{
			//	var existingRecord = db.tbl_courses.FirstOrDefault(x => x.Id == courses.Id);

			//	if (existingRecord != null)
			//	{
					 
			//		existingRecord.Title = courses.Title;
			//		existingRecord.Description = courses.Description;
			//		existingRecord.Duration = courses.Duration;
			//		existingRecord.Status = courses.Status;
			//		existingRecord.StartingDate = courses.StartingDate;
			//		existingRecord.AllocatedTeacher = courses.AllocatedTeacher;

				 
			//		if (courses.Image != null)
			//		{
			//			string imageName = Path.GetFileName(courses.Image.FileName);
			//			var folderPath = Path.Combine(env.WebRootPath, "images");
 
			//			if (!Directory.Exists(folderPath))
			//			{
			//				Directory.CreateDirectory(folderPath);
			//			}

			//			var imagePath = Path.Combine(folderPath, imageName);

						 
			//			using (var fs = new FileStream(imagePath, FileMode.Create))
			//			{
			//				courses.Image.CopyTo(fs);
			//			}
 
			//			existingRecord.ImageName = imageName;
			//		}

					 
			//		db.Update(existingRecord);
			//		db.SaveChanges();

					 
			//		TempData["SuccessMessage"] = "Record updated successfully.";
			//	}
			//	else
			//	{
					
			//		TempData["ErrorMessage"] = "Record not found.";
			//	}
			//}
			//catch
			//{
			
			//	TempData["ErrorMessage"] = "An error occurred while updating the data.";
			//}

			
			//return RedirectToPage("ShowCourses");
		}

	}
}
