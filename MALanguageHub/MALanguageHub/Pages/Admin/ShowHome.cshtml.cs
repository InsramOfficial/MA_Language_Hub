using MALanguageHub.Data;
using MALanguageHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MALanguageHub.Pages.Admin
{
    public class ShowHomeModel : PageModel
    {
		MALHdbcontext db;
		IWebHostEnvironment env;
		public List<Home> Home { get; set; }
		public ShowHomeModel(MALHdbcontext _db, IWebHostEnvironment _env)
		{
			db = _db;
			env = _env;
		}

		public void OnGet()
		{
			Home = db.tbl_home.ToList();
		}

		public IActionResult OnGetDelete(int Id)
		{
			try
			{
				var ItemToDel = db.tbl_home.Find(Id);
				if (ItemToDel != null)
				{
					db.tbl_home.Remove(ItemToDel);
					db.SaveChanges();
					TempData["DeleteMessage"] = "The course has been successfully deleted.";
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

			return RedirectToPage("ShowCourses");
		}
	}
}
