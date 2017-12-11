using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment3CS3750.Models
{
    public class Clock
    {
       
            public DateTime ClockIn { get; set; }
            public DateTime ClockOut { get; set; }

            public string ClockOutComment { get; set; }
            public string clockInQuery { get; set; }
            // public DateTime ClockIn = DateTime.Now;

   
    }
}