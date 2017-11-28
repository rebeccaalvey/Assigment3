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
        // GET: Student
        public ActionResult Student()
        {
            return View();
        }

        public ActionResult StudentClockIn()
        {
            //Debug.WriteLine("working");
            studentIn.ClockIn = DateTime.Now;
            return View(studentIn);
        }

        public ActionResult StudentClockOut()
        {
            studentOut.ClockOut = DateTime.Now;
            return View(studentOut);
        }
    }
}