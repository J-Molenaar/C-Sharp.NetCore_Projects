using System.ComponentModel.DataAnnotations;
namespace BankAccounts.Models
{
    public class UsersViewModel 
    {
        [Required]
        [MinLength(2, ErrorMessage = "First name is required and must be at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string first { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Last name is required and must be at least 2 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string last { get; set; }

        [Required]
        [EmailAddress (ErrorMessage = "Email address is required.")]
        public string email { get; set; }
 
        [Required]
        [MinLength(8, ErrorMessage = "Password is required and must be at least 8 characters.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
 
        [Required]
        [Compare("password", ErrorMessage="Passwords must match")]
        [DataType(DataType.Password, ErrorMessage="Please confirm your password.")]
        public string confirm{get;set;}
    }
}