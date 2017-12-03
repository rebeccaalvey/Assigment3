using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3CS3750.Models
{
    public class Student
    {
        // [Required]
        //want to check/ display username from the database
        public string Username { get; set; }
        //want to verify password
        public string Password { get; set; }
        public string Project { get; set; }

        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public string ClockOutComment { get; set; }
        // public DateTime ClockIn = DateTime.Now;
    }
}