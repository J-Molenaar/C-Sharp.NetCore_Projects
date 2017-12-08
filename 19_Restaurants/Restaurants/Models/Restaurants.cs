using System;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Models{
    public abstract class BaseEntity{}
    public class Restaurant:BaseEntity{

        public int Id { get ; set;}

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get ; set;}

        [Required(ErrorMessage = "Restaurant name is required.")]
        public string Place{ get ; set;}

        [Required(ErrorMessage = "Location is required.")]
        public string Location { get ; set;}

        [Required (ErrorMessage = "Star rating is required.")]
        [Range(0,6, ErrorMessage = "Please select a rating between 0 and 5 stars.")]
        public int Stars { get ; set;}

        [Required (ErrorMessage = "Reivew is required.")]
        public string Review { get ; set;}

        [Required]
        public int Helpful { get ; set;}

        [Required]
        public int Unhelpful { get ; set;}

        public DateTime Created_at {get; set;}

        

        

        

        

        

        
    }


}