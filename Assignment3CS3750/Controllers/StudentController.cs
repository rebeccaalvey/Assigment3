using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;

using Assignment3CS3750.Models;
using System.Text;
using System.Globalization;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Assignment3CS3750.Controllers
{
    public class StudentController : Controller
    {
        
        Clock c = new Models.Clock();
        Student s = new Models.Student();

       /*public ViewResult DBConn() 
        {
            
            var dbCon = DBConnection.Instance();
            //var dbCon = D
            dbCon.DatabaseName = "assignment3";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT * FROM timesheets";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);

                    Console.WriteLine(someStringFromColumnZero);
                    ViewData["admin"] = someStringFromColumnZero;
                }
            }
            dbCon.Close();

            return View();
        }*/
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
           //Timesheet_data timesheet_data_id, timesheet_id, clock_in, clock_out, comment, modified
            
           // studentIn.ClockIn = DateTime.Now;
            var dbCon = DBConnection.Instance();
            //var dbCon = D
            dbCon.DatabaseName = "assignment3";
            

            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                string x = "";

                while (reader.Read())
                {
                    // someStringFromColumnZero = reader.GetString(0);
                    x = reader.GetString(0);
                    Console.WriteLine(x);                                     
                }

                c.clockInQuery = x;
                c.ClockIn = DateTime.Now;
            }
            

            dbCon.Close();
           
            return View(c);
            

        }
        //[HttpPost]
        public ActionResult StudentClockOut(Clock c2, FormCollection formCollection)
        {
          //  string cm = Request["clockoutComment"];
            c.ClockOut = DateTime.Now;
            //c.ClockOutComment = formCollection.GetValue("ClockOutComment").AttemptedValue;
            // c.ClockOutComment  = c2.ClockOutComment;
            c.ClockOutComment = Request.Form["Item2.ClockOutComment"].ToString();
              
            //c.ClockOutComment = "comments";


            return View("StudentClockOut", c);
        }

        //[HttpPost]
        public ActionResult CreateStudentLogin(Student s2, FormCollection formCollection)//Student s2, FormCollection formCollection)
        {
            if (!string.IsNullOrEmpty(Request.Form["Username"]))
            {
                s.Username = Request.Form["Username"].ToString();
                s.Password = Request.Form["Password"].ToString();
                s.fname = Request.Form["fname"].ToString();
                s.lname = Request.Form["lname"].ToString();
            }

            // s.Username = Request.Form["model.Username"].ToString();

            //s.Password = Request.Form["Password"].ToString();
            // s.Username = Request["Username"];
            //  s.lname = Request.Form["lname"];
            //  s.fname = Request.Form["fname"];
            // s.fname = Request.Form["fname"].ToString();
            //  s.lname = Request.Form["lname"].ToString();*/
            try
            {


                var dbCon = DBConnection.Instance();
                dbCon.DatabaseName = "assignment3";


                if (dbCon.IsConnect())
                {
                    //suppose col0 and col1 are defined as VARCHAR in the DB
                    string query = "Insert Into users(password, user_name, last_name,first_name, admin) " +
                        "VALUES (@password, @user_name, @last_name, @first_name,0)";
                    //var cmd = new MySqlCommand(query, dbCon.Connection);
                    //  var reader = cmd.ExecuteReader();
                    /*  string x = "";

                      while (reader.Read())
                      {
                          // someStringFromColumnZero = reader.GetString(0);
                          x = reader.GetString(2);
                          Console.WriteLine(x);
                      }*/

                    using (var cmd = new MySqlCommand(query ))
                    {
                        cmd.Connection = dbCon.Connection;
                        cmd.Parameters.AddWithValue("@password", s.Password);
                        cmd.Parameters.AddWithValue("@user_name", s.Username);
                        cmd.Parameters.AddWithValue("@last_name", s.lname);
                        cmd.Parameters.AddWithValue("@first_name", s.fname);
                        /*
                        cmd.Parameters.Add(new MySqlParameter("@password", s.Password));
                        cmd.Parameters.Add(new MySqlParameter("@user_name", s.Username));
                        cmd.Parameters.Add(new MySqlParameter("@first_name", s.fname));
                        cmd.Parameters.Add(new MySqlParameter("@last_name", s.lname));
                        */
                        cmd.ExecuteNonQuery();

                        dbCon.Close();
                    }
                }

            }
            catch (MySqlException ex)
            {
                Console.Write( "Data not inserted !" + ex);
            }

            return View("CreateStudentLogin", s);
        }

        //[HttpPost]
        public ActionResult StudentLogin()
        {
            //if login successful return to the general student page
            //verify student login username and password


            // string pass = Request["Password"];

            string pass = "delete later";
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

           // return Content(savedPasswordHash);

            return View(s);
        }
        


    }

    /*public class Hash : StudentController
    {
        //get password

        MD5 md5 = new MD5CryptoServiceProvider();
        Byte[] hash = MD5.ComputeHash();
    }*/
}