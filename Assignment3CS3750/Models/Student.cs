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
        public string fname { get; set; }
        public string lname { get; set; }
        // public string Email { get; set; }

        public string Username { get; set; }
        //want to verify password
        public string Password { get; set; }
        public string Project { get; set; }

       
            
    }
    
}