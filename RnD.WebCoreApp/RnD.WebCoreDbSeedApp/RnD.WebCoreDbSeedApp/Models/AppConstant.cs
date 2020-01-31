using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RnD.WebCoreDbSeedApp.Models
{
    public static class AppConstant
    {
        public static class SuperAdminUser
        {
            public static string UserName = "SuperAdmin";
            public static string Email = "superadmin@mail.com";
            public static string UserPassword = "Qwer!234";
            public static string RoleName = "SuperAdmin";
        }

        public static class AdminUser
        {
            public static string UserName = "Admin";
            public static string Email = "admin@mail.com";
            public static string UserPassword = "Qwer!234";
            public static string RoleName = "Admin";
        }

        public static class ManagerUser
        {
            public static string UserName = "Manager";
            public static string Email = "manager@mail.com";
            public static string UserPassword = "Qwer!234";
            public static string RoleName = "Manager";
        }

        public static class MemberUser
        {
            public static string UserName = "Member";
            public static string Email = "member@mail.com";
            public static string UserPassword = "Qwer!234";
            public static string RoleName = "Member";
        }
    }
}
