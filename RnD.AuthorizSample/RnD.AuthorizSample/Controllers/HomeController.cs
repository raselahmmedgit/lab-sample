using RnD.AuthorizSample.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RnD.AuthorizSample.Controllers
{
    [Authorize]
    [InitializeAuthoriz]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        
        //IndexAjax
        public ActionResult IndexAjax()
        {
            var today = DateTime.Now.ToString();
            //return Json(today);
            return Json(new { message = today }, JsonRequestBehavior.AllowGet);
        }
    }
}
