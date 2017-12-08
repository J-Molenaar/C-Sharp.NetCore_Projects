
using System.ComponentModel.DataAnnotations;

namespace Users.Models
{
    public class User {
        [Required]
        [MinLength(2, ErrorMessage="Please enter a first name with at least 2 characters.")]
        public string first{get;set;}
        [Required]
        [MinLength(2, ErrorMessage="Please enter a last name with at least 2 characters.")]
        public string last{get;set;}        
        [Required]
        [EmailAddress(ErrorMessage="Please enter a valid email address.")]
        public string email{get;set;}
        [Required]
        [DataType(DataType.Password, ErrorMessage="Please enter a valid password.")]
        [MinLength(8, ErrorMessage="Password must be at least 8 characters.")]
        public string pass1{get;set;}
        [Required]
        [Compare("pass1", ErrorMessage="Passwords must match")]
        [DataType(DataType.Password, ErrorMessage="Please confirm your password.")]
        public string pass2{get;set;}

    }
}
