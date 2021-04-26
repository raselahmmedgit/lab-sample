using System.ComponentModel.DataAnnotations;

namespace AeonicTech.TestApp.ViewModels
{
    public partial class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
