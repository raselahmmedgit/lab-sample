﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AeonicTech.TestApp.Identity
{
    public class AppClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, ApplicationRole>
    {
        public AppClaimsPrincipalFactory(
            UserManager<ApplicationUser> userManager
            , RoleManager<ApplicationRole> roleManager
            , IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        { }

        public async override Task<ClaimsPrincipal> CreateAsync(ApplicationUser user)
        {
            var principal = await base.CreateAsync(user);

            //if (!string.IsNullOrWhiteSpace(user.FirstName))
            //{
            //    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
            //        new Claim(ClaimTypes.GivenName, user.FirstName)
            //    });
            //}
            //if (!string.IsNullOrWhiteSpace(user.DisplayName))
            //{
            //    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
            //        new Claim("DisplayName", user.DisplayName)
            //    });
            //}
            //if (!string.IsNullOrWhiteSpace(user.LastName))
            //{
            //    ((ClaimsIdentity)principal.Identity).AddClaims(new[] {
            //         new Claim(ClaimTypes.Surname, user.LastName),
            //    });
            //}
            return principal;
        }
    }
}
