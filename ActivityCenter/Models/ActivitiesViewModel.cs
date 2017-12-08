using System;
using System.ComponentModel.DataAnnotations;

namespace ActivityCenter.Models
{
    public class ActivitiesViewModel 
    {
        public int Activityid { get; set; }
        
        [Required]
        [MinLength(2, ErrorMessage = "Name is required.")]
        public string name { get; set; }
        
        [Required (ErrorMessage = "Future date is required.")]
        public DateTime date { get; set; }
 
        [Required(ErrorMessage = "Duration is required.")]
        public int duration { get ; set;}
        
        public string durationtype { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Description is required and must be at least 10 characters.")]
        public string description { get; set; }
        
        public int Userid { get; set; }
        public User User {get;set;}


    }
}