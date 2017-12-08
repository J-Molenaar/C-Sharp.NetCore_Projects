using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ActivityCenter.Models
{
    public class Activity 
    {
        
        public int Activityid {get;set;}
        public string name {get;set;}
        public DateTime date {get;set;}
        public int duration {get;set;}
        public string durationtype {get;set;}
        public string description {get;set;}
        public int Userid {get;set;}
        public User User {get;set;}

        public List<Guest> Guests {get;set;}

        public Activity() {
            Guests = new List<Guest>();
        }
    }
}