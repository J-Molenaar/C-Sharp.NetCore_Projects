using System;
using System.Collections.Generic;

namespace ActivityCenter.Models
{
    public class Guest 
    {
        public int Guestid { get; set; }
        public int Userid { get; set; }
        public int Activityid { get; set; }
        public User User { get; set; } 
        public Activity Activity {get; set;}
    }
}