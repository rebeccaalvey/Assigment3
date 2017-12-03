using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3CS3750.Models;

namespace Assignment3CS3750.Controllers
{
    public class StudentController : Controller
    {
        Student studentIn = new Student();
        Student studentOut = new Student();
        Student studentCreate = new Models.Student();

        // GET: Student
        public ActionResult Student()
        {
            List<SelectListItem> ObjItem = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Select", Value = "0", Selected = true},
                new SelectListItem { Text = "Project 1", Value = "1"},
                new SelectListItem { Text = "Project 2", Value = "2"},
                new SelectListItem { Text = "Project 3", Value = "3"},
                new SelectListItem { Text = "Project 4", Value = "4"},
                new SelectListItem { Text = "Project 5", Value = "5"},
            };

            ViewBag.ListItem = ObjItem;


            return View();
        }

        public ActionResult StudentClockIn()
        {
            //Debug.WriteLine("working");
            studentIn.ClockIn = DateTime.Now;
            //pass timestamp to database
            //won't need a view, just the timestamp to database
            return View(studentIn);
        }

        public ActionResult StudentClockOut()
        {
            studentOut.ClockOut = DateTime.Now;

            //pass time stamp  and comment to the database
            //won't actually need a view, just a timestamp
            return View(studentOut);
        }

        public ActionResult CreateStudentLogin()
        {
           //query student username and password
           //create new username and password
           //open the student login view.

            return View(studentCreate);
        }

        public ActionResult StudentLogin()
        {
            //if login successful return to the general student page
            //verify student login username and password

           
            return View();
        }

    }
}