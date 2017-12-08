using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Users.Models{
    
    public class User 
        {
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
       
       [Required]
       [EmailAddress]
        public string Email { get; set; }
       
       [Required]
       [DataType(DataType.Password)]
        public string Password { get; set; }
        
     }
}

