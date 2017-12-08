using System;
using System.Collections.Generic;

namespace ActivityCenter.Models
{
    public class User 
    {
        public int Userid { get; set; }
        public string first { get; set; }
        public string last { get; set; }
        public string email { get; set; }
        public string password { get; set; }
       public List<Activity> Activities { get; set; }
       public List<Guest> Guests { get; set; }

       public User(){ //this is a constructor function. When a new user is created, this automatically runs
            Activities = new List<Activity>();
            Guests = new List<Guest>(); //each user has an empty list of transactions
 //each user has an empty list of transactions
       }
    }
}