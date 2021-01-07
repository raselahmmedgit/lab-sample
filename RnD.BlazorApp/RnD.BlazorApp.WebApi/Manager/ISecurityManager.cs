using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RnD.BlazorApp.WebApi.Models;

namespace RnD.BlazorApp.WebApi.Manager
{
    public interface ISecurityManager
    {
        string GenerateJsonWebToken(UserModel model);
        UserModel AuthenticateUser(UserModel model);
    }
}
