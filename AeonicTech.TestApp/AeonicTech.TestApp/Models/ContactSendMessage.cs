using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.Models
{
    public class ContactSendMessage
    {
        [Required]
        [EmailAddress]
        public string ContactEmail { get; set; }
        
        [Required] 
        public string ContactName { get; set; }
        
        [Required] 
        public string ContactPhone { get; set; }
        
        [Required]
        public string ContactSubject { get; set; }
        
        [Required] 
        public string ContactMessage { get; set; }

        [Required]
        public string MessageCategory { get; set; }

        [Required]
        public string MessageCategoryValue { get; set; }

        [Required]
        public string RecipientEmail { get; set; }
    }
}
