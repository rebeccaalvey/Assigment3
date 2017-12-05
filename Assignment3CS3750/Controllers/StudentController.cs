using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

using Assignment3CS3750.Models;
using System.Text;
using System.Globalization;

namespace Assignment3CS3750.Controllers
{
    public class StudentController : Controller
    {
        Student studentIn = new Student();
        Student studentOut = new Student();
        Student studentCreate = new Student();

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
          
            studentIn.ClockIn = DateTime.Now;
           

            return View(studentIn);
        }
       // [HttpPost]
        public ActionResult StudentClockOut(Student Student)
        {
            
            studentOut.ClockOut = DateTime.Now;
            string dt = studentOut.ClockOut.ToString();
            // string dt = (DateTime.TryParse("ddmmyyyy HHMMss", out studentOut.ClockOut);


            string cm = Request["clockoutComment"];

            string result = cm  +"  " + dt;
            //pass time stamp  and comment to the database
            //won't actually need a view, just a timestamp
            // return Content(Model => Model.Clockoutcomment);
            //return Content(clockoutComment);
            return View (studentOut);
        }
       

        public ActionResult CreateStudentLogin()
        {

         
            return View();
        }

        public ActionResult StudentLogin()
        {
            //if login successful return to the general student page
            //verify student login username and password


              string pass = Request["Password"];
            //query student username and password
            //create new username and password
            //open the student login view.
             byte[] salt = new byte [16];

             new RNGCryptoServiceProvider().GetBytes(salt);

             string sSalt = System.Text.Encoding.UTF8.GetString(salt);
             var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
             byte[] hash = pbkdf2.GetBytes(20);

             byte[] hashBytes = new byte[36];
             Array.Copy(salt, 0, hashBytes, 0, 16);
             Array.Copy(hash, 0, hashBytes, 16, 20);

             string savedPasswordHash = Convert.ToBase64String(hashBytes);

             //need the db up and going
             //DBContext.AddUser(new User { ..., Password = savedPasswordHash });

            return Content(savedPasswordHash);

            //return View();
        }

    }

    /*public class Hash : StudentController
    {
        //get password

        MD5 md5 = new MD5CryptoServiceProvider();
        Byte[] hash = MD5.ComputeHash();
    }*/
}