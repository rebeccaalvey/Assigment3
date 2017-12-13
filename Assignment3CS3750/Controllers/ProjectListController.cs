using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3CS3750.Models;

namespace Assignment3CS3750.Controllers
{
    public class ProjectListController : Controller
    {
		Admin a = new Models.Admin();
		// GET: ProjectList
		public ActionResult ProjectList()
        {
			// Needs to sort by group name
			// Example data - Needs to be replaced with data array from database
			a.StudentGroup = new string[] {
				"Doug", "Sass", "Group 4", "20",
				"Rebecca", "Alvey", "Group 4", "20",
				"Mikaella", "Giffin", "Group 5", "20",
				"Brynn", "Player", "Group 5", "20"
			};
			a.StudentCount = 0;
			return View(a);
		}
    }
}