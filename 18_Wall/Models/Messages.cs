
using System.ComponentModel.DataAnnotations;

namespace Messages.Models
{
    public class Message {
        [Required]
        [MinLength(2, ErrorMessage="Please enter a first name with at least 2 characters.")]
        public string first{get;set;}
        
    }
    
}
