using Microsoft.AspNetCore.Identity;

namespace AeonicTech.TestApp.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }

        public bool IsActive { get; set; }
    }
}
