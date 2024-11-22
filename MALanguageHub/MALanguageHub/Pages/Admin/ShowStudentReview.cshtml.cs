using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages
{
    public class ShowStudentReviewModel : PageModel
	{
		MALHdbcontext db;
		IWebHostEnvironment env;
		public List<StudentReviews> StudentReviews { get; set; }
		public ShowStudentReviewModel(MALHdbcontext _db, IWebHostEnvironment _env)
		{
			db = _db;
			env = _env;
		}

		public IActionResult OnGet()
		{
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            StudentReviews = db.tbl_studentreviews.ToList();
			return Page();
		}

		public IActionResult OnGetDelete(int Id)
		{
            if (!(HttpContext.Session.GetString("flag") == "true"))
            {
                return RedirectToPage("/Admin/Login");
            }
            try
			{
				var ItemToDel = db.tbl_studentreviews.Find(Id);
				if (ItemToDel != null)
				{
					db.tbl_studentreviews.Remove(ItemToDel);
					db.SaveChanges();
					TempData["DeleteMessage"] = "The Review has been successfully deleted.";
				}
				else
				{
					TempData["ErrorMessage"] = "Course not found.";
				}
			}
			catch (Exception ex)
			{
				TempData["ErrorMessage"] = "An error occurred while deleting the course.";
			}

			return RedirectToPage("ShowStudentReview");
		}

	}
}
