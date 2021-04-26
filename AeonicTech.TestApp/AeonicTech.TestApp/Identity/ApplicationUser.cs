using Microsoft.AspNetCore.Identity;

namespace AeonicTech.TestApp.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser() { }
        public int CompanyId { get; set; }
    }
}
