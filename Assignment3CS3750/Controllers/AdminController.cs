using MySql.Data.MySqlClient;
using System;
using System.Web.Mvc;

namespace Assignment3CS3750.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ViewResult Login()
        {
       
            var dbCon = DBConnection.Instance();
            //var dbCon = D
            dbCon.DatabaseName = "assignment3";
            if (dbCon.IsConnect())
            {
                //suppose col0 and col1 are defined as VARCHAR in the DB
                string query = "SELECT Id FROM Frozen";
                var cmd = new MySqlCommand(query, dbCon.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string someStringFromColumnZero = reader.GetString(0);
                
                    Console.WriteLine(someStringFromColumnZero);
                    ViewData["admin"] = someStringFromColumnZero;
                }
            }
            return View();
        }
    }
}