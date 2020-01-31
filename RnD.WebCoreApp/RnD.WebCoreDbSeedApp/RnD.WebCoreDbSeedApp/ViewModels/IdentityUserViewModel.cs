using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.WebCoreDbSeedApp.ViewModels
{
    public class IdentityUserViewModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public string RoleName { get; set; }
    }
}
