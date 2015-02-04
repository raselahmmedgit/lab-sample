using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading;
using System.Web.Mvc;
using WebMatrix.WebData;
using RnD.AuthorizSample.Models;

namespace RnD.AuthorizSample.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class InitializeAuthorizAttribute : ActionFilterAttribute
    {
        //private static SimpleMembershipInitializer _initializer;
        //private static object _initializerLock = new object();
        //private static bool _isInitialized;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //// Ensure ASP.NET Simple Membership is initialized only once per app start
            //LazyInitializer.EnsureInitialized(ref _initializer, ref _isInitialized, ref _initializerLock);

            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                string strIsAjaxRequest = "It is Ajax Request.";

                filterContext.Result = new JsonResult
                {
                    Data = new
                    {
                        // put whatever data you want which will be sent
                        // to the client
                        message = "Sorry, you are not logged user."
                    }, JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                string strIsRequest = "It is Request.";
            }
        }

        private class SimpleMembershipInitializer
        {
            public SimpleMembershipInitializer()
            {
                ////Database.SetInitializer<AppDbContext>(null);

                ////try
                ////{
                ////    using (var context = new AppDbContext())
                ////    {
                ////        if (!context.Database.Exists())
                ////        {
                ////            //// Create the SimpleMembership database without Entity Framework migration schema
                ////            //((IObjectContextAdapter)context).ObjectContext.CreateDatabase();
                ////        }
                ////    }

                ////    //WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
                ////    //WebSecurity.InitializeDatabaseConnection("AppDbContext", "User", "UserId", "UserName", autoCreateTables: true);
                ////}
                ////catch (Exception ex)
                ////{
                ////    throw new InvalidOperationException("The ASP.NET Simple Membership database could not be initialized. For more information, please see http://go.microsoft.com/fwlink/?LinkId=256588", ex);
                ////}
            }
        }

    }
}
