using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment3CS3750.Controllers
{
    public class AdministratorController : Controller
    {
        // GET: Administrator
        public ActionResult Administrator()
        {
            return View();
        }

		public ActionResult ProjectList()
		{
			// TODO Needs to go to the ProjectList View
			return View();
		}

		public ActionResult CreateProject()
		{
			return View();
		}

		public ActionResult CompleteProjectList()
		{
			return View();
		}
    }
}